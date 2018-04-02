1.����������ԡ�
2.��һ��ʯͷ����������Ϸ��

1.IAuditLog ������¼��������־��
IAuditLog .

public interface IAuditable
{
	void WriteLog(int modelId,string userName,string moduleName,string tableName,string eventType,ModelBase newValues);
}


public interface IAuditable
{
	void WriteLog(int modelId,string userName,string moduleName,string tableName,string eventType,ModelBase newValue);
}

public class AuditLog:ModelBase
{
	public int ModelId;
	public string UserName;
	public string ModuleName;
	public string TableName;
	public string EventType;
	public ModelBase newValue;
}
public class AuditLog
{
	public int ModelId;
	public string UserName;
	public string ModuleName;
	public string TableName;
	public string EventType;
	public ModelBase newValue;
}
//DbContextBase ������DbContext�Ļ��࣬�����л�����CRUD �¼� ������һ�����캯��������ע�����ݿ����ӡ�
//����һ��IAuditLog ��������SaveChanges��ʱ��WriteLog .
public class LogDbContext:DbContextBase,IAuditable
{

}
public interface IAuditable
{
	void WriteLog(int modelId,string userName,string moduleName,string TableName,string eventType,ModelBase newValue);
}
public class AuditLog:ModelBase
{
	public int ModelId{get;set;}
	public string ModuleName{get;set;}
	public string TableName{get;set;}
	public string UserName{get;set;}
	public string EventType{get;set;}
	public ModelBase newValue{get;set;}
}

public class DbContextBase:DbContext,IDisposable,IDataRepository
{

}
public interface IDataRepository
{
	T Update<T>(T entity) where T:ModelBase;
	T Insert<T>(T entity) where T:ModelBase;
	void Delete<T>(T entity) where T:ModelBase;
	T Find<T>(params object[] keyValues) where T:ModelBase;
	List<T> FindAll<T>(Expiresson<Func<T,bool>> conditions) where T:ModelBase;
}
public class AuditLog:ModelBase
{
	public int ModelId{get;set;}
	public string UserName{get;set;}
	public string ModuleName{get;set;}
	public string TableName{get;set;}
	public string EventType{get;set;}
	public ModelBase newValues{get;set;}
}
public class DbContextBase:DbContext,IDisposable,IDataRepository
{
	public IAuditable AuditLog{get;set;}
	public DbContextBaes(string connectionString){
		this.Database.Connection.ConnectionString=connectionString;
		this.Configuration.LayzLoadingEnabled=false;
		this.Configuration.ProxyCreationEnabled=false;
	}

	public DbContextBase(string connectionString,IAuditable auditLog):base(connectionString){
			this.AuditLog=auditLog;
	}

	public T Update<T>(T entity) where T:ModelBase{
		this.Set<T>().Attach(entity);
		this.Entry<T>(entity).State=EntityState.Modified;
		this.SaveChanges();
		return entity;
	}
	public T Insert<T>(T entity) where T:ModelBase{
		this.Set<T>().Add(entity);
		this.SaveChanges();
		return entity;
	}
	public T Find<T>(params object[] keyValues) where T:ModelBase{
		return this.Set<T>().Find(keyValues);
	}
	
	public void Delete<T>(T entity) where T:ModelBase{
		this.Entry<T>(entity).State=EntityState.Deleted;
		this.SaveChanges();
	}

	public List<T> FindAll<T>(Expiression<Func<T,bool>> conditions=null) where T:ModelBase{
		if(conditions==null){
			return this.Set<T>().ToList();
		}else{
			return this.Set<T>().Where(conditions).ToList();
		}
	}

	public int SaveChanges(){
		this.WriteAuditLog();
		var result=base.SaveChanges();
		return result;
	}

	public void WriteAuditLog(){
		if(this.AuditLog==null){
			return;
		}
		foreach(var dbEntry in this.ChangeTracker.Entires<ModelBase>().Where(p=>p.State=EntityState.Added)){
			var auditAttr=dbEntry.Entity.GetType().GetCustomeAttribute(typeof(IAuditableAttribute),false) as IAuditableAttribtue;
			if(auditAttr==null){
				continute;
			}
			//����Ҫд��־
			//ΪʲôҪ����������д������Ϊ�Ƚ�ռ��ʱ����
			var operaterName=WCFContext.Current.Operater.Name;
			Task.Factory.StartNew(()=>{
				var tableName=dbEntry.Entity.GetType().GetCustomeAttribute(typeof(TableAttribute),false) as TableAttribute;
				string moduleName=dbEntry.Entity.GetType().FullName.Split(".").Skip(1).FirstOrDeault();
				auditLog.WriteLog(dbEntry.Entity.ID,operaterName,moduleName,tableName,dbEntry.State.ToString(),dbEntry.Entity);
			});
			
		}
	}
}

public class AuditLog:ModelBase
{
	public int ModelId{get;set;}
	public string UserName{get;set;}
	public string ModuleNasme{get;set;}
	public string TableName{get;set;}
	public string EventType{get;set;}
	public ModelBase NewValues{get;set;}
}
public class LogDbContext:DbContextBase,IAudtable
{
	public LogDbContext():base(CachedConfigContext.Current.DaoConfig){
	
	}
	public Set<AuditLog> AuditLogs;
	public void WriteLog(int modelId,string userName,string modelName,string tableName,string EventType,ModelBase newValues){
		

		this.AdutiLogs.Add(new{
			ModelId=modelId,
			UserName=userName,
			ModuleName=moduleName,
			TableName=tableName,
			EventType=eventType,
			ModelBase=modelBase
		});
		this.SaveChanges();
		this.Disposible();
	}
}

//ֱ����DbContext���ɾ���ˣ�����ҪDisposable .
//����Ļ��������Service .����Using .
public class LogDbContext:DbContextBase,IAuditable
{
	public LogDbContext():base(CachedConfigContext.Current.DaoConfig.LogDbContext){
	
	}
	public Set<AuditLog> AuditLogs{get;set;}

	public void WriteLog(){
		this.AuditLogs.Add(new{
			ModelId=modelId,
			UserName=userName,
			ModuleName=moduleName,
			TableName=tableName,
			EventType=eventType,
			ModelBase=JsonConvert.SerializeObject(modelBase,new JsonSerializerSettings(){ReferenceLoopHanding=ReferenceLoopHanding.Ignore})
		});
		this.saveChanges();
		this.Dispose();
	}
}

public interface IUserService
{
	IEnumerable<User> GetUserList(UserRequest request);
}
public class AccountDbContext:DbContextBase
{
	public class UserDbContext():base(CachedConfigContext.Current.DaoConfig.Account,new LogDbContext())
	{
	}

	public void onModelCreating(DbModelBuilder modelBulider){
		//user��Role���й����ģ�����һ��������

		this.SetInitliazer<AccountDbContext>(null);
		modelBuilder.Entity<User>().Map()
			.HasMany(e=>e.Role)
			.WithMany(e=>e.User)
			.Map(m=>{
				m.ToTable("UserRole");
				m.MapLeftKey("UserID");
				m.MapRightKey("RoleID");
			});
		base.onModelCreating(modelBuilder);
	}

	public DbSet<User> Users{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;}
	public DbSet<Role> Roles{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
}

public interface IUserService
{
	IEnumerable<User> GetUserList(UserRequest request);
}
public class UserService:IUserService
{
	public IEnumerable<User> GetUserList(UserRequest request){
		request=request??new UserRequest();
		using(var dbContext=new AccountDbContext()){
			var users=dbContext.Users.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.LoginName.Contains(request.UserName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(e=>e.Id).ToPagedList();
		}
	}

}

ToPagedList(){}
public class UserRequest:Request
{
	public string LoginName{get;set;}
	public string Mobile{get;set;}
}
public class Request
{
	public Request(){
		this.PageSize=5000;
	}
	public int Top{
		set{
			this.PageSize=value;
			this.PageIndex=1;
		}
	}
	public int PageIndex{get;set;}
	public int PageSize{get;set;}
}

//GMS.FrameWork.Contract
public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
	int TotalItemCount{get;set;}
}
public class PagedList:List<T>,IPagedList
{
	public PagedList<T>(IList<T> items,int pageIndex,int pageSize){
		
	}

}

΢���Ŷӣ�΢���Ŷӣ��������ߣ�-���/���߸�����֤ ���� ȷ�� ����

