//分页Bean 和 逻辑

public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
	int TotalItemCount{get;set;}
}
public class PagedList<T>:List<T>,IPagedList
{
	public PagedList(IList<T> items,int pageIndex,int pageSize){
		PageSize=pageSize;
		TotalItemCount=items.Count;
		CurrentPageIndex=pageIndex;
		for(int i=StartRecordIndex-1;i<EndRecordIndex;i++){
			Add(items[i]);
		}
	}
	public PagedList(IEnumerable<T> items,int pageIndex,int pageSize,int totalItemCount){
		CurrentPaageIndex=pageIndex;
		PageSize=pageSize;
		TotalItemCount=totalItemCount;
		AddRange(items);
	}
	public int ExtraCount{get;set;}
	public int CurrentPageIndex{get;st;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return (int)Math.Ceiling(TotalItemCount/(double)PageSize)}} //ceiling .最高限度
	public int StartPageIndex{get{ return (CurrentPageIndex-1)*PageSize+1;}}
	public int EndPageIndex{get{return TotalItemCount>CurrentPageIndex*PageSize?CurrentPageIndex*PageSize:TotalItemCount;}}
}

public static class PageLinqExtensions{
	public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems,int pageIndex,int pageSize){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(pageIndex-1)*pageSize;
		var pageOfItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemsCount=allItems.Count();
		return new PagedList<T>(pageOfItems,pageIndex,pageSize,totalItemCount);
	}	
}
//定义了一个数据结构，PagedList<T>. 用于存储分页数据。 与业务逻辑无关。取数据，并对数据分页。
//如果有业务处理，在Sql和Sql取出来之后，进行处理。

public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
	int TotalItemCount{get;set;}
}
//实现分页的类，一定有3个数据，CurrentPageIndex,PageSize,TotalItemCount;
public class PagedList<T>:list<T>,IPagedList
{
	public PagedList(IList<T> allItems,int pageIndex,int pageSize){
		CurrentPageIndex=pageIndex;
		PageSize=pageSize;
		TotalItemCount=allItems.Count;
		for(int i=StartRecordIndex-1;i<EndRecordIndex;i++){
			Add(allItems[i]);
		}
	}
	public PagedList(IQueryable<T> items,int pageIndex,int pageSize,int totalItemCount){
		PageSize=pageSize;
		CurrentPageIndex=pageIndex;
		TotalItemCount=totalItemCount;
		AddRange(items);
	}
	public int ExtraCount{get;set;}
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return (int)Math.Ceiling(TotalItemCount/(double)PageSize;) }}
	public int StartRecordIndex{get{return (CurrentPageIndex-1)*PageSize+1;}}
	public int EndRecordIndex{get{return TotalItemCount>CurrentPageIndex*PageSize?CurrentPageIndex*PageSize:TotalItemCount;}}
}

public static class PageLinqExtension
{
	public static PagedList<T>(this IQueryable<T> allItems,int pageIndex,int pageSize){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(pageIndex-1)*pageSize;
		var pageOfItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemCount=allItems.Count();
		return new PagedList<T>(pageOfItems,pageIndex,pageSize,totalItemCount);
	}
} 

public class PageLinqExtensions
{
	public static PagedList<T> ToPagelist(IQueryable<T> allItems,int pageIndex,int pageSize){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(pageIndex-1)*pageSize;
		var pageOfItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemCount=allItems.Count();
		return new PagedList<T>(pageOfItems,pageIndex,pageSize,totalItemCount);
	}
}

//获取 到了一个 分页过的结构体。然后呢
public interface IAccountService
{
	List<User> GetUserList(UserRequest request);
}
public class AccountService:IAccountService
{
	public List<User> GetUserList(UserRequest request){
		request=request??new UserRequest();
		using(var dbContext=new AccountDbContext()){
			IQueryable users=dbContext.Users.Include("Roles");
			//DbSet<T>,IQueryable<T>,IEnumeable<T>
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(u=>u.ID).ToPagedList(request.pageInde,request.PageSize);
		}
	}
}

public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int TotalItemCount{get;set;}
	int PageSize{get;set;}
}
public class PagedList<T>:List<T>,IPagedList
{
	public PagedList(IEnumerable<T> allItems,int pageIndex,int pageSize){
		To'ta'l
	}
	public PagedList(IQueryable<T> allItems,int pageIndex,int pageSize,int totalItemCount){
		CurrentPageIndex=pageIndex;
		PageSize=pageSize;
		TotalItemCount=totalItemCount;
		Add(allItems);
	}
	public int ExtraCount{get;set;}
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return (int)Math.Ceiling(TotalItemCount/(double)pageSize);}}
	public int StartRecordIndex{get{return (CurrentPageIndex-1)*PageSize+1;}}
	public int EndRecordIndex{get{return TotalItemCount>CurrentPageIndex*PageSize?CurrentPageIndex*PageSize:TotalItemCount;}}

}

public static class PageLinqExtensions
{
	public static PagedList<T> ToPageList(this IQueryable<T> items,int pageIndex,int pageSize){
		if(pageIndex<1){
			pageIndex=1;
		}
		var startIndex=(pageIndex-1)*pageSize;
		var pageOfItems=items.Skip(startIndex).Take(pageSize).ToList();
		var totalItemCount=items.Count;
		return new PagedList<T>(pageOfItems,pageIndex,pageSize,totalItemCount);
	}
}

public interface IListDS<T>
{
	public void Clear();
	public bool isEmpty();
	public void Delete(T item);

	public int GetLength();
	public T GetItem(int i);
	public int Location(T item);

	public void Append(T item);
	public void Insert(T item,int i);

}
//顺序表
//线性表，元素，在内存中，地址连续的 空间 中存放。
//随机存取
//读取每个元素的时间 都是一样的。
public class SeqList<T>:IListDS<T>
{
	public T[] data;
	public int maxSize;
	public int last;//真实长度的位置
	public SeqList(int maxSize){
		this.maxSize=maxSize;
		data=new T[size];
		last=-1;
	}
	//容量
	public int MaxSize{
		get{return this.maxSize;}
		set{this.maxSize=value;}
	}
	//索引器
	public T this[int index]{
		get{
			return data[index];
		}
		set{
			data[index]=value;
		}
	}
	public int Last{
		get{
			return last;
		}
	}
	
	public int GetLength(){
		return last+1;
	}

	public void Clear(){
		last=-1;
		data=null;
	}
	public bool isEmpty(){
		if(last==-1){
			return true;
		}else
			return false;
	}
	

	public bool isFull(){
		if(last+1>maxSize)
				return true;
		else
			return false;
	}

	public void Append(T item){
		if(isFull()){
			Console.WriteLine("is Full");
			return ;
		}
		data[++last]=item;
	}
	public void Insert(T item,int i){
		if(isFull()){
			Console.WirteLine("is Full");
			return;
		}
		if(i<1||i>last+2){
			Console.WriteLine("Position Error");
			return;
		}
		if(i==last+2){
			data[last+1]=item;
		}else{
			for(int j=last;j>=i-1;j--){
				data[j-1]=item;
			}	
			data[i-1]=item;
		}
		++last;
	}
	public T Delete(int i){
		T tmp=default(T);
		if(isEmpty()){
			Cpmsp;e/WriteLine("Empty");
			return tmp;
		}
		if(i<1||i>last+1){
			Console.WriteLine("Position Error");
			return tmp;
		}
		if(i==last+1){
			tmp=data[last--];
		}else{
			tmp=data[i-1];
			for(int j=i;j<=last;j++){
				data[i]=data[j];
			}
		}
		--last;
		return temp;
	}
	
	public T GetItem(int i){
		if(isEmpty()||i<1||i>last+1)){
			Console.WriteLine("Error");
			return;
		}
		return data[i-1];
	}
	
	public int Locate(T item){
		if(isEmpty()){
			Console.WriteLine("isEmpty");
			return -1;
		}
		int i=0;
		for(int i=0;i<=last;i++){
			if(item.Equals(data[i])){
				break;
			}
		}
		if(i>last){
			return -1;
		}
		return i;
	}
}
//顺序表的基本操作和实现。
public class SeqList<T>:IListDS<T>
{
	public int maxSize;
	public T[] data;
	public int last;

	
	public SeqList(int maxSize){
		maxSize=maxSize;
		data=new T[maxSize];
		last=-1;
	}
	public int MaxSize{
		get{return this.maxSize;}
		set{this.maxSize=value;}
	}
	public int GetLength(){
		return last+1;
	}
	public void Clear(){
		last=-1;
	}
	public bool isEmpty(){
		if(last==-1){
			return true;
		}else
			return false;
	}
	public bool isFull(){
		if(maxSize==last+1){
			return true;
		}else
			return false;
	}
	public void Append(T item){
		if(isFull()){
			Console.WriteLine("isFull");
			return;
		}
		data[++last]=item;
	}
	public void Insert(T item,int i){
		if(isFull()){
			Console.WriteLine("isFull");
			return;
		}
		if(i<1||i>last+2){
			Console.WriteLine("Error Position");
			return;
		}
		if(i==last+2){
			data[++last]=item;
		}else{
			for(int j=last;j>i;j--){
				data[j+1]=data[j];
			}
			data[i]=item;
		}
		++last;
	}
	//算法时间，复杂度分析。 顺序表的 ，掺入。有一个循环 
	//时间，消耗在，数据的移动上。
	// 在 第 i 个 位置，插入元素，  需要移动  n-i+1 个元素。
	// i  的取值 范围 1，n +1，i=1 时，需要移动的，最多。为 n 个。
	//i=n+1,时，不需要移动。
	//设 第 i 个位置 ，做插入的频率 Pi 平均移动元素次数 n/2 .
	//在 顺序表 上做插入，平均需要移动 一半的元素，插入 操作 时间复杂度 O(n).
	public void Delete(int i){
		T temp=default(T);
		if(isEmpty()||i<1||i>last+1){
			Console.WriteLine("Position Error");
			return;
		}
		if(i==last+1){
			temp=data[last--];
			return temp;
		}else{
			temp=data[i-1];
			for(int j=i;j<=last;++j){
				data[j]=data[j+1];
			}
			--last;
			return temp;
		}
	}

	//时间复杂度： 顺序表 的 删除 和 插入 操作一样。时间 主要消耗在 数据的移动上。
	//第 i 个位置，删除一个元素。
	//Ai+1,Ai都要向前移动一个元素。n-i个。
	//当i=1 ,n-1;
	//当i=n，不需要移动元素。 (0+n-1)/2=(n-1)/2; O(n); 顺序表上，做删除，平均移动一半的元素。
	public T GetItem(int i){
		if(isEmpty()||i<1||i>last+1){
			Console.WriteLine("is Empty");
			return;
		}
		return data[i-1];
	}
	//时间复杂度：O(1); 
	//按值查找。
	public int Location(T item){
		if(isEmpty()){
			Console.WriteLine("is Empty");
			return -1;
		}
		for(int i=0;i<=last;i++){
			if(item.Equals(data[i])){
				break;
			}
		}
		if(i>last){
			return -1;
		}
		return i;
	}
	//时间复杂度： 
	// 1<i<n-1.
	//如果i=1,1,如果i=n ,n
	//平均次数：(1+n)/2 O(n);
	//由于 顺序表 用连续的 空间 存储元素，所以，按值查找方法有很多。如果顺序表是有序的，则按照折半查找方法。效率可以提高很多。

}
//顺序表的  应用举例 。

已知 顺序表 L ,写一个算法将其 倒置， 即实现如图 2.4 的操作。
（a） 为前倒置，
（b）为后倒置
将(a)倒置 为（b）
public void Test(object[] items){
	int len=items.length;
	object[] b=new object[len];
	for(int i=0;i<items.length;i++){
		b[len-i-1]=items[i];
	}
	return b;
}
//算法思路，把第一个与 最后一个交换。
public void ReversSeqList(SeqList<int> L){
	int temp=0;
	int len=L.GetLength();
	for(int i=0;i<=len/2;++i){
		temp=L[i];
		L[i]=L[len-i];
		L[len-i]=temp;
	}
	return L;
}