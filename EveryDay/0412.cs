//十分不想看单链表，因为我不会，不熟，看着忒难受

单链表
	-》数据域
	-》引用域 （只包含 直接继承结点的 引用地址，称为单链表）

结点，用类表示
public class Node<T>
{
	public Node(T item){
		this.data=item;
		this.next=null;
	}
	public Node(Node<T> next){
		this.next=next;
	}
	public Node(T data,Node<T> next){
		this.data=data;
		this.next=next;
	}
	private T data;
	private Node<T> next;

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

public class Node<T>
{
	private T data;
	private Node<T> next;

	public Node(T val,Node<T> p){
		this.data=val;
		this.next=p;
	}
	public Node(Node<T> p){
		this.next=p;
	}
	public Node(T val){
		this.data=val;
		this.next=null;
	}
	public Node(){
		data=default(T);
		this.next=null;
	}

	public T Data{
		get{
			return this.data;
		}
		set{
			this.data=value;
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
		this.next=p;
	}
	public Node(Node<T> p){
		this.next=p;
	}
	public Node(){
		this.data=default(T);
		this.next=p;
	}
	public T Data{
		get{
			return this.data;
		}
		set{
			this.data=value;
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
//单链表
 通常，我们把单链表 画成  箭头 相连 的 结点 的序列。结点 间的 箭头 表示 引用域 中 的地址存储。
单链表 由 H 唯一确定。头引用，指向第一个结点，
H 是一个Node类型的变量，如果H=null,是空链表。
H 是一个Node<T> 类型的变量，如果H=null,表示空链表。
链表由H 唯一确定。
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
			return this.data;
		}
		set{
			this.data=value;
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
把 单链表 看成 一个类，类名 叫 LinkedList<T>.LinkedList<T> 实现了接口 IListDS<T>.
LinkedList 
head 表示头引用。head的类型为Node<T>.
链表是非连续，没有最大空间限制，

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
		this.head=null;
	}

	public void Clear(){
		this.head=null;
	}

	public bool isEmpty(){
		if(head==null){
			return true;
		}else
			return false;

	}
	//没有引用，c#的垃圾回收器会自动回收。
	public int GetLength(){
		int j=0;
		Node<T> p=head;
		while(p!=null){
			p=p.Next;
			++j;
		}
		return j;
	}

	public void Append(T item){
		Node<T> q=new Node<T>(item);
		if(head==null){
			head=q;
			return;
		}
		Node<T> p=head;
		while(p.Next!=null){
			p=p.Next;
		}
		p.Next=q;
	}
	public void Insert(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Error Position Or Empty");
			return;
		}
		if(i==1){
			Node<T> q=new Node<T>(item);
			q.Next=head.Next;
			head.Next=q;
			return;
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
	public void Insert(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return;
		}
		if(i==1){
			Node<T> q=new Node<T>(item);
			q.Next=head.Next;
			head.Next=q;
			return;
		}
		int j=1;
		Node<T> p=head;
		Node<T> r=new Node<T>();
		while(p.Next1=null&&j<i){
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
	//在i 位置结点后插入 
	public void InsertPost(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return;
		}
		if(i==1){
			Node<T> q=new Node<T>(item);
			q.Next=head.Next;
			head.Next=q;
			return;
		}
		int j=1;
		Node<T> p=head;
		while(p!=null&&j<i){
			p=p.Next;
			++j;
		}
		if(j==i){
			Node<T> q=new Node<T>(item);
			q.Next=p.Next;
			p.Next=q;
		}
	}
	//删除单链表的 第 i 个结点 
	public T Delete(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return;
		}
		Node<T> q=new Node<T>();
		if(i==1){
			q=head;
			head=head.Next;
			return q.Data;
		}
		int j=1;
		Node<T> p=head;
		while(p.Next!=null&&j<i){
			q=p;
			p=p.Next;
			++j;
		}
		if(j==i){
			q.Next=p.Next;
			return p.Data;
		}else{
			Console.WriteLine("The node not exits");
			return default(T);
		}
	}

	public T Delete(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return default(T);
		}
		Node<T> q=new Node<T>();
		if(i==1){
			
			q=head;
			head=head.Next;
			return q.Data;
		}
		int j=1;
		Node<T> p=head;
		while(p.Next!=null&&j<i){
			q=p;
			p=p.Next;
			++j;
		}
		if(j==i){
				q.Next=p.Next;
			return q.Data;
		}else{
			Console.WriteLine("Node no tExists");
			return default(T);
		}
	}
	public T GetItem(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return default(T);
		}
		if(i==1){
			return head;
		}
		int j=1;
		Node<T> p=head;
		while(p.Next=null&&j<i){
			p=p.Next;
			j++;
		}
		if(j==i){
			return p.Data;
		}else{
			Console.WriteLine("Empty Or Error Position");
			return ;
		}
	}
	public int Location(T item){
		if(isEmpty()){
			Console.WriteLine("Empty");
			return ;
		}
		int j=1;
		Node<T> p=head;
		while(p.Next!=null&&!p.Data.Equals(item)){
			++j;
			p=p.Next;
		}
		return j;

	}
}

时间复杂度分析：

单链表的附加操作

public void Append(T item){
	Node<T> p=head;
	Node<T> q=new Node<T>(item);
	if(head==null){
		head=q;
		return;
	}
	while(p.Next!=null){
		p=p.Next;
	}
	p.Next=q;
}
需要便利到最后一个结点，O(n);
插入操作。
前插入，和后插入。

public void Insert(T item,int i){
	if(isEmpty()||i<1){
		Console.WriteLine("isEmpty Or Error Position");
		return ;
	}
	Node<T> q=new Node<T>(item);
	if(i==1){
		q.Next=head.Next;
		head.Next=q;
		return;
	}
	int j=1;
	Node<T> p=head;
	Nodel<T> r=new Node<T>();
	while(p.Next!=null&&j<i){
		r=p;
		p=p.Next;
		++j;
	}
	if(j==i){
		q.Next=p;
		r.Next=q;
	}else{
		Console.WriteLine("Node not Exists");
	}
}
public void InsertPost(T item,int i){
	if(isEmpty()||i<1){
		Console.WriteLine("Empty Or Error Position");
		return;
	}
	if(i==1){
		Node<T> q=new Node<T>(item);
		q.Next=head.Next;
		head.Next=q;
		return;
	}
	int j=1;
	Node<T> p=head;
	while(p!=null&&j<i){
		++j;
		p=p.Next;
	}
	if(j==i){
		Node<T> q=new Node<T>(item);
		q.Next=p.Next;
		p.Next=q;
	}else{
		Console.WriteLine("Node not Exists");
		return;
	}
}

//删除操作
public T Delete(int i){
	if(isEmpty()||i<1){
		Console.WriteLine("Empty Or Error Position");
		return default(T);
	}
	if(i==1){
		Node<T> p=head;
		head=head.Next;
		return p.Data;
	}
	int j=1;
	Node<T> p=head;
	Node<T> r=new Node<T>();
	while(p.Next!=null&&j<i){
		r=p;
		p=p.Next;
		j++;
	}
	if(j==i){
		r.Next=p.Next;
		return p.Data;
	}else{
		Console.WriteLine("Node not Exists");
		return default(T);
	}
}
//删除的 时间复杂度 ： 结点便利O(n).
public T GetItem(int i){
	if(isEmpty()||i<1){
		Console.WriteLine("Empty Or Error Position");
		return defallt(T);
	}
	if(i==1){
		return head.Data;
	}
	int j=1;
	Node<T> p=head;
	while(p.Next!=null&&j<i){
		++j;
		p=p.Next;
	}
	if(j==i){
		return p.Data;
	}else{
		Console.WriteLine("Node not Exists");
		return default(T);
	}
}
//按值查找
public int Location(T item){
	if(isEmpty()){
		Console.WriteLine("Empty");
		return -1;
	}
	int j=1;
	Node<T> p=head;
	while(p.Next!=null&&!p.Data.Equals(item)){
		++j;
		p=p.Next;
	}
	return j;
}
是一个绑定操作，I/Item 是绑定的内容。

单链表的建立：
	单链表 的建立 ，和 顺序表的 建立 不同。。。是一种动态管理的存储结构。

单链表：
	在头部插入结点，建立单链表
	在尾部插入结点，建立单链表

单链表——在头部插入结点，建立单链表
LinkedList<int> CreateListHead(){
	int d;
	LinkedList<int> L=new LinkedList<int>();
	d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> p=new Node<int>(d);
		p.Next=L.head;
		L.head=p;
		d=Int32.Parse(Console.WriteLine());
	}
	return L;
}	

-1 是输入数据结束标志。
LinkedList<int> CreateLinkedList(){
	int d;
	LinkedList<int> L=new LinkedList();
	d=int.Parse(Console.ReadLine());
	while(d!=-1){
		Node<T> p=new Node<T>(int.Parse(d));
		d.Next=L.head;
		L.Head=d;
		d=Int32.Parse(Console.ReadLine());
	}
	return L;
}
//在链表的尾部， 插入结点，建立单链表
LinkedList<int> CreateLinkedList(){
	Node<int> r=new Node<int>();
	int d;
	LinkedList<int> L=new LinkedList<int>();

	r=L.head;
	d=int.Parse(Console.ReadLine());

	while(d!=-1){
		Node<int> p=new Node<int>(d);
		
	}
}

1.search 图标加一下。
2.把三个模块，先写了。

1.质量方案的查询做出来。

梅岭