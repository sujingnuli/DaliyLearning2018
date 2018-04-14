
//˳���
public class SeqList<T>:IListDS<T>
{
	public T[] data;
	public int maxSize;
	public int last;

	public SeqList(int size){
		data=new T[size];
		last=-1;
		maxSize=size;
	}

	public int MaxSize{
		get{
			return maxSize;
		}
		set{
			maxSize=value;
		}
	}
	public int Last{
		get{
			return last;
		}
		set{
			last=value;
		}
	}
	public bool isEmpty(){
		if(last==-1){
			return true;
		}else
			return false;
	}
	public bool isFull(){
		if(last+1==maxSize){
			return true;
		}else
			return false;
	}
	public int GetLength(){
		return last+1;
	}
	public void Clear(){
		last=-1;
	}
	public T GetItem(int i){
		var t=default(T);
		if(isEmpty()||i<1||i>last+1){
			Console.WriteLine("is Empty");
			return t;
		}
		return data[i-1];
	}
	public int Location(T item){
		if(isEmpty()){
			Console.WriteLine("isEmpty");
			return;
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
	public void Append(T item){
		if(isFull()){
			Console.WriteLine("is Full");
			break;
		}
		data[++last]=item;
	}
	public void Insert(T item,int i){
		var temp=default(T);
		if(isFull()){
			Console.WriteLine("is Full");
			return ;
		}
		if(i<1||i>last+2){
			Console.WriteLine("Error Position");
			return ;
		}
		if(i==last+2){
			data[i-1]=item;
		}else{
			var temp=data[i-1];
			for(int j=last;j>i;j--){
				data[j+1]=data[j-1];
			}
			data[i-1]=temp;
		}
		++last;
	}

	public void Delete(int i){
		if(isEmpty()){
			Console.WriteLine("isEmpty");
			return;
		}
		if(i<1||i>last+1){
			Console.WriteLine("Positoin Error");
			return;
		}
		if(i==last+1){
			temp=data[last];
		}else{
			temp=data[i-1];
			for(int j=i-1;i<=last;i++){
				data[j]=data[j+1];
			}
		}
		--last;
		return temp;
	}
}

//ʱ�临�Ӷ�
void Insert(T item,int i) ��i=1����λn, ��i=n+2,��λ0��	ƽ�� n/2  ʱ�临�Ӷ� O(N)
void GetItem(int i)										ƽ�� 1��  ʱ�临�Ӷ� O(1)
void Delete(int i)		  ��i=1����λn-1,��i=n+1,��λ0,ƽ�� n-1/2 ʱ�临�Ӷ� O(n)
void Location(T item)	  ��i=1,��ѯ 1�� ��i=n,��ѯ n.	ƽ�� n+1/2ʱ�临�Ӷ� O(n)
����˳���
Insert,Delete ʱ�临�Ӷ� O(n)
����index��ȡԪ�أ�ʱ�临�Ӷ�0(n)
����Itemȷ��λ��,ʱ�临�Ӷ�O(n)
//ʱ�临�Ӷ�Ӧ�þ���
дһ���㷨����һ��˳������� �� Ϊʲô���½�������ճ����̫�˷��ڴ棬�����500M�����֣���Ҳ��ô�ɣ�
11	23	36	45	80	60	40	6
public void ReversSeqList(SeqList<int> L){
	var len=L.GetLength();
	int temp=0;
	for(int i=0;i<=len/2;i++){
		temp=L[i];
		L[i]=L[len-i-1];
		L[len-i-1]=temp;
	}
}
��ʱ�临�Ӷ� n/2 .O(n);

//��Ϸ�������ڹ����⼸�������ʱ�����⼸��������ʼ�ƶ����ƶ���ʱ����һ����λ�á�
0��1��2��3
647��648��649��650

1 ���̫С�ˣ�
���ԣ�Ҫ��10.

0.3*100=300%10=30��
0.8*100=80%4=20��
0.5*100=50%4=12.5
0.9*10=90%4=25.5

0	10	20	30
620	630	640	650

��ֻҪһ�� �Ϳ����ˡ�
����һ��Stop ,������haha ��vidisble=false;
//Ϊʲô������ѡ���ĸ����� ���з����haha .
0.26078*10=2.678%4=

0.358*10=3.58%4=3.58 =30 .

����һ��ͼ�꣬���¿�ʼ��
���ظ��ļ���
Handler.create(this,this.up,[123,234]);

publci function up():void{
	
}