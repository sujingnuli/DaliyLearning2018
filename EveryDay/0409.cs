//
线性表，连续的存储单元，存储表中的数据。
用接口表示，IListDS 
public interface IListDS<T>
{
	void Insert(T item,int i);
	void Append(T item);
	int Location(T item);
	T GetItem(int index);
	...
}
顺序表，借助于数组的形式。
连续存储单元，存储逻辑相邻的数据。
public class SeqList<T>:IListDS<T>
{
	public T[] data;
	public int maxSize;
	public int last;
	public SeqList(int size){
		data=new T[size];
		this.maxSize=size;
		this.last=-1;
	}
	...
}
	优点，查找元素方便。时间复杂度O(1);
	缺点，插入，删除元素 要移动元素。时间复杂度基本 O(n).
链表；
 不借助于数组， 由结点组成。结点= 数据域+引用域。
 引用域 只 存储直接后继元素的存储 地址，称为 单链表。
 单链表 用类表示 。
 public class Node<T>
 {
	private T data;//数据域
	private Node<T> next;//引用域
	
	//构造器
	public Node(T val,Node<T> p){
		data=val;
		next=p;
	}
	public Node(Node<T> p){
		next=p;
	}
	public Node(T val){
		this.data=val;
		next=null;
	}
	public Node(){
		data=default(T);
		next=null;
	}

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
			return next;
		}
		set{
			next=value;
		}
	}
 }

 数据域，引用域；
链表-》箭头相连 -》结点的序列。
节点 间 的箭头，表示 引用域 中的 存储的  地址。

单链表 看成 一个类，LinkedList<T>,实现了IListDS<T>.
LinkedList<T>,有一个字段，head .表示 单链表 的头引用，head 的类型是 Node<T>.
链表的存储空间，是不连续的，所以没有最大空间的限制，

public class LinkedList<T>:IListDS<T>
{
	private Node<T> head; //头引用

	public Node<T> Head{
		get{
			return head;
		}
		set{
			head=value;
		}
	}

	public LinkedList(){
		head=null;
	}
	
	public void Clear(){
		head=null;
	}
	public void isEmpty(){
		if(head==null){
			return true;
		}else
			return false;
		
	}
	public int GetLength(){
		Node<T> p=head;
		int len=0;
		while(p!=null){
			++len;

			p=p.Next;
		}
		return len;
	}
	//在后面追加元素
	public void Append(T item){
		Node<T> q=new Node<T>(item);
		Node<T> p=new Node<T>();
		if(head==null){
			head=q;
			return;
		}
		p=head;
		while(p.Next!=null){
			p=p.Next;
		}
		p.Next=q;

	}
	
	public void InsertPost(T item,int i){
		if(isEmpty()||i<1){
			Console.WriteLine("Empty List");
			return ;
		}
		if(i==1){
			Node<T> p=new Node<T>(item);
			p.Next=head.Next;
			head.Next=p;
			return ;
		}
		Node<T> p=head;
		int j=1;
		
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

	//删除单链表中的第i个结点
	public T Delete(int i){
		if(isEmpty()||i<0){
			Console.WriteLine("Empty List");
			return default(T);
		}
		Node<T> q=new Node<T>();
		if(i==1){
			q=head.Next;
			return q.Data;
		}
		Node<T> p=head;
		int j=1;
		while(p.Next!=null&&j<i){
			q=p;
			p=p.Next;
			++j;
		}
		if(j==i){
			q.Next=p.Next;
			return p.Data;
		}else{
			Console.WriteLine("Not EXISTS");
			return default(T);
		}
	}
	//获取单链表的 第 i  个元素数据
	public T GetItem(int i){
		if(isEmpty()){
			Console.WriteLine("Empty List");
			return default(T);
		}
		Node<T> p=new Node<T>();

		p=head;
		int j=1;
		while(p.Next!=null&&j<i){
			p=p.Next;
			++j;
		}
		if(j==i){
			return p.Data;
		}else{
			Console.WriteLine("Not Exists");
			return default(T);
		}

	}
	//查找位置
	public int Location(T item){
		if(isEmpty()){
			Console.WriteLine("Empty List");
			return -1;
		}
		Node<T> p=new Node<T>();
		p=head;
		int i=1;
		while(!p.Data.Equals(item)&&p.Next!=null){
			p=p.Next;
			++i;
		}
		return i;
	}

}
单链表的操作
1.长度
SeqList ,
public int GetLength(){
	return last+1;
}
LinkedList
public void GetLength(){
	Node<T> p=new Node<T>();
	p=head;
	int j=0;
	while(p!=null){
		++j;
		p=p.Next;
	}
	return j;
}

时间复杂度：求长度，O(n);
2.清空操作
public void Clear(){
	head=null;
}
3.判断单链表 是否空
public bool isEmpty(){
	if(head==null){
		return true;
	}else
		return false;
}
4.附加操作
public void Append(T item){
	Node<T> q=new Node<T>(item);
	Node<T> p=new Node<T>();
	if(isEmpty()){
		head=q;
		return;
	}
	p=head;
	int j=1;
	while(p.Next!=null){
		p=p.Next;
		++j;
	}
	p.Next=q;
}
算法时间复杂度O(n).
5.插入操作
单链表 的插入 操作 ，第 i 个位置 结点 处，插入 一个结点。
前插/后插
public void Insert(T item,int i){
	if(isEmpty()||i<1){
		Console.WriteLine("Empty List");
		return;
	}
	if(i==1){
		Node<T> q=new Node<T>(item);
		q.Next=head.Next;
		head.Next=q;
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
		q.Next=r.Next;
		r.Next=q;
	}else{
		Console.WriteLine("Position Error");
	}
	return;
}
//后插操作
public void InsertPost(T item ,int i){
	if(isEmpty()||i<1){
		Console.WriteLine("ErrorPostion");
		return;
	}
	if(j==1){
		Node<T> q=new Node<T>(item);
		Node<T> p=head.Next;
		q.Next=p.Next;
		p.Next=q;
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
		p.Next=q;
	}else{
		Console.WriteLine("Error Position");
	}
	return;
}

算法时间复杂度分析：
	前插，和后插的元素，i 吵着。
	头引用，一个个便利。
	i=1,O(1);
	i=n.O(n-1)
	O(N/2)
//删除操作
public void Delete(int i){
	if(isEmpty()||i<0){
		Console.WriteLine("Error Position or Empty");
		return ;
	}
}
public ActionResult Create(){
	var roles=this.AccountService.GetRoleList();
	ViewBag.RoleIds=new SelectList(roles,"ID","Name");
	var model=new User();
	model.Password="111111";
	return View("Edit",model);
}

public interface IAccountService
{
	IEnumerable<User> GetUserList(UserRequest request);
	IEnumerable<Role> GetRoleList(RoleRequest request);
}
public class AccountService:IAccountService
{
	public IEnumerable<Role> GetRoleList(RoleRequest request=null){
		request=request??new RoleRequest();
		using(var dbContext=new AccountDbContext()){
			var roles=dbContext.Roles;
			if(!string.IsNullOrEmpty(request.RoleName)){
				roles=roles.Where(r=>r.RoleName.Contains(request.RoleName));
			}
			return roles.OrderByDescending(r=>r.ID).ToPagedList(request.PageIndex,request.PageSize);
		}
	}

	public IEnumerbale<User> GetUserList(UserRequest request=null){
		request=request==null?new UserRequest();
		using(var dbContext=new AccountDbContext()){
			var users=dbContext.Users.InClude("Roles");
			if(!string.IsNullOrEmpty(request.LoginName)){
				users=users.Where(u=>u.Contains(request.LoginName));
			}
			if(!string.IsNullOrEmpty(request.Mobile)){
				users=users.Where(u=>u.Mobile.Contains(request.Mobile));
			}
			return users.OrderByDescending(u=>u.ID).ToPagedList(request.PageIndex,requdest.PageSize);
		}
	}
}
public class Request
{
	public Request(){
		PageSize=5000;
	}
	public int Top{
		set{
			this.PageIndex=1;
			this.PageSize=value;
		}
	}
	public int PageIndex{get;set;}
	public int PageSize{get;set;}
}
public class RoleRequest:Request
{
	public string RoleName{get;set;}
}
public class UserRequest:Request
{
	public string LoginName{get;set;}
	public string Mobile{get;set;}
}
public class AccountDbContext:DbContextBase
{
	public AccountDbContext():base(CachedConfigContext.Current.DaoConfig.Account,new LogDbContext()){
	
	}
	public void OnModelCreating(DbModelBuilder modelBuilder){
		this.Database.SetInitalizer<AccountDbContext>(null);
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
	public DbSet<User> Users{get;set;}
	public DbSet<Role> Roles{get;set;}
	public DbSet<VerifyCode> VerifyCodes{get;set;}
	public DbSet<LoginInfo> LoginInfos{get;set;} 
}
public interface IDataRepository<T>
{
	T Update<T>(T entity) where T:ModelBase;
	T Insert<T>(T entity) where T:ModelBase;
	T Find<T>(params object[] keys) where T:ModelBase;
	void Delete<T>(T entity) where T:ModelBase;
	IEnumerable<T> FindAll(Expiression<Func<T,bool>> conditions) where T:ModelBase;
}
public class DbContextBase:DbContext,IDataRespository<T>,IDisposable
{
	private IAuditable AuditLogger;
	public DbContextBase(string connectionString){
		this.Database.Connection.ConnectionString=connectionString;
		this.Configuration.LazyLoadedEnabled=false;
		this.Configuration.ProxyCreationEnabled=false;
	}
	public DbContextBase(string connectionString,IAudiable audit):this(connectionString){
		this.AuditLogger=audit;
	}

	public T Update<T>(T entity) where T:ModelBase{
		this.Set<T>().Attach(entity);
		this.Entry<T>(entity).State=EntityState.Modified;
		this.SaveChanges();
		return entity;
	}
	public T Insert<T>(T entity) where T:ModelBase{
		this.Set<T>().Add(entity);
		this.SaveChanges();
		return entity;
	}
	public void Delete<T>(T entity) where T:ModelBase{
		this.Entry<T>(entity).State=EntityState.Deleted;
		this.SaveChanges();
	}
	public T Find<T>(params object[] keys) where T:ModelBase{
		return this.Set<T>().Find(keys);
	}
	public List<T> FindAll<T>(Expiression<Func<T,bool>> conditions)where T:ModelBase{
		if(conditions==nul){
			return this.Set<T>().ToList();
		}else{
			return this.Set<T>().Where(conditions).ToList();
		}
	}

	public int SaveChanges(){
		this.WriteLog();
		var res=base.saveChanges();
		return res;
	}
	public void WriteLog(){
		if(this.AuditLog==null){
			return;
		}
		foreach(var dbEntry in this.ChangeTracker.Entries<ModelBase>().Where(p=>p.State=EntityState.Added||p.State=EntityState.Modified||p.State=EntityState.Deleted)){
			var auditAttr=dbEntry.Entity.GetType().GetCustomeAttribute(typeof(AuditableAttribute),false) as AuditableAttribute;
			if(auditAttr==null){
				continute;
			}
			//否则 ，开始记录日志

		}
	}
}
