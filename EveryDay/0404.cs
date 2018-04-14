
//顺序表
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

//时间复杂度
void Insert(T item,int i) 当i=1，移位n, 当i=n+2,移位0，	平均 n/2  时间复杂度 O(N)
void GetItem(int i)										平均 1，  时间复杂度 O(1)
void Delete(int i)		  当i=1，移位n-1,当i=n+1,移位0,平均 n-1/2 时间复杂度 O(n)
void Location(T item)	  当i=1,查询 1， 当i=n,查询 n.	平均 n+1/2时间复杂度 O(n)
对于顺序表
Insert,Delete 时间复杂度 O(n)
根据index获取元素，时间复杂度0(n)
根据Item确定位置,时间复杂度O(n)
//时间复杂度应用举例
写一个算法，将一个顺序表，倒置 。 为什么不新建，复制粘贴？太浪费内存，如果是500M的数字，你也这么干？
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
算时间复杂度 n/2 .O(n);

//游戏开发，在构建这几个画面的时候，让这几个东西开始移动，移动的时候，有一定的位置。
0，1，2，3
647，648，649，650

1 相差太小了，
所以，要加10.

0.3*100=300%10=30；
0.8*100=80%4=20；
0.5*100=50%4=12.5
0.9*10=90%4=25.5

0	10	20	30
620	630	640	650

我只要一个 就可以了。
其中一个Stop ,其他的haha 都vidisble=false;
//为什么，不管选择哪个都是 红螃蟹出来haha .
0.26078*10=2.678%4=

0.358*10=3.58%4=3.58 =30 .

增加一个图标，重新开始。
有重复的迹象
Handler.create(this,this.up,[123,234]);

publci function up():void{
	
}