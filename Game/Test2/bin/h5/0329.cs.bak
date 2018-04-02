public class UserController:ComController
{
	public ActionResult Index(){
		var result=this.AccountService.GetUserList();
		return View(result);
	}
}

public class WebController:FrameController
{
	public IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
}
//GMS.Web
public class ServiceContext
{
	public static  ServiceContext Current{
		get{
			return CacheHelper.Get<ServiceContext>("ServiceContext",()=>new ServiceContext());
		}
	}

	public IAccountService AccountService{
		get{
			return ServiceHelper.CreateService<IAccountService>();
		}
	}
}
//GMS.CORE.SERVICE 
public class ServiceHelper
{
	public static ServiceFactory ServiceFactory=new RefServiceFactory();

	public static T CreateService<T>():where T:class{
		var service=serviceFactory.CreateService<T>();

		var generator=new ProxyGenerator();
		var dynamicProxy=generator.CreateInterfaceTypeWithTargetInterface<T>(service,new InvokeInterceptor());
		return ydnamicProxy;
	}
	
}
public class InvokeInterceptor:IInterceptor
{
	public void Incept(IInvocation invocation){
		try{
			invocation.Proceed();
		}catch(Exception e){
			if(e is BusinessException){
				throw;
			}
			var message=new{
				exception=e.Message;
				method=invocation.Method.ToString();
				arguments=invocation.Arguments;
				returnValue=invocation.ReturnValue;
			};
			Log4NetHelper.Error(LoggerType.WebException,message,exception);
		}
	}
}

public abstract class ServiceFactory
{
	 T CreateService<T>() where T:class;
}
public class RefServiceFactory
{
	public T CreateService<T>() where T:class{
		var interfaceName=typeof(T).Name;
		
		return CacheHelper.Get<T>(string.Format("Service_{0}",interfaceName),()=>{
			return AssemblyHelper.GetTypeByInterface<T>();
		});
	}
}


public class AssemblyHelper
{
	public static T GetTypeByInterface<T>(string searchPattern="*.dll")where T:class{
		var interfaceType=typeof(T);
		var domain=GetBaseDirectory();
		var dllFiles=Directory.GetFiles(domain,searchPattern,SearchOptions.TopDirectoryOnly);
		foreach(var fileName in dllFiles){
			foreach(var type in Assembly.LoadForm(fileName).GetLoadableTypes()){
				if(type!=interfaceType&&interfaceType.isAssignForm(type)){
					return Activator.CreateInstance(type) as T;
				}
			}
		}
		return null;
	}
	public static IEnuemrable<Type> GetLoadableTypes(this Assmebly assembly){
		try{
			return assembly.GetTypes();
		}catch(ReflectionLoadTypeException e){
			return e.Types.Where(e=>e!=null);
		}
	} 
	public static string GetBaseDirectory(){
		var baseDirectory=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirecotry;
		}
		return baseDirectory;
	}
}

public interface IAccountService
{
	IEnumerable<User> GetUserList(UserRequest  request=null);
}
public class AccountService:IAccountService
{
	public IEnuemrable<User> GetUserList(UserRequest request=null){
		request=request==null?new UserRequest();
		using(var dbContext=new AccountDbContext()){
			IQueryable<User> users=dbContext.Users.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(e=>e.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(e=>e.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(e=>e.ID).ToPagedList(requdest.PageIndex,request.PageSize);
		}
	}
}

public class AccountDbContext:DbContextBase
{
	public AccountDbContext():base(CachedConfigContext.Current.DaoConfig.Account,new LogDbContext()){
	
	}
	public override void OnModelBuilder(DbModelBuilder modelBuilder){
		Database.SetInitalizer<AccountDbContext>(null);
		modelBulider.Entity<User>()
			.HasMany(e=>e.Role)
			.WithMany(e=>e.User)
			.Map(m=>{
				m.ToTable("UserRole");
				m.MapLeftKey("UserID");
				m.MapRightKey("RoleID");
			});
		base.OnModelBuilder(modelBuilder);
	}
	public DbSet<User> Users{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
	public DbSet<Role> Roles{get;set;}
}

public class DbContextBase:DbContext,IDataRepository,IDisposable
{
	public DbContextBase(string connectionString){
		Database.Connection.ConnectionString=connectionString;
		this.Configuration.LazyLoadEnabled=false;
		this.Configuration.ProxyCreationEnabled=false;
	}
	public DbContextBase(string connectionString,IAuditable AuditLogger):this(connectionString){
		this.AuditLogger=AuditLogger;
	}

	public IAuditable AuditLogger{get;set;}

	public T Update<T>(T entity) where T:ModelBase{
		this.Set<T>().Attach(entity);
		this.Entry<T>(entity).State=EntityState.Modifield;
		this.SaveChanges();
	}

	public T Insert<T>(T entity) where T:ModelBase{
		this.Set<T>().Add(entity);
		this.SaveChanges();
		return entity;
	}
	public void Delete<T>(T entity)where T:ModelBase{
		this.Set<T>(entity).State=EntityState.Deleted;
		this.SaveChanges();
	}
	public T Find<T>(params object[] keyValues) where T:ModelBase{
		return this.Set<T>().Find(keyValues);
	}

	public List<T> FindAll<T>(Expression<Func<T,bool>> conditions) where T:ModelBase{
		if(conditions==null){
			return this.Set<T>().ToList();
		}else
			return this.Set<T>().Where(conditions).ToList();
	}
	public override int SaveChanges(){
		this.WriteAuditLog();
		var result=base.SaveChanges();
		return result;
	}
	//写日志。记录增，删，改
	
	internal void WriteAuditLog(){
		if(this.AuditLogger==null){
			return ;
		}
		///获取增删改的实例Entry .foreach(var dbEntry in this.ChangeTracker.Entries<ModelBase>().Where(p=>p.State=))
		foreach(var dbEntry in this.ChangeTracker.Entries<ModelBase>().Where(p=>p.State=EntityState.Added||p.State==EntityState.Modified||p.State==EntityState.Deleted)){
			var auditableAttr=dbEntry.Entity.GetType().GetCustomAttribute(typeof(AuditableAttribute),false).SingleOrDefault() as AuditableAttribute;
			if(auditableAttr==null){
				continute;
			}
			var operaterName=WCFContect.Current.OperaterName;

			//Task.Factory.NewStart创建一个新的任务，他又一个任务队列，通过任务调度器，把任务分配到线程池的空闲线程去执行。
			Task.Factory.StartNew(()=>{
				var tableAttr=dbEntry.Entity.GetType().GetCustomeAttribute(typeof(TableAttribute),false) as TableAttribute;
				string tableName=tableAttr!=null?tableAttr.Name:dbEntry.Entity.GetType().Name;
				var modelName=dbEntry.Entity.GetType().FullName.Split('.').Skip(1).FirstOrDefault();
				this.AuditLogger.WriteLog(dbEntry.Entity.ID,operaterName,moduleName,tableName,dbEnty.State.ToString(),dbEntry.Entity);
				ModelID,OepraterName,ModelName,TableName,EntryState,Entity
			});

		}
	}
}
}
//GMS.Framework.Contract
public interface IAuditable
{
	void WriteLog(int modelId,string userName,string modelName,string tableName,string eventType,ModelBase,newValue);
}
public class AuditableAttribute:Attribute
{
}
public class Request
{
	public Request(){
		this.PageSize=50000;
	}
	public int PageSize{get;set;}
	public int PageIndex{get;set;}
	public int Top{
		set{
			this.PageIndex=1;
			this.PageSize=value;
		}
	}
}
//GMS.Framework.

public interface IAuditable
{
	void WriteLog(int moelId,string userName,string moduleName,string tableName,string eventType,ModelBase newValue);
}
public class LogDbContext:DbCotnextBase,IAuditable
{
	public LogDbContext():base(CachedConfigContext.Current.DaoConfig.Log){
		Database.SetInitalizer<LogDbContext>(null);
	}

	public DbSet<AuditLog> AuditLogs{get;set;}

	public void WriteLog(int modelId,string userName,string moduleName,string tableName,string eventType,ModelBase newValue){
		this.AuditLogs.Add(new AuditLog(){
			ModelId=modelId,
			UserName=userName,
			ModuleName=moduleName,
			TableName=tableName,
			EventType=eventType,
			NewValues=JsonConvert.SerializerObject(newValues,new JsonSerializersettings(){ReferenceLoopHanding=ReferenceLoopHanding.Ignore})
		});
		this.SaveChanges();
		this.Dispose();
	}

}

//这个是操作记录表
//还有一个异常信息记录表
//增删改信息，如果传入auditable 要记录就记录。如果类有IAuditable 就记录。

public class DbContextBase:DbContext,IDataRepository,IDisposable
{
	public override int SaveChanges(){
		this.WriteAduitLog();
		var result=base.SaveChanges();
		return result;
	}
	internal void WriteLog(){
		if(this.AuditLogger==null){
			return ;
		}
		foreach(var dbEntry in this.ChangeTracker.Entires<ModelBase>().Where(p=>e.State==EntityState.Added||p.State=EntityState.Modified||p.State=EntityState.Deleted)){
			var auditableAttr=dbEntry.Entity.GetType().GetCustomeAttribute(typeof("table"),false) as TableAttribute;
			string tableName=auditableAttr!=null?auditableAttr.Name:dbEntry.Entity.GetType().Name;
			string moduleName=dbEntry.Entity.GetType().FullName.Split(".").Skip(1).FirstOrDefault();
			string userName=WCFContext.Current.Operater.Name;
			this.AuditLogger.WriteLog(dbEntry.Entity.ID,operterName,moduleName,tableName,dbEntry.State.ToString(),dbEntry.Entity);
		}
	}
}
//GMS.Framework.Contract
public interface IAuditable
{
	void WriteLog(int modelId,string userId,string moduleName,string tableNaem,string eventType,ModelBase newValue);
}
//GMS.Core.Log
public class LogDbContext:IAuditable,DbContextBase
{
	public LogDbContext():base(CachedConfigContext.Current.DaoConfig.Log){
	
	}

}
