1.������
La ,Lb ���� ��С����� ���� ���� ˳���
���������� �ϲ��� Lc�� ��Lc Ҳ�� ��������

˳���:SeqList<T>.
public SeqList<int> Merge(SeqList<int> La,SeqList<int> Lb){
	SeqList<int> Lc=new SeqList<int>(La.MaxSize+Lb.MaxSize);
	int i=0;
	int j=0;
	while(i<=(La.GetLength()-1)&&j<=(Lb.GetLength()-1)){
		if(La[i]<Lb[j]){
			Lc.Append(La[i++]);
		}else{
			Lc.Append(Lb[j++]);
		}
	}
	//1.A����ʣ��
	while(i<=(La.GetLength()-1)){
		Lc.Append(La[i++]);
	}
	//2.B�� ��ʣ��
	while(j<=(Lb.GetLength()-1)){
		Lc.Append(Lb[j++]);
	}
}

//ʱ�临�Ӷ� O(n+m);
