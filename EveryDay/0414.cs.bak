我的新名字-巴山夜雨

1.GMS
2.C#数据结构
3.游戏开发
4.英语
5.创业

1.3月份的记录，看看没有做的，做完。
//1，数据结构，我快看疯了。

其他链表

双向链表
循环列表
c#中的线性表
//单链表结点
public class Node<T>
{
	public T data;
	public Node<T> next;
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
//双链表类
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
	public int GetLength(){
		int j=0;
		while(p!=null){
			p=p.Next;
			++j；
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
		if(isEmpty()){
			head=q;
		}else{
			Node<T> p=head;
			while(p.Next!=null){
				p=p.Next;
			}
			p.Next=q;
		}
	}
	public T GetItem(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("isEmpty Or Error Position");
			return default(T) ;
		}
		int j=1;
		Node<T> p=head;
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
			return -1 ;
		}
		int j=i;
		Node<T> p=head;
		while(p.Next!=null&&!p.Data.Equals(item)){
			p=p.Next;
			++j;
		}
		return j;
	}

	public T Delete(int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Error Position");
			return default(T);
		}
		int j=1;
		Node<T> p=head;
		Node<T> r=new Node<T>();
		while(p.Next!=null&&j<i){
			r=p;
			p=p.Next;
			++j;
		}
		if(j==i){
			r.Next=p.Next;
			return p.Data;
		}else{
			Console.WriteLine("Node not Exists");
			return default(T);
		}
	}
	//前插入
	public void Insert(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Wrong Position");
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
	public void Insert(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty Or Wrong Position");
			return ;
		}
		Node<T> p=head;
		int j=1;
		while(p.Next!=null&&j<i){
			p=p.Next;
			++j;
		}
		if(j==i){
			Node<T> q=new Node<T>();
			q.Next=p.Next;
			p.Next=q;
		}
	}
}
//创建链表
//前插入创建链表
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	while(d!=-1){
		Node<int> q=new Node<int>(d);
		q.Next=L.head;
		L.head=q;
		d=Int32.Parse(Console.ReadLine());
	}
	return L;
}
//后插入
public LinkedList<int> CreateLinkedList(){
	LinkedList<int> L=new LinkedList<int>();
	int d=Int32.Parse(Console.ReadLine());
	Node<int> R=L.head;
	while(d!=-1){
		Node<int> q=new Node<int>(d);
		if(L.head==null){
			L.head=q;
		}else{
			R.Next=q;
		}
		R=q;
		D=Int32.Parse(Console.ReadLine());
	}
	return L;

}
//单链表没有特别说明，都是指有头节点的单链表
//单链表中的元素，位置互换 
public void ReverseLinkedList(LinkedList<int> H){
	Node<int> p=H.Next;
	Node<int> q=new Node<int>();
	H.Next=null;
	while(p!=null){
		q=p;
		p=p.Next;

		q.Next=H.Next;
		H.Next=q;
	}
}
//使用前插入的方式。来倒置链表中的位置
public LinkedList<int> ReverseLinkedList(LinkedList<int> H){
	Node<int> p=H.Next;
	H.Next=null;
	Node<int> q=new Node<int>();
	while(p!=null){
		p=p.Next;
		q=p;
		q.Next=H.Next;
		H.Next=q;
	}
}
时间复杂度O(n).比顺序表的时间复杂度多了一半
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
	public void Reverse(){
		Node<T> p=head;
		Node<T> q=new Node<T>();
		head.Next=null;
		while(p!=null){
			q=p;
			p=p.Next;
			q.Next=head.Next;
			head.Next=q;
		
		}
	}
}
//有数据类型为 
LinkedList<int> Ha	从小到大  升序
LinkedList<int> Hb  从小到大  升序
LinkedList<int> Hc  Hc中的值，也是升序排列

public void Comb(LinkedList<int> Ha,LinkedList<int> Hb){
	Node<int> pa=Ha.Next;
	Node<int> Pb=Hb.Next;
	LinkedList<int> Hc=new LinkedList<int>();
	Node<int> q=new Node<int>();
	Node<int> pc=Hc.Head;
	while(pa=null&&pb=null){
		if(pa.Data<=pb.Data){
			q=pa;
			pa=pa.Next;
		}else{
			q=pb;
			pb=pb.Data;
		}
			pc.Next=q;
			pc=q;
	}
	if(pa==null){
		while(pb!=null){
			q=pb;
			pb=pb.Next;
			pc.Next=q;
			pc=q;
		}
	}
	if(pb==null){
		while(pa!=null){
			q=pa;
			pa=pa.Next;
			pc.Next=q;
			pc=q;
		}
	}
}

public LinkedList<int> Merge(LinkedList<int> Ha,LinkedList<int> Hb){
	LinkedList<int> Hc=new LinkedList<int>();
	Node<int> p=Ha.Next;
	Node<int> q=H.Next;
	Node<int> s=new Node<int>();
	Hc=Ha;
	Hc.Next=null;
	while(p!=null&&q!=null){
		if(p.Data<q.Data){
			s=p;
			p=p.Next;
		}else{
			s=q;
			q=q.Next;
		}
		Hc.Append(s);
	}
	if(p==null){
		p=q;
	}
	while(q!=null){
		s=q;
		q=q.Next;
		Hc.Append(s);
	}
	return Hc;
}
时间复杂度 是 O((m+n)*k)

从上面的算法，知道，把结点附件到单链表的尾部，很花时间。
因为，定位一个结点，要从头开始便利，而把结点，插入到头部，就省很多时间。
但是把单链表，附加到头部，得到的就是逆序，而不是顺序。
把结点插入到链表Hc，头部合并Ha 和 Hb的算法。
public LinkedList<int> Merge(LinkedList<int> Ha,LinkedList<int> Hb){
	LinkedList<int> Hc=new LinkedList<int>();
	Node<int> p=Ha.Next;
	Node<int> q=Hb.Next;
	Node<int> s=new Node<int>();
	Hc=Ha;
	Hc.Next=null;
	while(p!=null&&q!=null){
		if(p.Data<q.Data){
			s=p;
			p=p.Next;
		}else{
			s=q;
			q=q.Next;
		}
		s.Next=Hc.Next;
		Hc.Next=s;
	}
	if(p==null){
		p=q;
	}
	while(p!=null){
		s=p;
		p=p.Next;
		s.Next=Hc.Next;
		Hc.Next=s;
	}
	return Hc;
}
这是逆序排列，从大到小。然后再reverse .
时间复杂度O(m+n).
//带一个空结点的单链表
public void ReverseLinkedList(){
	Node<T> p=head.Next;
	Node<T> r=new Node<T>();
	head.Next=null;
	while(p!=null){
		r=p;
		p=p.Next;
		r.Next=head.Next;
		head.Next=r;
	}
}
时间复杂度O(n).
总共复杂度O(m+n+n);否则 O((m+n)*k),k是Hc的长度。
1.反转表
2.合并表，从小到大排序。

LinkedList<int> Ha .
试图构造 单链表 Hb .要求 Hb 只包含 Ha 中所有值不同的结点。
LinkedList<int> Hb .对Ha 的值去重。
public void Purge(LinkedList<int> Ha){
	LinkedList<int> Hb=new LinkedList<int>();
	Node<int> p=Ha.Next;
	Node<int> r=new Node<int>();
	bool has=false;
	while(p!=null){
		Node<int> q=Hb.Next;
		while(q!=null&&q.Data!=p.Data){
			q=q.Next;
		}
		if(q==null){
			r=p;
			p=p.Next;
			r.Next=Hb.Next;
			Hb.Next=r;
		}
	}
}

public LinkedList<int> Purge(LinkedList<int> Ha){
	LinkedList<int> Hb=new LinkedList<int>();
	Node<int> p=Ha.Next;
	Node<int> q=new Node<int>();
	Node<int> s=new Node<int>();

	while(p!=null){
		s=p;
		p=p.Next;
		q=Hb.Next;
		while(q!=null&&q.Data!=s.Data){
			q=q.Next;
		}
		if(q==null){
			s.Next=Hb.Next;
			Hb.Next=s;
		}
	}
	return Hb;
}
算法的时间复杂度O(m+n).m 是Ha的长度，n 是Hb的长度。

//我知晓你的意思了，第一个结点不用比较，从第二个结点器，开始比较。
public void Purge(LinkedList<int> Ha){
	LinkedList<int> Hb=new LinkedList<int>();
	Node<int> p=Ha.Next;
	Node<int> s=new Node<int>();
	Node<int> q=new Node<int>();
	s=p;
	p=p.Next;
	s.Next=null;
	Hb.Next=s;
	while(p!=null){
		s=p;
		p=p.Next;
		q=Hb.Next;
		while(q!=null&&q.Data!=s.Data){
			q=q.Next;
		}
		if(q==null){
			s.Next=Hb.Next;
			Hb.Next=s;
		}
	}
	return Hb;
}
//其他链表
//双向链表
//循环链表
//c#中的线性表

