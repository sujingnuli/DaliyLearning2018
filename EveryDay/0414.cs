�ҵ�������-��ɽҹ��

1.GMS
2.C#���ݽṹ
3.��Ϸ����
4.Ӣ��
5.��ҵ

1.3�·ݵļ�¼������û�����ģ����ꡣ
//1�����ݽṹ���ҿ쿴���ˡ�

��������

˫������
ѭ���б�
c#�е����Ա�
//��������
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
//˫������
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
			++j��
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
	//ǰ����
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
	//�����
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
//��������
//ǰ���봴������
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
//�����
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
//������û���ر�˵��������ָ��ͷ�ڵ�ĵ�����
//�������е�Ԫ�أ�λ�û��� 
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
//ʹ��ǰ����ķ�ʽ�������������е�λ��
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
ʱ�临�Ӷ�O(n).��˳����ʱ�临�Ӷȶ���һ��
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
//����������Ϊ 
LinkedList<int> Ha	��С����  ����
LinkedList<int> Hb  ��С����  ����
LinkedList<int> Hc  Hc�е�ֵ��Ҳ����������

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
ʱ�临�Ӷ� �� O((m+n)*k)

��������㷨��֪�����ѽ�㸽�����������β�����ܻ�ʱ�䡣
��Ϊ����λһ����㣬Ҫ��ͷ��ʼ���������ѽ�㣬���뵽ͷ������ʡ�ܶ�ʱ�䡣
���ǰѵ��������ӵ�ͷ�����õ��ľ������򣬶�����˳��
�ѽ����뵽����Hc��ͷ���ϲ�Ha �� Hb���㷨��
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
�����������У��Ӵ�С��Ȼ����reverse .
ʱ�临�Ӷ�O(m+n).
//��һ���ս��ĵ�����
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
ʱ�临�Ӷ�O(n).
�ܹ����Ӷ�O(m+n+n);���� O((m+n)*k),k��Hc�ĳ��ȡ�
1.��ת��
2.�ϲ�����С��������

LinkedList<int> Ha .
��ͼ���� ������ Hb .Ҫ�� Hb ֻ���� Ha ������ֵ��ͬ�Ľ�㡣
LinkedList<int> Hb .��Ha ��ֵȥ�ء�
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
�㷨��ʱ�临�Ӷ�O(m+n).m ��Ha�ĳ��ȣ�n ��Hb�ĳ��ȡ�

//��֪�������˼�ˣ���һ����㲻�ñȽϣ��ӵڶ������������ʼ�Ƚϡ�
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
//��������
//˫������
//ѭ������
//c#�е����Ա�

