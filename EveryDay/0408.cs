1.游戏做完
2.加入声效
3.把飞机大战的游戏做完。



1.点击重来的时候，可以重来
2.留下小脚印
3.加入音频。



1.数据结构看2 页
//示例：
1.对数据进行倒序排列
public void ReversSeqList<T>(SeqList<T> ls)
{
	var len=ls.GetLength();
	var temp=default(T);
	for(int i=0;i<=len/2;i++){
		temp=ls[i];
		ls[i]=ls[len-i-1];
		ls[len-i-1]=temp;
	}
	return ls;
}


顺序表。再写一遍顺序表
public class SeqList<T>:IListDS<T>
{
	public T[] data;
	public int maxSize;
	public int last;
	public int MaxSize{
		get{
			return this.maxSize;
		}
		set{
			this.maxSize=value;
		}
	}
	public int Last{
		get{
			return this.last;
		}
	}
	public SeqList(int size){
		data=new T[size];
		maxSize=size;
		last=-1;
	}
	public bool isFull(){
		if(last+1=maxSize){
			return true;
		}else{
			return false;
		}
	}
	public bool isEmpty(){
		if(last=-1){
			return true;
		}else
			return false;
	}
	public void GetLength(){
		return last+1;
	}
	public void Append(T item){
		if(isFull()){
			Console.WriteLine("is Full");
			return ;
		}
		data[++last]=item;
	}
	public T GetItem(int index){
		var temp=default(T);
		if(isEmpty()){
			Console.WriteLine("is Empty");
			return temp;
		}
		if(index<1||index+1>maxSize){
			Console.WriteLine("Error Position");
			return temp;
		}
		return data[index];
	}
	public int Loacation(T item){
		if(isEmpty()){
			Console.WriteLine("is Empty");
			return -1;
		}
		for(int i=0;i<=last;i++){
			if(item.Equals(data[i])){
				return i;
			}
		}
		return -1;
	}

	public void Insert(T item,int i){
		if(isFull()){
			Console.WriteLine("is Full");
			return ;
		}
		if(i<-1||i>last+2){
			Console.WriteLine("Error Position");
			return ;
		}
		if(i==last+2){
			data[++last]=item;
		}else{
			for(int j=last+1;j>i;j--){
				data[j]=data[j-1];
			}
			data[i]=item;
			++last;
		}
	}
	public T Delete(int index){
		var temp=default(T);
		if(isEmpty()||index<1||index>last+1){
			Console.WriteLine("Empty or Error Position");
			return temp;
		}
		if(index==last+1){
			temp=data[last--];
		}else{
			temp=data[index];
			for(int j=index-1;j<last;j++){
				data[j]=data[j+1];
			}
			--last;
		}
		return temp;
	}
}
//例 2-2  
SeqList<int>  La,Lb . 数据元素，均 从小到大 升序排列。  编写一个算法，将他们整合成一个Lc .要求Lc也按照升序排列。


public void CombSeql(SeqList<int> La,SeqList<T> lb){
	var Lc=new SeqList<int>(La.GetLength()+lb.GetLength());
	for(int i=0;i<La.length;i++){
		if(La[i]<Lb[i]){
			Lc[i]=La[i];
			for(int i)
		}else{
			Lc[i]=Lb[i];
		}
		for(int j=0;j<Lb.Length;j++){
			if(La[i]<Lb[j]){
				
			}
		}
	}
	SeqList<int> temp=La.GetLength()<=Lb.GetLength()?La:Lb;
	SeqList<int> temp2=temp==La?Lb;
	for(int i=0;i<temp.GetLength;i++){
		if(temp[i]<temp2[i]){
			
		}
	}
}
La 复制 到 Lc ,然后拿 Lc 和 Lb做比较。那样的话，就的移动，移动好多个。
//依次 扫描 La 和	Lb 的数据元素，比较 La  和 Lb 当前数据元素的 值。将最小值 赋值  给Lc .
//如此 直到 一个顺序表 被 扫完，然后将 未完成的 顺序表 剩下的 数据元素 ，赋值 给Lc .Lc的长度 ，是 长度和 。
public SeqList<int> Merge(SeqList<int> La,SeqList<int> Lb){
	SeqList<int> Lc=new SeqList<int>(La.MaxSize+Lb.MaxSize);
	
	while((i<=(La.GetLength()-1))&&(j<=(Lb.GetLength()-1))){
		if(La[i]<Lb[j]){
			Lc.Append(La[i++]);
		}else{
			Lc.Append(Lb[j++]);
		}
	}
	while(i<=(La.GetLength()-1)){
		Lc.Append(La[i++]);
	}
	while(j<=(Lb.GetLength()-1)){
		Lc.Append(Lb[j++]);
	}

	return Lc;
}
时间复杂度 O(n+m);m 是La 的长度，Lb 的长度
La	1,2,3,7,9  /4
Lb	4,6,8	   /2

i=0;j=0
	Lc[0]=1,
	i=1;j=0;
i=1,j=0
	Lc[1]=2;
	i=2;j=0;
i=2;j=0;
	Lc[2]=3;
i=3;j=0;
	Lc[3]=4
i=3;j=1;
//简直不要太精妙

将两个 顺序表 合并，La 和 Lb .
La 和 Lb  都是从小到大 升序
Lc 也 从小到大 升序

La 和 Lb 都升序排列，合并到 Lc 中，升序排列

public SeqList<int> Merge(SeqList<int> La,SeqList<int> Lb){
	while(i<=(La.GetLength()-1)&&j<=(Lb.GetLength()-1)){
		if(La[i]<Lb[j]){
			Lc.Append(La[i++]);
		}else{
			Lc.Append(Lb[j++]);
		}
	}
	//如果是 A 长度长
	while(i<=(La.GetLength()-1)){
		Lc.Append(La[i++]);
	}
	while(j<=(Lb.GetLength()-1)){
		Lc.Append(Lb[j++]);
	}
	return Lc;
}

//合并顺序表
public SeqList<int> Merge(SeqList<int> La,SeqList<int> Lb){
	SeqList<int> Lc=new SeqList<int>(La.MaxSize+Lb.MaxSize);
	while((i<=(La.GetLength()-1))&&j<=(Lb.GetLength()-1)){
		if(La[i]<Lb[j]){
			Lc.Append(La[i++]);
		}else{
			Lc.Append(Lb[j++]);
		}
	}
	while(i<=(La.GetLength()-1)){
		Lc.Append(La[i++]);
	}
	while(j<=(Lb.GetLength()-1)){
		Lc.Append(Lb[j++]);
	}
	return Lc;
}

//例2-3 
已知 一个存储整数 的 顺序表 La ,SeqList<int> La,
SeqList<int> La
试构造 一个顺序表 Lb .要求 顺序表中 Lb 只 包含 La 中 所有 值不同的数据元素 。

public SeqList<int> UniqueSql(SeqList<int> La){
	SeqList<int> Lb=new SeqList<int>(La.GetLength());
	for(int i=0;i<=last;i++){
		var index=Lb.Location(La[i]);
		if(index==-1){
			Lb.Append(La[i]);
		}
	}
	return Lb;
}

这样，每次i ，都要循环，Lb 的次数，并且是 阶乘 !n .
时间复杂度 O(m*!n);

先把顺序表的第一个元素 赋值 给Lb , 然后 从第二个元素 起， 每一个元素 ，与顺序表的 每一个元素比较。不相同的，加
public SeqList<int> Purge(SeqList<int> La){
	SeqList<int> Lb=new SeqList<int>(La.MaxSize);
	Lb.Append(La[0]);

	for(int i=0;i<=La.GetLength()-1;i++){
		int j=0;
		for(int j=0;j<Lb.GetLength()-1;j++){
			if(La[i].CompareTo(Lb[j])==0){
				break;
			}
		}
		if(j>Lb.GetLength()-1){
			Lb.Append(La[i]);
		}
	}
	return Lb;
}

public SeqList<int> Purge(SeqList<int> La){
	SeqList<int> Lb=new SeqList<int>(La.GetLength()-1);
	for(int i=0;i<=La.GetLength()-1;i++){
		for(int j=0;j<Lb.GetLength()-1;j++){
			if(La[i].CompareTo(Lb[j])==0){//等于
				break;
			}
		}
		if(j>Lb.GetLength()-1){
			Lb.Append(La[i]);
		}
	}
	return Lb;
}

//单 链表 
 顺序表： 物理位置相同的，存放线性表的 各个元素。
 逻辑上相邻的数据，物理位置也相邻。
 查找，方便。
 插入和删除，要移动数据表。 影响效率
 //链表：Linked List .
链式存储 链表 Linked List。
对链表 进行插入和删除 时，不需要移动元素。也失去 随机 存储的 优点。
对链式表 ，插入和删除时，不需要 移动元素。


ToPagedList 
public interface IPagedList
{
	public int PageSize{get;set;]
	public int CurrentPageIndex{get;set;}
	public int TotalItemCount{get;set;}
}
public class PagedList<T>;List<T>,IPagedList
{
	public PagedList(IQueryable<T> items,int PageSize,int pageIndex,int totalItemCount){
		AddRange(items);
		this.CurrentPageIndex=pageIndex;
		this.PageSize=pageSize;
		this.TotalItemCount=totalItemCount;
	}
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return (int)Math.Ceil(TotalItemCount/(double)PageSize);}}
	public int StartItemIndex{get{return (CurrentPageIndex-1)*PageSize+1;}}
	public int EndItemIndex{get{return TotalItemCount>(PageSize*CurrentPageIndex)?PageSize*CurrentPageIndex:TotalItemCount;}}
}
//IQueryable 是在 需要的时候，才执行Sql 的。
public interface IUserService
{
	IEnumerable<User> GetUserList(UserRequest request);
	IEnuemrable<Role> GetRoleList(RoleRequest request);
}
public class Request
{
	public Request(){
		this.PageSize=5000;
	}
	public int Top{
		set{
			this.PageSize=value;
			this.PageIndex=1;
		}
	}
	public int PageSize{get;set;}
	public int PageIndex{get;set;}
}
public class UserRequest:Request
{
	
	public string LoginName{get;set;}

	public string Mobile{get;set;}

}
public class UserService
{
	public List<User> GetUserList(UserRequest request){
		using(var dbContext=new UserDbContext()){
			var users=dbContext.Users.Include("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.LoginName.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(u=>u.ID).ToList();
		}
	}
}
public class UserDbContext:DbContextBase
{
	public UserDbContext():base(CachedConfigContext.Current.DaoConfig.User,new LogDbContext()){
		
	}
	public void OnModelCreating(DbModelBuilder modelBuilder){
		this.Database.SetInitializer<AccountDbContext>(null);
		modelBuilder.Entry<User>()
			.HasMany(u=>u.Role)
			.WithMany(r=>r.User)
			.Map(m=>{
				m.ToTable("UserRole");
				m.MapLeftKey("UserID");
				m.MapRightKey("RoleID");
			});
		base.OnModelCreating(modelBuilder);
	}
	public DbSet<User> Useres{get;set;}
	public DbSet<Role> Roles{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
}
public class UserController:WebBaseController{
	public ActionResult GetUserList(UserRequest request){
		var res=this.UserService.GetUserList();
		return View(res);
	}

	public ActionResult Create(){
		var roles=this.AccountService.GetRoleList();
		this.VeiwBag.RoleIds=new SelectList(roles,"ID","Name");
		var model=new User();
		user.Password="111111"
		return View("Edit",model);
	}
}


public interface IUserService
{
	IEnumerable<User> GetUserList(UserRequest request);
	IEnumerable<Role> GetRoleList(RoleRequest request);
}

