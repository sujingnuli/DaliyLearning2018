public interface IListExamp<T>
{
	void Clear();
	bool isEmpty();
	T Delete(T item);

	T GetItem(int i);
	int Location(T item);
	int GetLength();

	void Insert(T t,int i);
	void Append(T t);
}

//顺序表

在 计算机内，保存 线性表最简单，最自然的方式。
线性表。元素，一个挨一个 放在 顺序 存储单元中。

顺序表（线性表，顺序存储）

每个元素 占 w  个存储单元。
第1 个元素的存储地址 Loc(ai)
Loc(ai)=Loc(a1)+w*(i-1);

顺序表，泛型类。
SeqList<T>.
Sequence .
SeqList<T> .
SeqList<T>:IListDS<T>.
用数组来存储 顺序表中的值。
SeqList<T> 用字段Data 表示
顺序表中，插入，删除元素。要求 顺序表，长度可变。
数组的容量 ，设计需求很大。
System.Array 的length 属性表示。
最大长度，MaxSize .
MaxSize ,可以根据实际需求 修改。SeqList<T> 的构造器的参数，size来实现。
顺序表中的元素，由 data[0] 开始，顺序存放。
SeqList<T>中，需要一个Last 最后一个元素的位置。
有元素，last 的变化范围，0-maxSize-1.
没有元素，last -1 .
顺序表 空间 限制。插入元素，判断是否已满，已满，不能插入元素。
SeqList<T>:IListDS<T>,需要实现 判断 顺序表是否已满的方法。

public class SeqList<T>:IListDS<T>
{
	public int maxSize;
	private T[] data;
	private int last;
	
	//索引器
	public T this[int index]{
		get{
			return data[index];
		}
		set{
			data[index]=value;
		}
	}
	//最后一个元素位置
	public int Last{
		get{
			return last;
		}
	}

	public int MaxSize{
		get{
			return maxSize;
		}
		set{
			maxSize=value;
		}
	}
	
	//构造器
	public SeqList(int size){
		data=new T[size];
		maxSize=size;
		last=-1;
	}

	public int GetLength(){
		return last+1;
	}

	public void Clear(){
		last=-1;
	}

	public bool isEmpty(){
		if(last=-1){
			return true;
		}else
			return false;
	}

	public bool isFull(){
		if(last==maxSize-1)
			return true;
		else
			return false;
	}

	public void Append(T item){
		if(isFull){
			Console.WriteLine("Last is Full");
			return;
		}
		data[++last]=item;
	}
	//第i 个位置，插入严肃
	public void Insert(T item,int i){
		if(isFull()){
			return ;
		}
		if(i<1||i>last+2){
			return;
		}
		if(i==last+2){
			data[last+1]=item;
		}else{
			for(int j=last;j>=i-1;j--){
				data[j+1]=data[j];
			}
			data[i-1]=item;
		}
		++last;
	}
}