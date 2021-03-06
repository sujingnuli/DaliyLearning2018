验证码： 是放在Cookie中的。
this.CookieContext.VerifyCode.

验证码是放在Cookie中的。
配置文件放在 DaoConfig.xml中。
然后去读取xml文件，放在哪里呢。链接 放在Service中吗，链接也是经常用的的，CachedConfigContext.Current.DaoConfig.Log

protected override string 

jquery-tags-input .怎么用的。


Article 
	文章
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


ServiceContext 缓存在
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
		//暂时使用引用服务方式，可以改造成注入，或者使用WCF服务方式
		public static ServcieFactory serviceFactory=new RefServiceFactory();
		public static T CreateService<T>() where T:class{
			var service=serviceFactory.CreateService<T>();
			var generator=new ProxyGeneratro();
			var dynamicGenerator=generator.CreateInterfaceProxyWithTargetInterface<T>()service,new InvokeInterceptor();
			return dynamicProxy;
		}
	}

对 IQueryable的数据，进行了扩展，扩展ToPagedList .返回的就是封装过Page分页的数据。

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
	///构造函数，注入数据链接
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
EntityFramework . ADO.NET  是一套 ORM框架。
ORM object relationship Mapping 
object relation mapping .
Hibernet ,IBatis ,mybatis . java orm .
ef linq .


CodeFirst .首先创建 POCO 模型。数据层 DbContext ,DbContext ,Mapping .Database.Initlaizer

IQueryable IEnumerable 

IEnumerable 公开枚举器，支持在指定类型集合上简单迭代。 
IQueryable . 继承 IEnumerbale 接口， .net 加入 Linq 和 IQueryable后，


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


//反射调用方法用的，还不是很多，看看别人是怎么用反射调用方法，进行方法的执行的。
自己写的框架，支持lambda 表达式吗。
自己写的内容，支持委托吗，


思维导图；
	CPA .全部知识点。
		
财务报表 项目

企业中，经济上的事务，做具体的讲解

金融资产，存货，长期股权投资，固定资产，无形资产。

ERP . 买东西。

库存盘点的内容，可以做哦。

1.库存。
2.进库单
3.出库单