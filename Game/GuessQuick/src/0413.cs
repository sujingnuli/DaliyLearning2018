我有新的名字了。丁香枝。


单链表，尾部插入数据。

public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=int.Parse(Console.ReadLine());
	Node<int> R=new Node<int>();
	R=L.head;

	while(d!=-1){
		Node<int> p=new Node<int>(d);
		if(L.Head==null){
			L.Head=p;
		}else{
			p.Next=head;
		}
		R=p;
		d=Int32.Parse(Console.ReadLine());
	}
	if(R!=null){
		R.Next=null;
	}
	return L;
}
-1 是输入数据的结束标志，-1 结束。

第一个结点 加入时，链表为空。没有直接前驱 。地址，存放在链表 的头引用中。
而其他结点，有直接前驱结点，地址，直接前驱结点的引用域 中，
在头部插入结点，头引用，所指向的结点，是变化的。

为了方便，
	头引用保存的，结点地址保持不变。
	在链表头部，加入一个空结点。Head Node .
	把头结点的地址，保存在头引用中。
	即使是空表，头引用，变量也部位空。
	头节点，第一个结点的问题，不存在。空表 和非空表的 处理一直。
单链表。前结点
加入了一个空结点，作为头结点，去除掉第一个结点的我呢提。

在链表头部插入
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	Node<int> R=new Node<int>();
	R=L.head;
	int d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		if(L.head==null){
			L.head=p;
		}else{
			R.Next=p;
		}
		R=p;
		d=Int32.Parse(Console.ReadLine());
	}
	if(R!=null){
		R.Next=null;
	}
	return L;
}

//建立一个空链表，
第一个空结点。结点 的引用域 存放新值 。
Node<int> p=new Node<int>();
if(L==null){
	L.head=p;
}else{
	R.Next=p;
}
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		p.Next=L.head;
		L.head=p;
		d=Int32.Parse(Console.ReadLine());
	}
	return L;

}
//在单链表的尾部，插入结点，建立
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	Node<int> R=new Node<int>();
	R=L.head;
	d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		if(L.Head==null){
			L.head=p;
		}else{
			R.Next=p;
		}
		R=p;
		d=Int32.Parse(Console.ReadLine());
	}
	if(R!=null){
		R.Next=null;
	}
	return L;

}

//单链表，前插入建立链表
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		p.Next=L.head;
		L.head=p;
	}
	return L;
}
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	Node<int> R=L.Head;
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		if(L.Head==null){
			L.head=p;
		}else{
			R.Next=p;
		}
		R=p;
		d=Int32.Parse(Console.ReadLine());
	}
	if(R!=null){
		R.Next=null;
	}
	return L;
}
//单链表，后插入建立链表

public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	Node<T> R=L.head;
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		if(L.head==null){
			L.head=p;
		}else{
			R.Next=p;
		}
		R=p;
		d=Int32.Parse(Console.ReadLine());
	}
	if(R!=null){
		R.Next=null;
	}
	return L;
}
//
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		p.Next=L.head;
		L.head=p;
	}
	return L;
}

单链表的结点，和类
public class Node<T>
{
	private T data;
	private Node<T> next;
	public Node(T val,Node<T> p){
		this.data=val;
		this.next=p;
	}
	public Node(T val){
		this.data=val;
		this.next=null;
	}
	public Node(Node<T> p){
		this.next=p;
	}
	public Node(){
		this.data=default(T);
		this.next=null;
	}
	public T Data{
		get{
			return data;
		}
		set{
			data=value;
		}
	}
	public Node<T> Next{
		get{
			return this.next;
		}
		set{
			this.next=value;
		}
	}
}

public class LinkedList<T>:IListDS<T>
{
	private Node<T> head;
	public Node<T> Head{
		get{
			return this.head;
		}
		set{
			this.head=value;
		}
	}
	public LinkedList(){
		head=null;
	}
	public int GetLength(){
		int j=0;
		Node<T> p=head;
		while(p!=null){
			p=p.Next;
			j++;
		}
		return j;
	}
	public void Clear(){
		this.head=null;
	}
	public void isEmpty(){
		if(head==null){
			return true;
		}else{
			return false;
		}
	}
	public void Append(T item){
		Node<T> q=new Node<T>(item);
		Node<T> p=head;
		if(isEmpty()){
			head=q;
		}else{
			while(p.Next!=null){
				p=p.Next;
			}
			p.Next=q;
		}

	}
	public T GetItem(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return default(T);
		}
		Node<T> p=head;
		int j-1;
		while(p.Next!=null&&j<i){
			p=p.Next;
			++j;
		}
		if(j==i){
			return p.Data;
		}else{
			Console.WriteLine("Node not Exists");
			return default(T);
		}
	}
	public int Location(T item){
		if(isEmpty()){
			Console.WriteLine("Empty");
			return -1;
		}
		Node<T> p=head;
		int j=1;
		while(p.Next!=null&&!p.Data.Equals(item)){
			p=p.Next;
			++j;
		}
		if(j==GetLength()&&!p.Data.Equals(item)){
			return -1;
		}else{
			return j;		
		}
	}
	//前插入
	public void Insert(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error position");
			return ;
		}
		Node<T> p=head;
		Node<T> r=new Node<T>();
		int j=1;
		while(p.Next!=null&&j<i){
			r=p;
			p=p.Next;
			++j;
		}
		if(j==i){
			Node<T> q=new Node<T>(item);
			q.Next=p;
			r.Next=q;
		}
	}
	//后插入
	//两种情况。插入不是最后一个，插入是最后一个。
	//不是最后一个。
	j=i;p.Next!=null;
	q.Next=p;
	//是最后一个
	j=i,p.Next==null;
	q.Next=p.Next;
	p.Next=q;
	public void Insert(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error position");
			return ;
		}
		Node<T> p=head;
		int j=1;
		while(p.Next!=null&&j<i){
			p=p.Next;
			++j;
		}
		if(j==i){
			Node<T> q=new Node<T>(item);
			q.Next=p.Next;
			p.Next=q;
		}
	}
	//删除结点
	public T Delete(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Position Error!")；
			return default(T);
		}
		Node<T> p=head;
		Node<T> r=new Node<T>();
		int j=1;
		while(p.Next!=null&&j<i){
			++j;
			r=p;
			p=p.Next;
		}
		if(j==i){
			
			r.Next=p.Next;
			return p.Data;
		}else{
			Console.WriteLine("Wrong Position");
			return default(T);
		}
	}

	
}
//
public LinkedList<int> CreatelinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> d=new Node<int>(d);
		d.Next=L.head;
		L.head=d;
	}
	return L;
}
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	Node<int> R=L.head;
	whlile(d!=-1){
		Node<int> q=new Node<int>(d);
		if(L.head==null){
			L.head=q;
		}else{
			R.Next=q;
		}
		R=q;
		d=Int32.Parse(Console.ReadLine());
	}
	if(R!=null){
		R.Next=null;
	}
	return L;
}

//单链表 的应用举例 。

已知 单链表 H ,写一个算法，倒置 ，
将单链表 倒置 。

public LinkedList<int> ReverseLinkedList(LinkedList<int> L){
	if(L.GetLength()<=1){
		return L;
	}
	LinkedList<int> S=new LinkedList<int>();
	Node<int> p=L.head;
	S.Head=L.head;
	while(p!=null){
		Node<T> q=p.Next;
		q.Next=S.Head;
		S.head=q;
		p=p.Next;
	}

	return S;
}
p!=null，比p.Next1=null，多执行了一次。

public void ReversLinkedList(LinkedList<int> H){
	Node<int> p=H.Head.Next;
	Node<int> q=new Node<int>();

	while(p!=null){
		q=p;
		p=p.Next;
		q.Next=H.head.Next;
		H.Head.Next=q;

	}
}
//算法思路
由于 单链表 的存储空间，不是连续的。倒置 不能从i 到 i-1 交换。
解决办法，一次取出 单链表的结点，放到新链表中去。并且为了节省内存资源。把原来链表的头结点，作为新链表的头结点。

该算法要对链表的结点顺序扫描一遍完成倒置。
O(n)
O(n/2)

public class LinkedList<T>:IListDS<T>
{
	public void Reverse(){
		Node<int> p=head.Next;

	}
}
//ToPagedList  
public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
	int TotalItemCount{get;set;}
}
public class PagedList<T>:List<T>,IPageList
{
	public PagedList(IList<T> allItems,int PageSize,int PageIndex){
		this.CurrentPageIndex=pageIndex;
		this.PageSize=pageSize;
		this.TotalItemCount=allItems.Count;
		for(int i=StartRecordSize;i<EndRecordSize;i++){
			Add(allItems[i]);
		}
	}
	public PagedList(IQueryable<T> items,int PageIndex,int PageSize,int totalItemCount){
		this.TotalItemCount=totalItemCount;
		this.CurrentPageIndex=pageIndex;
		this.PageSize=pageSize;
		AddRange(items);
	}
	public int ExtraCount{get;set;}
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return Math.Ceil(TotalItemCount/(double)PageSize;)}}
	public int StartRecordIndex{get{return PageSize*(CurrentPageIndex-1)+1;}}
	public int EndRecordIndex{get{return TotalItemCount>CurrentPageIndex*PageSize?CurrentPageIndex*PageSize:TotalItemCount;}}

}

public static class PageLinqExtensions
{
	public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems,int pageIndex,int pageSize){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(Page)
	}
}
