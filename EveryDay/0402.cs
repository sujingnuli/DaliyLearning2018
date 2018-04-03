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

//˳���

�� ������ڣ����� ���Ա���򵥣�����Ȼ�ķ�ʽ��
���Ա�Ԫ�أ�һ����һ�� ���� ˳�� �洢��Ԫ�С�

˳������Ա�˳��洢��

ÿ��Ԫ�� ռ w  ���洢��Ԫ��
��1 ��Ԫ�صĴ洢��ַ Loc(ai)
Loc(ai)=Loc(a1)+w*(i-1);

˳��������ࡣ
SeqList<T>.
Sequence .
SeqList<T> .
SeqList<T>:IListDS<T>.
���������洢 ˳����е�ֵ��
SeqList<T> ���ֶ�Data ��ʾ
˳����У����룬ɾ��Ԫ�ء�Ҫ�� ˳������ȿɱ䡣
��������� ���������ܴ�
System.Array ��length ���Ա�ʾ��
��󳤶ȣ�MaxSize .
MaxSize ,���Ը���ʵ������ �޸ġ�SeqList<T> �Ĺ������Ĳ�����size��ʵ�֡�
˳����е�Ԫ�أ��� data[0] ��ʼ��˳���š�
SeqList<T>�У���Ҫһ��Last ���һ��Ԫ�ص�λ�á�
��Ԫ�أ�last �ı仯��Χ��0-maxSize-1.
û��Ԫ�أ�last -1 .
˳��� �ռ� ���ơ�����Ԫ�أ��ж��Ƿ����������������ܲ���Ԫ�ء�
SeqList<T>:IListDS<T>,��Ҫʵ�� �ж� ˳����Ƿ������ķ�����

public class SeqList<T>:IListDS<T>
{
	public int maxSize;
	private T[] data;
	private int last;
	
	//������
	public T this[int index]{
		get{
			return data[index];
		}
		set{
			data[index]=value;
		}
	}
	//���һ��Ԫ��λ��
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
	
	//������
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
	//��i ��λ�ã���������
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