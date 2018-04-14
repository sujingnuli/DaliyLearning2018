1.条件：
La ,Lb 都是 从小到大的 升序 排列 顺序表
将这两个表 合并到 Lc中 。Lc 也是 升序排列

顺序表:SeqList<T>.
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
	//1.A表有剩余
	while(i<=(La.GetLength()-1)){
		Lc.Append(La[i++]);
	}
	//2.B表 有剩余
	while(j<=(Lb.GetLength()-1)){
		Lc.Append(Lb[j++]);
	}
}

//时间复杂度 O(n+m);
