1.pdf看一点，看一点
2.别人家的技术，看一点，看一点
3.c#的后台的技术看一点看一点，泡沫剧看一点。


public ActionResult Edit(int id){
	var model=this.CmsService.GetArticle(id);
	var channelList=this.CmsService.GetChannelList(new ChannelRequest(){IsActive=true});
	this.ViewBag.ChannelId=new SelectList(channelList,"ID","Name");
	this.ViewBag.Tags=this.CmsService.GetTagList(new TagRequest(){IsActive=true});
	return View(model);
}
public interface ICmsService
{
	Article GetArticle(int id);
	IEnumerable<Channel> GetChannelList(ChannelRequest request=null);
	IEnumerable<Tag> GetTags(TagRequest request=null);
}
public class CmsService:ICmsService
{
	public Article GetArticle(int id){
		using(var dbContext=new CmsDbContext()){
			return dbContext.Articles.Include("Tags").FirstOrDefault(t=>t.Id==id);
		}
	}
	public IEnumerable<Channel> GetChannelList(ChannelRequest request=null){
		request=request??new ChannelRequest();
		using(var dbContext=new CmsDbContext()){
			IQueryable<Channel> channels=dbContext.Channels;
			if(!string.IsNullOrEmpty(request.Name)){
				channels=channels.Where(m=>m.Name.Contains(request.Name));
			}
			if(request.IsActive!=null){
				channels=channels.Where(m=>m.IsActive==request.IsActive);
			}
			return channels.OrderBy(m=>m.Id).ToPagedList(request.PageIndex,request.PageSize);
		}
	}
	public IEnumerable<Tag> GetTagList(TagReqeust request=null){
		request=request??new TagRequest();
		using(var dbContext=new CmsDbContext()){
			var tags=dbContext.Tags;
			if(request.OrderBy!=OrderBy.Hits){
				return tags.OrderBy(t=>t.Hits).ToPagedList(request.PageIndex,request.PageSize);
			}else
				return tags.OrderBy(t=>t.Id).ToPagedList(request.PageIndex,request.PageSize);
		}
	}
}

public class CmsDbContext:DbContextBase
{
	public CmsDbContext():base(CachedConfigContext.Current.Dao.Cms,new LogDbContext()){
		
	}
	public override void OnModelCreating(DbModelBuilder modelBuilder){
		this.Database.SetInitalizer<CmsDbContext>(null);
		modelBuilder.Entity<Article>()
			.HasMany(t=>t.Tag)
			.WithMany(t=>t.Article)
			.Map(m=>{
				m.ToTable("ArticleTag");
				m.MapLeftKey("ArticleID");
				m.MapRightKey("TagID");
			});
		base.OnModelBuilder(modelBuilder);
	}
	public DbSet<Article> Articles{get;set;}
	public DbSet<Channel> Channels{get;set;}
	public DbSet<Tag> Tags{get;set;}
}

[Serializable]
[Table("Tags")]
public class Tag:ModelBase
{
	[StringLength(100)]
	public string Name{get;set;}
	public int Hits{get;set;}
	public virtual List<Article> Articles{get;set;}
}
public class ArticleRequest:Request
{
	public string Name{get;set;}
	public int ChannelId{get;set;}
	public bool? IsActive{get;set;}
}
public class ChannelRequest:Request
{
	public string Name{get;set;}
	public bool? IsActive{get;set;}
}
//Request
public class TagRequest:Request
{
	public OrderBy OrderBy{get;set;}
}
public enum OrderBy{
	ID=0,
	Hits=1
}


public class Article:ModelBase
{
	public string Title{get;set;}
	
	public int Hits{get;set;}
	public int ChannelId{get;set;}
	public virtual Channel Channel{get;set;}

	public virtual List<Tag> Tags{get;set;}

	public string TagString{
		get{
			if(Tags==null){
				return string.Empty;
			}else
				return string.Join(",",Tags.Select(m=>m.Name));
		}
		set{
			if(string.IsNullOrEmpty(value)){
				Tags=new List<Tag>();
			}else{
				Tags=value.Split(",").Select(m=>new Tag(){Title=m}).ToList();
			}	
		}
	}
}
//1.今天下午把Article的内容看完。

@Html.TextAreaFor(m=>m.Content,new{style="width:92%;height:200px"})

[Serializable]
[Table("Article")]
public class Article:ModelBase
{
	public Article(){
		
	}
	public string Title{get;set;}
	[StringLength(int.MaxValue)]
	public string Content{get;set;}
	public int Hits{get;set;}
	public int ChannelId{get;set;}
	public virtual Channel Channel{get;set;}
	public virtual List<Tag> Tags{get;set;}
	public string TagString{
		get{
			
		}
	}
}