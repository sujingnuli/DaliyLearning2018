public Article GetArticle(int id){
	using(var dbContext=new CmsDbContext()){
		return dbContext.Articles.Include("Tag").FirstOrDefault(a=>a.Id=id);
	}
}
public class CmsDbContext:DbContextBase
{
	public CmsDbContext():base(CachedConfigContext.Current.DaoConfig.Cms,new LogDbContext()){
	
	}
	protected override void OnModelCreating(DbModelBuilder modelBuilder){
		this.Database.SetInitialzer<CmsDbContext>(null);
		modelBuilder.Entity<Article>()
			.HasMany(a=>a.Tags)
			.WithMany(t=>t.Articles)
			.Map(m=>{
				m.ToTable("ArticleTag");
				m.MapLeftKey("ArticleId");
				m.MapRightKey("TagId");
			});
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Article> Articles{get;set;}
	public DbSet<Channel> Channels{get;set;}
	public DbSet<Tag> Tags{get;set;}
}

public class TagRequest:Request
{
	public OrderBy OrderBy{get;set;}
}

public enum OrderBy
{

}

public interface ICmsService
{
	Article GetArticle(int id);
	IEnumerble<Tag> GetTagList(TagRequest request=null);
}
public class CmsService:ICmsService
{
	public Article GetArticle(int id){
		using(var dbContext=new CmsDbContext()){
			return dbContext.Articles.Include("Tags").FirstOrDefault(a=>a.Id==id);
		}
	}
	public IEnumerable<Tag> GetTagList(TagRequest request=null){
		
	}
}

	public ActionResult Edit(int id){
		var article=this.CmsService.GetArticle(id);
		var channelList=this.CmsService.GetChannelList(new ChannelRequest(){IsActive=true});
		this.ViewBag.ChannelId=new SelectList(channelList,"Id","Name");
		this.ViewBag.Tags=this.CmsService.GetTagList(new TagRequest(){Top=20,OrderBy=OrderBy.Hits});
		return View(model);
	}