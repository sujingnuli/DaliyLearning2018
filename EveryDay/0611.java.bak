1.IRepspository .


它的ModelBase 是怎么写的。

IRespository 是怎么写的，怎么用的

public class ModelBase
{
	public ModelBase(){
		CreateTime=DateTime.Now;
	}
	public int ID{get;set;}
	public DateTime CreateTime{get;set;}
}
public interface IDataRepository
{
	T Update<T>(T entity) where T:class;
	T Insert<T>(T entity) where T:class;
	void Delete<T>(T entity)where T:class;
	T Find<T>(params object[] keyValues)where T:ModelBase;
	List<T> FindAll<T>(Expression<Func<T,bool>> conditions=null)whereT:ModelBase;
	PagedList<T> FindAllByPage<T,S>(Expression<Func<T,bool>> conditions,Expression<Func<T,S>> orderBy,int pageSize,int pageIndex) where T:ModelBase;
}

public interface IRepository
{
	T Insert<T>(T entity) where T:ModelBase;
	T Update<T>(T entity) where T:ModelBase;
	void Delete<T>()
}

我的Request写错了

public class Request:ModelBase
{
	public Request(){
		PageSize=5000;
	}
	public int Top{
		set{
			this.PageSize=value;
			this.PageIndex=1;
		}
	}
	public int PageSize{get;set;}
	public int PageIndex{get;set;}
}

public class IRepository
{

}

邗建的下载，还是有问题，下载后，第二遍下载，少数据。
public interface IPagedList
{

}
邗建的导出，支持查询的内容全部导出。

public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
	int TotalItemCount{get;set:}
}

public class PagedList<T>:List<T>,IPagedList
{
	public PagedList(IList<T> items,int pageIndex,int pageSize){
		this.TotalItemCount=items.Count;
		this.CurrentPageIndex=pageIndex;
		this.PageSize=pageSize;
		for(int i=startRecordIndex-1;i<EndRecordIndex;i++){
			Add(items[i]);
		}
	}
	public PagedList(IList<T> items,int pageIndex,int pageSize,int totalItemCount){
		this.TotalItemCount=totalItemCount;
		this.CurrentPageIndex=currentPageIndex;
		this.pageSize=pageSize;
		AddRange(items);
	}
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return (int)Math.Ceiling(TotalItemCount/(double)PageSize);}}
	public int StartRecordIndex{get{return (PageIndex-1)*PageSize+1;}}
	public int EndRecordIndex{get{return TotalItemCount>CurrentPageIndex*PageSize?CurrentPageIndex*PageSize:TotalItemCount;}}
}

public interface IRepository
{
	T Insert<T>(T entity) where T:ModelBase;
	T Update<T>(T entity) where T:ModelBase;
	void Delete<T>(T entity) where T:ModelBase;
	T Find<T>(params object[] keyValues) where T:ModelBase;
	List<T> FindAll<T>(Expression<Func<T,bool>> conditions=null)where T:ModelBase;
	PagedList<T> FindAllByPage(Expression<Func<T,bool>> conditions=null,Expression<Func<T,S>> orderBy,int pageIndex,int pageSize) where T:ModelBase;
}

GMS 写一遍。
