//ʮ�ֲ��뿴��������Ϊ�Ҳ��ᣬ���죬����߯����

������
	-��������
	-�������� ��ֻ���� ֱ�Ӽ̳н��� ���õ�ַ����Ϊ������

��㣬�����ʾ
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
//������
 ͨ�������ǰѵ����� ����  ��ͷ ���� �� ��� �����С���� ��� ��ͷ ��ʾ ������ �� �ĵ�ַ�洢��
������ �� H Ψһȷ����ͷ���ã�ָ���һ����㣬
H ��һ��Node���͵ı��������H=null,�ǿ�����
H ��һ��Node<T> ���͵ı��������H=null,��ʾ������
������H Ψһȷ����
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
�� ������ ���� һ���࣬���� �� LinkedList<T>.LinkedList<T> ʵ���˽ӿ� IListDS<T>.
LinkedList 
head ��ʾͷ���á�head������ΪNode<T>.
�����Ƿ�������û�����ռ����ƣ�

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
	//û�����ã�c#���������������Զ����ա�
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
	//��i λ�ý������ 
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
	//ɾ��������� �� i ����� 
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

ʱ�临�Ӷȷ�����

������ĸ��Ӳ���

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
��Ҫ���������һ����㣬O(n);
���������
ǰ���룬�ͺ���롣

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

//ɾ������
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
//ɾ���� ʱ�临�Ӷ� �� ������O(n).
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
//��ֵ����
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
��һ���󶨲�����I/Item �ǰ󶨵����ݡ�

������Ľ�����
	������ �Ľ��� ���� ˳���� ���� ��ͬ��������һ�ֶ�̬����Ĵ洢�ṹ��

������
	��ͷ�������㣬����������
	��β�������㣬����������

����������ͷ�������㣬����������
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

-1 ���������ݽ�����־��
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
//�������β���� �����㣬����������
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

1.search ͼ���һ�¡�
2.������ģ�飬��д�ˡ�

1.���������Ĳ�ѯ��������

÷��