public class UserController:ComBaseController
{
	public ActionResult Index(){
		//��ȡ�û��б�
		var result=this.AccountService.GetUserList();
		return View(result);
	}
}

public class WebBaseController:Controller
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
	public static ServiceContext Current{
		get{
			return CacheHelper.Get<ServiceContext>("ServiceContext",()=>{
				return new ServiceContext();
			});
		}
	}

	public IAccountService AcountService{
		get{
			return ServiceHelper.CreateService<IAccountService>();
		}
	}
	public ICmsService CmsService{
		get{
			return ServiceHelper.CreateService<ICmsService>();
		}
	}
}
public class UserRequest:request
{
	public string LoginName{get;set;}
	public string 
}
public interface IAccountService
{
	IEnumerable<User> GetUserList(UserRequest request=null);
}
public class AccountService:IAccountService
{
	public IEnuemrable<User> GetUserList(UserRequest request=null){
		request=request??new UserRequest();
		using(var dbContext=new AccountDbContext()){
			IQueryable<User> users=dbContext.Users.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.LoginName.Contains(request.LoginName);)
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(u=>u.Id).ToPagedList(request.PageIndex,request.Page);
		}
	}
}
��ѯ������
request 
public class Request
{
	public Request(){
		PageSize=5000;
	}
	public int Top{
		set{
			this.PageIdex=1;
			this.PageSize=value;
		}
	}
	public int PageIndex{get;set;}
	public int PageSize{get;set;}
}

public class Request:ModelBase
{
	public Request(){
		this.PageSize=5000;
	}
	public int Top{
		set{
			this.PageIndex=1;
			this.PageSize=value;
		}
	}
	public int PageIndex{get;set;}
	public int PageSize{get;set;}

}
public class UserRequest:Request
{
	public string LoginName;
	public string Mobile;
}
public interface IAccountService
{
	IEnuemrable<User> GetUserList(UserRequest request=null);
}

public class AccountService
{
	public IEnumerable<User> GetUserList(UserRequest request=null){
		request=request??new UserRequest();
		using(var dbContext=new UserDbContext()){
			IQueryable<User> users=dbContext.Useres.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Cotains(request.Mobile));
			}
			return users.OrderByDescending(u=>u.Id).ToPagedList(request.PageIndex,request.PageSize);
		}
	}
}

//GMS.Core.Service
public class ServiceHelper
{
	public static SrviceFactory serviceFactory=new RefServiceFactory();

	public T CreateService<T>() where T:class{
		var service=serviceFactory.CreateService<T>();
		//ʹ��Castle.Core.dll�� һ��AOP ������
		//Castle �����.net ��һ����Դ��Ŀ�������ݷ��ʲ�ORM �� IOC�������ٵ�Web ���MVC��ܣ�AOP 
		//IOC �������������������������ϵ��������ϵ�����֮��ĵط�������Ŀ�ģ�����ϣ����á�
		//���ݷ��ʿ��ORM ,IOC������WEB���MVC ��AOP .
		var generator=new ProxyGenerator();
		var dynamicProxy=generator.CreateInterfaceTypeWithTargetInterface<T>(service,new InvokeInterceptor());
	}

}
	public class InvokeInterceptor:IInterceptor
	{
		public void Intercept(IInvocation invocation){
			try{
				invocation.Proceed();
			}catch(Exception e){
				if(e is BusinessException ){
					throw;
				}
				var message=new{
					exception=e.Message,
					excetpionContext=new{
						method=invocation.Method.ToString(),
						arguments=invocation.Arguments,
						returnValue=invocation.ReturnValue
					}
				};
				Log4NetHelper.Error(LoggerType.ServiceException,message,exception);
				throw;
			}
		}
	}	
}
}

public partial calss User:ModelBase
{
	public string LoginName{get;set;}
	public string Password{get;set;}
	public string Mobile{get;set;}
	public string Email{get;set;}
	public bool IsActive{get;set;}
	public virtual List<Role> Roles{get;set;}
	public List<int> RoleIds{get;set;}

	public virtual List<Role> Roles{get;set;}
}
public class Auditable:Attribute
{

}
[Auditable]
[Table("User")]
public class User:ModelBase
{
	public User(){
		
	}
	public string LoginName{get;set;}
	public string Password{get;set;}
	public string Mobile{get;set;}
	public string Email{get;set;}
	public bool IsActive{get;set;}
	public List<int> RoleIds{get;set;}
	[NotMapped]
	public List<Role> Roles{get;set;}
	[NotMapped]
	pulic string NewPassword{get;set;}
	[NotMapped]
	public List<EnumBusinessPermission> BusinessPermission 
	{
		get{
			var permissions=new List<EnumBusinessPermission>();
			foreach(var role in Roles){
				permission.AddRange(role.BusinessPermissionList);
			}
			return permissions.Distinct().ToList();
		}
	}
}

public class User:ModelBase
{
	public User(){
	
	}
	[Required(ErrorMessage="��¼������Ϊ��")]
	public string LoginName{get;set;}
	public string Password{get;set;}
	[RegularExpression(@"[1-9]{1}\d{10}#",ErrorMessage="������Ч���ֻ�����")]
	public string Mobile{get;set;}
	[RegularExpression(@"[A-Za-z0-9._+-]")]
	public string Email{get;set;}
	public bool IsActive{get;set;}
	[NotMapped]
	public string NewPassword{get;set;}
	public List<int> RoleIds{get;set;}
	[NotMapped]
	public List<Role> Roles{get;set;}
	public List<EnumBusinessPermission> BusinessPermissionList{
		get{
			var permissions=new List<EnumBusinessPermission>();
			foreach(var role in Roles){
				permission.AddRange(role.BusinessPermissionList);
			}
			return permission.Distinct().ToList();
		}
	}
}

public interface IAcccountService
{
	IEnumerable<User> GetUserList(UserRequest request=null);
}
public class AccountService:IAccountService
{
	public IEnumerable<User> GetUserList(UserRequest request=null){
		request=request??new UserRequest();
		using(var dbContext=new UserDbContext()){
			IQueryable<User> users=dbContext.Users.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(u=>u.Id).ToPagedList(request.PageIndex,request.PageSize);
		}
	}
}

public class AccountDbContext:DbContextBase
{
	public AccountDbContext():base(CachedConfig.Current.DaoConfig.Account,new LogDbConetxt()){}

	public void OnModelCreating(DbModelBuilder modelBuilder){
		Dabase.SetInitializer<AccountDbContext>(null);
		modelBuilder.Entity<User>().HasMany(e=>e.Roles).WithMany(e=>e.Users).Map(m=>{
			m.ToTable("UserRole");
			m.MapLeftKey("UserID");
			m.MapRightKey("RoleID");
		});
		base.OnModelCreating(modelBuilder);
	}
	public DbSet<User> Users{get;set;}
	
	public DbSet<Role> Roles{get;set;}

	public DbSet<LoginInfo> LoginInfos{get;set;}

	public DbSet<VerifyCode> VerifyCodes{get;set;}
}

public class AccountDbContext:DbContextBase
{
	public AccountDbContext():base(CachedConfigContext.Current.DaoConfig.Acount,new LogDbContext()){
	
	}
	public DbSet<User> Users{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;}
	public DbSet<Role> Roles{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
	public void OMdelCreating(DbModelBuilder modelBuilder){
		Database.SetInitializer<User>()
			.HasMany(e=>e.Roles)
			.WithMany(e=>e.Users)
			.Map(m=>{
			m.ToTable("UserRole");
			m.MapLeftKey("UserID");
			m.MapRightKey("RoleID");
		})
	}
}
public interface IAccountService
{
	IEnumerable<User> GetUserList(UserRequest request=null);
}
public class AccountService:IAccountService
{
	public IEnumerable<User> GetUserList(UserRequest request){
		request=request??new UserRequest();
		using(var dbContext=new AccountDbContext()){
			IQueryable<User> users=dbContext.Users.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(m=>m.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(m=>m.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(m=>m.ID).ToPagedList(request.PageIndex,request.PageSize);
		}
	}


}

public class AccountDbContext:DbContextBase
{
	//дһ�����ࡣ
	//������ͨ��������ע�롣
	public AccountDbContext():base(CachedConfig.Current.DaoConfig.Account,new LogDbContext()){
	
	}
	public override void OnModelBuilder(DbModleBulder modelBulder){
		Database.SetInitializer<AccountDbContext>(null);
		modelBulder.Entity<User>()
			.HasMany(e=>e.Role)
			.WithMany(e=>e.User)
			.Map(m=>{
				m.ToTable("UserRole");
				m.MapLeftKey("UserID");
				m.MapRightKey("RoleID");
		});
		base.OnModelBuilder(modelBuilder);
	}
}
public class AccountDbContext:DbContextBase
{
	public AccountDbContext():base(CachedConfigContext.Current.DaoConfig.Account,new LogDbContext()){

	
	}
	public override void OnModelBuilder(DbModelBuilder modelBulider){
		Database.SetInitializer<AccountDbContext>(null);
		modelBuilder.Entity<User>()
			.HasMany(e=>e.Roles)
			.WithMany(e=>e.User)
			.Map(m=>{
				m.ToTable("UserRole");
				m.MapLeftKey("UserID");
				m.MapRgithKey("RoleID");
			})
	}
	public DbSet<Role> Roles{get;set;}
	public DbSet<User> Users{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
}

Database.SetInitializer<T>(null);�Ӳ��������ݿ�
//GMS.Framework.DAL
//IDisposable: �ͷŷ��й���Դ�� ������Ҫʹ���йܶ���ʱ���������������Զ��ͷŷ����������ڴ档
//�����޷�Ԥ�������Ļ���ʱ�䡣���� �������������� ���ھ���ʹ򿪵��ĵ� �ȷ��й���Դ һ����֪��
//ͨ�����ַ�ʽ���ã�USING .TRY/FINALLY .
public class DbContextBase:DbContext,IDataRepository,IDiposable
{
	publc IAuditale AuditLogger{get;set;}
	public DbContext(string connectString){
		this.Database.Connection.ConnectionString=connectionString;
		this.Configuration.LayloadingEnabled=false;
		this.Configuration.ProxyCreationEnabled=false;
	}
	public DbContextBase(string connectionString,IAuditable auditLogger):this(connectionString){
		this.AuditLogger=auditLogger;
	}

	public T Update<T>(T entity) where T:ModelBase{
		var set=this.Set<T>();
		set.Attach(entity);
		this.Entity<T>(entity).State=EntityState.Modified;
		this.SaveChanges();
		return entity;
	}

	public T Insert<T>(T entity) where T:ModelBase{
		this.Set<T>().Add(entity);
		this.SaveChanges();
		return entity;
	}
	public void Delete<T>(T entity) where T:ModelBase{
		this.Set<T>(entity).State=EntityState.Deleted;
		this.SaveChanges();
	}
	public T Find<T>(params object[] keyValues) where T:ModelBase{
		return this.Set<T>().Find(keyValues);
	}
	public List<T> FindAll<T>(Expression<Func<T,bool>> conditions=null)where T:ModelBase{
		if(conditions==null)
				return this.Set<T>().ToList();
		else
				return this.Set<T>().Where(conditions).ToList();
	}
	public PagedList<T> FindAllByPages<T,S>(Ex)
	public void SaveChanges(){
		this.WriteAuditLog();
		var result=base.SaveChanges();
		return result;
	}

	internal void WriteAuditLog(){
		if(this.AuditLogger==null)
				return;
		foreach(var dbEntry in this.ChangeTracker.Entries<ModelBase>().Where(p=>p.State==EntityState.Added||EntityState.Modified))
	}
}

public class AccountDbContext:DbContextBase
{
	public AccountDbContext():base(CachedConfigContext.Current.DaoConfig.Acount,new LogDbContext()){
	
	}
	public override void OnModelBuilder(DbModelBuilder modelBuilder){
		Database.SetInitalizer<AccountDbContext>(null);
		modelBuilder.Entity<User>()
			.HasMany(m=>m.Role)
			.WithMany(m=>m.User)
			.Map(m=>{
				m.ToTable("UserRole");
				m.MapLeftKey("UserID");
				m.MapRightKey("RoleID");
		});
		base.OnModelBuilder(modelBuilder);
	}
	public DbSet<User> Users{get;set;}
	public DbSet<Role> Roles{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
}
public class AccountService:IAccountService
{
	public IEnumerable<User> GetUserList(UserRequest request=null){
		request=request??new UserRequest();
		using(var dbContext=new AccountDbContext()){
			IQueryable<User> users=dbContext.Users.Include("Role");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(m=>m.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(m=>m.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(m=>m.ID).ToPagedList(request.PageIndex,request.PageSize);
		}
	}
}