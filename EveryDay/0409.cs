//
���Ա������Ĵ洢��Ԫ���洢���е����ݡ�
�ýӿڱ�ʾ��IListDS 
public interface IListDS<T>
{
	void Insert(T item,int i);
	void Append(T item);
	int Location(T item);
	T GetItem(int index);
	...
}
˳����������������ʽ��
�����洢��Ԫ���洢�߼����ڵ����ݡ�
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
	�ŵ㣬����Ԫ�ط��㡣ʱ�临�Ӷ�O(1);
	ȱ�㣬���룬ɾ��Ԫ�� Ҫ�ƶ�Ԫ�ء�ʱ�临�ӶȻ��� O(n).
����
 �����������飬 �ɽ����ɡ����= ������+������
 ������ ֻ �洢ֱ�Ӻ��Ԫ�صĴ洢 ��ַ����Ϊ ������
 ������ �����ʾ ��
 public class Node<T>
 {
	private T data;//������
	private Node<T> next;//������
	
	//������
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

 ������������
����-����ͷ���� -���������С�
�ڵ� �� �ļ�ͷ����ʾ ������ �е� �洢��  ��ַ��

������ ���� һ���࣬LinkedList<T>,ʵ����IListDS<T>.
LinkedList<T>,��һ���ֶΣ�head .��ʾ ������ ��ͷ���ã�head �������� Node<T>.
����Ĵ洢�ռ䣬�ǲ������ģ�����û�����ռ�����ƣ�

public class LinkedList<T>:IListDS<T>
{
	private Node<T> head; //ͷ����

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
	//�ں���׷��Ԫ��
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

	//ɾ���������еĵ�i�����
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
	//��ȡ������� �� i  ��Ԫ������
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
	//����λ��
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
������Ĳ���
1.����
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

ʱ�临�Ӷȣ��󳤶ȣ�O(n);
2.��ղ���
public void Clear(){
	head=null;
}
3.�жϵ����� �Ƿ��
public bool isEmpty(){
	if(head==null){
		return true;
	}else
		return false;
}
4.���Ӳ���
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
�㷨ʱ�临�Ӷ�O(n).
5.�������
������ �Ĳ��� ���� ���� i ��λ�� ��� �������� һ����㡣
ǰ��/���
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
//������
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

�㷨ʱ�临�Ӷȷ�����
	ǰ�壬�ͺ���Ԫ�أ�i ���š�
	ͷ���ã�һ����������
	i=1,O(1);
	i=n.O(n-1)
	O(N/2)
//ɾ������
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
			//���� ����ʼ��¼��־

		}
	}
}
