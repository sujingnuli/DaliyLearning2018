1.����Ƶ������Щselect ����ô����
2.�б���Ϣ�����д�ģ�table���д��
3.ǰ̨���д��
4.ȥ��html��ǩ������

public class ArticleRequest:Request
{
	public int ChannelId{get;set;}
	public string Title{get;set;}
	public bool? IsActive{get;set;}
}
public class ChannelRequest:Request
{
	public string Name{get;set;}
	public bool? IsActive{get;set;}
}
//�����б�
//Ƶ���б�װ��select 
//�����б���װtable 
public class Request
{
	public Request(){
		PageSize=5000;
	}
	public int PageSize{get;set;}
	public int PageIndex{get;set;}
	public int Top{
		set{
			PageIndex=1;
			PageSize=value;
		}
	}
}
public ActionResult Index(ArticleRequest request){
	var channels=this.CmsService.GetChannelList(new ChannelRequest(){IsActive=true});
	this.ViewBag.channelId=new SelectList(channels,"ID","Name");
	var articles=this.CmsService.GetArticleList(request);
	return View(articles);
}
public interface ICmsService
{
	IEnuemrable<Article> GetArticleList(ArticleRequest request);
	IEnumerable<Channel> GetChannelList(ChannelRequest request);
}
public class ChannelRequest:Request
{
	public string Name{get;set;}
	public bool? IsActive{get;set;}
}

public class CmsService:ICmsService
{
	public IEnumerable<Article> GetArticleList(ArticleRequest request=null){
		request=request??new ArticleRequest();
		using(var dbContext=new CmsDbContext()){
			IQueryable<Article> articles=dbContext.Articles;
			if(!string.IsNullOrEmpty(request.Title)){
				articles=articles.Where(a=>a.Title.Contains(request.Title));
			}
			if(request.ChannelId>0){
				articles=articles.Where(a=>a.ChannelId==request.ChannelId);
			}
			if(request.IsActive!=null){
				articles=articles.Where(a=>a.IsActive=request.IsActive);
			}
			return articles.OrderByDescending(a=>a.ID).ToPagedList(request.pageIndex,request.PageSize);
		}
	}
	
	public IEnumerable<Channel> GetChannelList(ChannelRequest request){
		request=request??new ChannelRequest();
		using(var dbContext=new CmsDbContext()){
			IQueryable<Channel> channels=dbContext.Channels;
			if(!string.IsNullOrEmpty(request.Name)){
				channels=channles.Where(c=>c.Name.Contains(request.Name));
			}
			if(request.IsActive!=null){
				channels=channles.Where(c=>c.IsActive==request.IsActive);
			}
			return channels.OrderByDescending(c=>c.ID).ToPagedList();
		}
	}
}

public class Channel
{
	public string Name{get;set;}
	public bool? IsActive{get;set;}
}
[Serializable]
[Table("Article")]
public class Article:ModelBase
{
	public string Title{get;set;}
	public string Content{get;set;}
	public bool? IsActive{get;set;}
	public int ChannelId{get;set;}
	public Channel Channel{get;set;}
}