�����µ������ˡ�����֦��


������β���������ݡ�

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
-1 ���������ݵĽ�����־��-1 ������

��һ����� ����ʱ������Ϊ�ա�û��ֱ��ǰ�� ����ַ����������� ��ͷ�����С�
��������㣬��ֱ��ǰ����㣬��ַ��ֱ��ǰ������������ �У�
��ͷ�������㣬ͷ���ã���ָ��Ľ�㣬�Ǳ仯�ġ�

Ϊ�˷��㣬
	ͷ���ñ���ģ�����ַ���ֲ��䡣
	������ͷ��������һ���ս�㡣Head Node .
	��ͷ���ĵ�ַ��������ͷ�����С�
	��ʹ�ǿձ�ͷ���ã�����Ҳ��λ�ա�
	ͷ�ڵ㣬��һ���������⣬�����ڡ��ձ� �ͷǿձ�� ����һֱ��
������ǰ���
������һ���ս�㣬��Ϊͷ��㣬ȥ������һ�����������ᡣ

������ͷ������
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

//����һ��������
��һ���ս�㡣��� �������� �����ֵ ��
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
//�ڵ������β���������㣬����
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

//������ǰ���뽨������
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
//����������뽨������

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

������Ľ�㣬����
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
	//ǰ����
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
	//�����
	//������������벻�����һ�������������һ����
	//�������һ����
	j=i;p.Next!=null;
	q.Next=p;
	//�����һ��
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
	//ɾ�����
	public T Delete(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Position Error!")��
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

//������ ��Ӧ�þ��� ��

��֪ ������ H ,дһ���㷨������ ��
�������� ���� ��

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
p!=null����p.Next1=null����ִ����һ�Ρ�

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
//�㷨˼·
���� ������ �Ĵ洢�ռ䣬���������ġ����� ���ܴ�i �� i-1 ������
����취��һ��ȡ�� ������Ľ�㣬�ŵ���������ȥ������Ϊ�˽�ʡ�ڴ���Դ����ԭ�������ͷ��㣬��Ϊ�������ͷ��㡣

���㷨Ҫ������Ľ��˳��ɨ��һ����ɵ��á�
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
