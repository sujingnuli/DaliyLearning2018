��֤�룺 �Ƿ���Cookie�еġ�
this.CookieContext.VerifyCode.

��֤���Ƿ���Cookie�еġ�
�����ļ����� DaoConfig.xml�С�
Ȼ��ȥ��ȡxml�ļ������������ء����� ����Service��������Ҳ�Ǿ����õĵģ�CachedConfigContext.Current.DaoConfig.Log

protected override string 

jquery-tags-input .��ô�õġ�


Article 
	����
		Id,CreateTime,UserId,UserName.

public ActionResult Create(FormColelct)

public ActionResult Create(){
	var channelList=this.AccountService.GetChannelList(new ChannelRequest(){IsActive=true});
	this.ViewBag.channelId=new SelectList(channelList,"ID","Name");
	this.ViewBag.Tags=this.AccountService.GetTagList(new TagRequest(){Top=20,OrderBy=OrderBy.Hits});
	var model=new Article(){IsActive=true};
	return View("Edit",model);
}

public class ControllerBase:FrameControllerBaes
{
	public virtual IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
}


ServiceContext ������
public class ServiceContext
{
	public static ServiceContext Current{
		get{
			return CacheHelper.GetItem<ServiceContext>("ServiceContext",()=>new ServiceContext());
		}
	}
}

public class WebControllerBase
{
	public virtual IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
}
public class ServiceContext
{
	public static ServiceContext Current{
		get{
			return CacheHelper.GetItem<ServiceContext>("ServiceContext",()=>new ServiceContext());
		}
	}

	public IAccountService AccountService{
		get{
			return ServiceHelper.CreateService<IAccountService>();
		}
	}
}

//GMS.Core.Service
	public class ServiceHelper
	{
		//��ʱʹ�����÷���ʽ�����Ը����ע�룬����ʹ��WCF����ʽ
		public static ServcieFactory serviceFactory=new RefServiceFactory();
		public static T CreateService<T>() where T:class{
			var service=serviceFactory.CreateService<T>();
			var generator=new ProxyGeneratro();
			var dynamicGenerator=generator.CreateInterfaceProxyWithTargetInterface<T>()service,new InvokeInterceptor();
			return dynamicProxy;
		}
	}

�� IQueryable�����ݣ���������չ����չToPagedList .���صľ��Ƿ�װ��Page��ҳ�����ݡ�

return channels.OrderByDescending(m=>m.Id).ToPagedList(request.pageSize,request.PageIndex);


public class IPagedList
{
	int TotalItemCount{get;set;}
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
}
public class PagedList:List<T>,IPagedLIst
{
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return (int)Math.Ceiling(TotalItemCount/(double)PageSize);}}
	public int StartRecordIndex{get{return (CurrentPageIndex-1)*PageSize+1;}}
	public int EndRecordIndex{get{return TotalItemCount>CurrentPageIndex*PageSize?CurrentPageIndex*PageSize:TotalItemCount;}}
}


public class PageLinqExtensions
{
	public static PagedList<T>(this IQueryable<T> allItems,int pageIndex,int pageSize){
		if(pageIndex<1)
			pageIndex=1;
		var itemIndex=(pageIndex-1)*PageSize;
		var pageOfItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemCount=allItems.Count();
		return new PagedList(pageOfItems,pageIndex,pageSize,totalItemCount);
	}
}

IQueryable .ToPagedList

public class PageLinqExtensions
{
	public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems,int pageIndex,int pageSize){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(pageIndex-1)*PageSize;
		var pageItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemCount=allItems.Count();
		return new PagedList(allItems,pageIndex,pageSize,allItemCount);
	}
}

public ActionResult Create(){
	var channelList=this.CmsService.GetChannelList(new ChannelRequest(){IsActive=true});
	this.ViewBag.channelId=new SelectList(channelList,"ID","Name");
	this.ViewBag.Tags=this.CmsService.GetTagList(new TagRequest(){Top=20,OrderBy=OrderBy.Hits});
	var model=new Article();
	return View("Edit",model);
}

public class CmsService:ICmsService
{
	
}
public interface ICmsService
{
	IEnumerable<Channel> GetChannelList(ChannelRequest reuqest=null);
	IEnumerable<Tag> GetTagList(TagRequest request=null);
}

public class TagRequest:Request
{
	public OrderBy OrderBy{get;set;}
}
public class ChannelRequest:Request
{
	public string Name{get;set;}
	public bool? IsActive{get;set;}
}
public enum OrderBy{
	ID=0,
	Hits=1
}

public class CmsDbContext:DbContextBase
{
	///���캯����ע����������
	public CmsDbContext():base(CachedConfigContext.Current.DaoConfig.Cms,new LogDbContext()){
		
	}
	public override void OnModelCreating(DbModelBuilder modelBuilder){
		this.Database.SetInitializer<CmsDbContext>(null);
		modelBuilder.Entity<Article>()
			.HasMany(e=>e.Tags)
			.WithMany(e=>e.Articles)
			.Map(m=>{
				m.ToTable("ArticleTag");
				m.MapLeftKey("ArticleId");
				m.MapRightKey("TagId");
			});
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Tag> Tags;
	public DbSet<Channel> Channels;
	public DbSet<Article> Articles;
}

EF 
EntityFramework . ADO.NET  ��һ�� ORM��ܡ�
ORM object relationship Mapping 
object relation mapping .
Hibernet ,IBatis ,mybatis . java orm .
ef linq .


CodeFirst .���ȴ��� POCO ģ�͡����ݲ� DbContext ,DbContext ,Mapping .Database.Initlaizer

IQueryable IEnumerable 

IEnumerable ����ö������֧����ָ�����ͼ����ϼ򵥵����� 
IQueryable . �̳� IEnumerbale �ӿڣ� .net ���� Linq �� IQueryable��


public class CmsDbContext:DbContextBase
{
	public CmsDbContext():base(CachedConfigContext.Current.DaoConfig.Cms,new LogDbContext()){
	
	}
	public override void OnModelCreating(OnModelBuilder modelBuilder){
		this.Database.SetInitializer<CmsDbContext>(null);
		modelBuider.Entity<Aritlce>()
			.HasMany(e=>e.Tags)
			.WithMany(e=>e.Articles)
			.Map(m=>{
				m.ToTable("ArticleTag");
				m.MapLeftKey("ArticleId");
				m.MapRightKey("TagId");
		});
		base.OnModelBuilder();
	}
	public DbSet<Article> Articles{get;set;}
	public DbSet<Tag> Tags{get;set;}
	public DbSet<Channel> Channels{get;set;}
}
//ICmsService
public interface ICmsService
{
	public IEnumerable<Channel> GetChannelList(ChannelRequest request=null){
		request=request??new ChannelRequest(){IsActive=true};
		using(var dbContext=new CmsDbContext()){
			IQueryable<Channel> channels=dbContext.channels;
			if(request.IsActive!=null){
				channels=channels.Where(c=>c.IsActive==request.IsActive);
			}
			if(!string.IsNullOrEmpty(request.Name)){
				channels=channels.Where(c=>c.Name.Contains(request.Name));
			}
			return channels.OrderByDescending(c=>c.Id).ToPagedList(request.PageInde,request.PageSize);
		}
	}
	public IEnumerable<Tag> GetTagList(TagRequest request=null){
		request=request??new  TagReqeust();
		using(var dbContext=new CmsDbContext()){
			IQueryable<Tag> tags=dbContext.Tags;
			if(request.OrderBy==OrderBy.Hits){
				return tags.OrderByDescending(t=>t.Hits).ToPagedList(request.PageInde,request.PageSize);
			}else{
				return tags.OrderByDescending(t=>t.Id).ToPagedList(request.PageInde,request.PageSize);
			}
		}
	}
}

public class DbContextBase:DbContext,IDataRepository,IDisposable
{
		public IAuditable AuditLogger{get;set;} 
		public DbContextBase(string connectionString){
			this.Database.Connection.ConnectionString=connectionString;
			this.Configuration.LazyLoadingEnabled=false;
			this.Configuration.ProxyCreationEnabled=false;
		}

		public DbContextBase(string connectionString,IAuditable auditLogger):this(connectionString){
			this.AuditLoggger=auditLogger;
		}
		
		public T Update<T>(T entity) where T:ModelBase{
			this.Set<T>().Attach(entity);
			this.Entry<T>(entity).State=EntityState.Modified;
			this.SaveChanges();
			return entity;
		}

}
public interface IDataRepository
{
	T Update<T>(T entity) where T:ModelBase;
	T Insert<T>(T entity) where T:ModelBase;
	void Delete<T>(T entity) where T:ModelBase;
	T Find<T>(params object[] keyValues) where T:ModelBase;
	List<T> FindAll<T>(Expression<Func<T,bool>> conditions=null) where T:ModelBase;
	PagedList<T> FindAllByPage(Expression<Func<T,bool>> conditions=null,Expression<Func<T,S>> orderBy,int pageIndex,int pageSize) where T:ModelBase;
}
public class DbContextBase:DbContext,IDataRepository,IDisposable
{
	public IAuditable AuditLogger{get;set;}
	public DbContextBase(string connectionString){
		this.Database.Connnection.ConnectionString=connectionString;
		this.Configuration.LazyLoadingEnabeld=false;
		this.Configuration.ProxyCreationEnabled=false;
	}
	public DbContextBase(string connectionString,IAuditable auditLogger){
		this.AuditLogger=auditLogger;
	}
	public T Update<T>(T entity) where T:ModelBase{
		
	}
}


//������÷����õģ������Ǻܶ࣬������������ô�÷�����÷��������з�����ִ�еġ�
�Լ�д�Ŀ�ܣ�֧��lambda ����ʽ��
�Լ�д�����ݣ�֧��ί����


˼ά��ͼ��
	CPA .ȫ��֪ʶ�㡣
		
���񱨱� ��Ŀ

��ҵ�У������ϵ�����������Ľ���

�����ʲ�����������ڹ�ȨͶ�ʣ��̶��ʲ��������ʲ���

ERP . ������

����̵�����ݣ�������Ŷ��

1.��档
2.���ⵥ
3.���ⵥ