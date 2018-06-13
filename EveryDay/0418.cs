//ToPagedList
//CachedConfigContext
//DbContextBase
//AuditLog
public interface IDataRepository
{
	T Update<T>(T item) where T:ModelBase;
	T Insert<T>(T item) where T:ModelBase;
	void Delete<T>(T entity) where T:ModelBase;
	T Find<T>(params object[] keys) where T:ModelBase;
	List<T> FindAll<T>(Expression<Func<T,bool>> conditions);
	PagedList<T> FindAllByPage<T,S>(Expression<Func<T,bool>> conditions,Expression<Func<T,S>> orderBy,int pageSize,int pageIndex) where T:ModelBase;
}
public class DbContextBase:DbContext,IDataRepository,IDisposable
{
	private IAuditable AuditLogger{get;set;}
	public DbContextBase(string connectionString){
		this.Database.Connection.ConenctionString=connectionString;
		this.Configuration.LazyLoadingEnabled=false;
		this.Configuration.ProxyCreationEnabled=false;
	}
	public DbContextBase(string connectionString,IAuditable auditLog):this(connectionString){
		this.AuditLogger=auditLog;
	}
	public T Update<T>(T entity) where T:ModelBase{
		this.Set<T>().Attach(entity);
		this.Entry<T>(entity).State=EntityState.Modified;
		this.SaveChanges();
		return entity;
	}
	public T Insret<T>(T entity) where T:ModelBase{
		this.Set<T>().Add(entity);
		this.SaveChanges();
	}
	public T Find<T>(params object[] keys) where T:ModelBase{
		return this.Set<T>().Find(keys);
	}
	public List<T> FindAll<T>(Expression<Func<T,bool>> conditions=null) where T:ModelBase{
		if(conditions==null){
			return this.Set<T>().ToList();
		}else{
			return this.Set<T>().Where(conditions).ToList();
		}
	}
	public void Delete<T>(T entity) where T:ModelBase{
		this.Entry<T>(entity).State=EntityState.Deleted;
		this.SaveChanges();
	}

	public int SaveChanges(){
		this.WrieLog();
		return base.SaveChanges();
	}

	public void WriteLog(){
		if(AuditLogger==null){
			return ;
		}
		foreach(var dbEntry in this.ChangeTracker.Entries<ModelBase>().Where(p=>p.State=EntityState.Modified||p.State==EntityState.Added||p.State=EntityState.Deleted)){
			var auditAttr=dbEntry.Entity.GetType().GetCustomeAttribute(typeof(AuditableAttribute),false);
			if(auditAttr==null){
				continute;
			}
			var operaterName=WCFContext.Current.OperaterName;
			Task.Factory.NewStart(m=>{
				var tableAttr=dbEntry.Entity.GetType().GetCustomAttribtue(typeof(TableAttribute),false) as TableAttribute;
				string tableName=tableAttr!=null?tableAttr.Name:dbEntry.Entity.GetType().Name;
				string moduleName=dbEntry.Entity.GetType().FullName().Split(".").Skip(1).FirstOrDefault();
				AuditLogger.WriteLog(dbEntry.Entity.ID,operaterName,moduleName,tableName,dbEntry.State.ToString(),dbEntry.Entity);
			});
		}
	}
}
public interface IAuditable
{
	void WriteLog(int modelId,string userName,string moduleName,string tableName,string eventType,ModelBase newValue);
}
public class AuditLog:ModelBase
{
	public int ModelId{get;set;}
	public string UserName{get;set;}
	public string TableName{get;set;}
	public string ModuleName{get;set;}
	public string EventType{get;set;}
	public ModelBase NewValue{get;set;}
}
public class LogDbContext:DbContextBase,IAuditable
{
	public LogDbContext():base(CachedConfigContext.Current.DaoConfig.Log){
	
	}
	public DbSet<AuditLog> AuditLogs{get;set;}
	public void WriteLog(int modelId,string userName,string moduleName,string tableName,string eventType,ModelBase newValue){
		this.AuditLogs.Add(new AuditLog(){
			ModelId=modelId,
			UserName=userName,
			ModuleName=moduleName,
			TableName=tableName,
			EventType=eventType,
			NewValue=JsonConvert.Serializer(newValue,new JsonSerilaizerSettings{ReferenceLoopHanding=ReferenceLoopHanding.Ignore})
		});
		this.SaveChanges();
		this.Dispose();
	}

}
//ToPagedList 
public interface IPagedList
{
	int CurrentPageIndex{get;set;}
	int PageSize{get;set;}
	int TotalItemCount{get;set;}
}
public class PagedList<T>:IPagedList
{
	public PagedList(IEnumerable<T> allItems,int pageSize,int pageIndex){
		this.PageSize=pageSize;
		this.PageIndex=pageIndex;
		this.TotalItemCount=allItems.Count;
	}
	public PagedList(IQueryable<T> items,int pageSize,int pageIndex,int totalItemCount){
		AddRange(items);
		this.CurrentPageIndex=pageIndex;
		this.PageSize=pageSize;
		this.TotalItemCount=totalItemCount;
	}
	public int ExtItemCount{get;set;}
	public int CurrentPageIndex{get;set;}
	public int PageSize{get;set;}
	public int TotalItemCount{get;set;}
	public int TotalPageCount{get{return Math.Ceil(TotalItemCount/(double)PageSize);}}
	public int StartRecordIndex{get{return PageSize*CurrentPageIndex+1;}}
	public int EndRecordIndex{get{return TotalItemCount>PageSize*CurrentPageIndex?pageSize*CurentPageIndex:TotalItemCount;}}
}

public static class PageLinqExtension
{
	public static PagedList<T> ToPagedList<T>(this IQueryable<T> allIitems,int pageSize,int PageIndex){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(pageIndex-1)*pageSize;
		var pageItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemCount=allItems.Count;
		return new PagedList<T>(pageItems,pageSize,pageIndex,totalItemCount);
	}
}

public static class PageLinqExtensions
{
	public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems,int pageSize,int PageIndex){
		if(pageIndex<1){
			pageIndex=1;
		}
		var itemIndex=(pageIndex-1)*PageSize;
		var pageItems=allItems.Skip(itemIndex).Take(pageSize).ToList();
		var totalItemCount=allItems.Count;
		return new PagedList<T>(pageItems,pageSize,pageIndex,totalItemCount);
	}
}
//1.Edit 尝试调试
//2.如果Edit 调试不成，就开始做Role相关内容。
[Auditable]
[Table("User")]
public class User:ModelBase
{
	[Required(ErrorMessage="登录名不能为空")]
	public string LoginName{get;set;}

	public string Password{get;set;}
	[RegularExpression(@"^[1-9]{1}\d{10}$")]
	public string Mobile{get;set;}
	[RegularExpression(@"[A-Za-z0-9._+-]+@[a-zA-Z0-9]\.\d{3,4}")]
	public string Email{get;set;}
	[NotMapped]
	public string NewPassword{get;set;}

	[NotMap]
	public List<int> RoleIds{get;set;}

	public List<Role> Roles{get;set;}
	[NotMapped]
	public List<EnumBusinessPermission> BusinessPermissonList{
		get{
			var permissions=new List<EnumBusinessPermisson>();
			foreach(var role in Roles){
				permissions.AddRange(role.PermissionList);
			}
			return permissions;
		}
	}
}

只有一个的时候，查询有问题。
为什么原来的有Edit
UserRole

public ActionResult Edit(int id,FormCollection collection){
	var user=this.AccountService.GetUser(id);
	this.TryUpdateModel(model);
	this.AccountService.Save(model);
	return RefreshParent();
}

<div class='row-fluid'>
	<div class='span4'>
		<a class='btn red' id='delete' href='javscript:;'><i class='icon-trash icon-white'></i>删除</a>
		<a class='btn blue thickbox' href='@Url.Action("Create")?TB_iframe=true&width=350&height=500'><i class='icon-plus icon-white'></i>新增</a>
	</div>
	<div class='span8'>
	@using(Html.BeginForm(null,null,null,FormMethod.Get,new{id="search"})){
			<label>
			<button type='submit' class='btn' >搜索<i class='icon-search'></i></button>
		</label>
		<label>
			<span>角色名:</span>@Html.TextBox("LoginName",new{id="m-wrap small"})
		</label>
	}
	</div>
</div>
@using(Html.BeginForm("Delete","Role",FormMethod.Post,new{id="mainForm"})){
	<table class="table table-stripped table-hover">
		<thead>
			<th><input type='checkbox' id='checkall' class='group-checkable'/></th>
			<th>角色名</th><th>说明</th><th>权限</th><th>操作</th>
		</thead>
		<tbody>
			@foreach(var m in Model){
				<tr>
					<td><input type='checkbox' class='checkboxes' name='ids'/></td>
					<td>@m.Name</td>
					<td>@StringUtils.</td>
				</tr>
	}
		</tbody>
	</table>
}
        
角色
描述
权限
public ActionResult Create(){
	var BusinessPermissionList=
}
//权限管理
//角色
//权限
//有哪些是不需要权限过滤的。
public ActionResult Create(){
	var businessPermissionList=EnumHelper.GetKeyValueList<EnumBusinessPermission>()
	this.ViewBag.BusinessPermissionList=new SelectList(businessPermissionList,"Key","Value");
	var model=new Role();
	return View("Edit",model);
}

[Auditable]
[Table("Role")]
public class Role:ModelBase
{
	[Required(ErrorMessage="角色名不能为空")]
	public string Name{get;set;}
	public string Info{get;set;}
	public virtual List<User> Users{get;ste;}
	public string BusinessPermissionString{get;set;}
	
	[NotMapped]
	public List<EnumBusinessPermission> BusinessPermissionList{
		get{
			if(string.IsNullOrEmpty(BusinessPermissionString)){
				return new List<EnumBusinesPermission>();
			}else{
				return BusinessPermissionString.Split(",".ToCharArray()).Select(p=>(int)p).Cast<EnumBusinessPermissionList>().ToList();
			}
		}
		set{
			this.BusinessPermissionString=string.Join(",",value.Select(p=>(int)p));
		}
	}
}
[Auditable]
[Table("Role")]
public class Role:ModelBase
{
	[Required(ErrorMessage="角色名不能为空")]
	public string Name{get;set;}

	public string Info{get;set;}

	public virtual List<User> Users{get;set;}

	public string BusinessPermissionString{get;set;}

	[NotMapped]
	public List<EnumBusinessPermission> BusinessPermissionList{
		get{
			if(string.IsNullOrEmpty(BusinessPermissionString)){
				return new List<EnumBusinessPermission>();
			}else{
				return BusinessPermissionString.Split(','.ToCharArray()).Select(p=>int.Parse(p)).Cast<EnumBusinessPermission>().ToList();
			}
		}
		set{
			string.Join(",",value.Select(p=>(int)p));
		}
	}
}

public ActionResult Create(){
	var businessPermissionList=EnumHelper.GetKeyValueList<EnumBusinessPermission>()
		ViewBag.BusinessPermissionList=new SelectList(businessPermissionList,"key","value");
	var model=new Role();
	return View("Edit",model);
}

public ActionResult Create(){
	var businessPermissionList=EnumHelper.GetBusinessPermissionList<EnumBusinessPermission>();
	ViewBag.BusinessPermssionList=new SelectList(businessPermissionList,"keys","values");
	var model=new Role();
	return View("Edit",model);
}
<div class='porlet-body form-horizontal form-bordered form-row-stripped'>
<div class='row-fluid'>
	<div class='control-group'>
		<div class='control-label'><span class='required'>*</span>角色名</label>
		<div class='controls'>
			@Html.TextBoxFor(m=>m.Name,new{@class='m-wrap small'})
			<span class='help-inline'>@Html.ValidationMessageFor(m=>m.Name)</span>
		</div>
	</div>
	<div class='control-group'>
		<label class='control-label'>描述：</label>
		<div class='controls'>
			@Html.TextBoxFor(m=>m.Info,new{@class='m-wrap small'})
			<span class='help-inline'>
				@Html.ValidationMessageFor(m=>m.Info)
			</span>
		</div>
	</div>
	<div class='control-group'>
		<label class='control-label'>权限：</label>
		<div class='controls'>
			@Html.CheckBoxList("BusinessPermissionList");
		</div>
	</div>
</div>
</div>

var businessPermissionList=EnumHelper.GetBusinessPermissonlist<EnumBusinessPermissionlist>();

public enum EnumBusinessPermission
{
	None=0;
	AccountManager_User=101;
	AccountManager_Role=102;
	CmsManager_Article=201;
	CmsManager_Channel=202;
	CrmManage_VisiRecord=301;
	CrmManage_Customer=302;
	CrmManage_Project=303;
	CrmManage_Analysis=304;
}

public enum EnumBusinessPermission{
	[EnumTitle("[无]",IsDisplay=false)]
	None=0;
	[EnumTitle("管理用户")]
	AccountManage_User=101;
	[EnumTitle("管理角色")]
	AccountManage_Role=102;
}
public class EnumTitleAttribute:Attribute
{
	public bool _isDisplay=true;
	
	public EnumTitleAttribute(string title,params string[] synonyms){
		Title=title;
		Sysnonyms=synonyms;
		Order=int.MaxValue;
	}
	public string Title{get;set;}
	
	public string Letter{get;set;}
	public string Description{get;set;}

	public bool IsDisplay{get{return this._isDisplay;}set{this._isDisplay=value;}}
	public int Category{get;set;}
	public int Order{get;set;}
	public string[] Sysnonyms{get;set;}
}
//
public class EnumTitleAttribute:Attribute
{
	public EnumTitleAttribute(string Title,params string[] sysnonyms){
		this.Title=title;
		Sysnonyms=sysnonyms;
		Order=int.MaxValue;
	}
	public bool _isDisplay=true;
	public bool IsDisplay{get{return _isDisplay;}set{this._isDisplay=value;}}
	public bool Title{get;set;}
	public string[] Sysnonyms{get;set;}
	public string Letter{get;set;}
	public string Description{get;set;}
	public string Order{get;set;}
	public int Category{get;set;}
}

public class EnumHelper
{
	public static Dictionary<int,string> GetItemValueList<T>(Enum language=null) where T:struct{
		return GetItemValueList<T,int>(false,language);
	}
	public static Dictionary<TKey,string> GetItemValueList<T,TKey>(bool isAll,Enum language=null)where T:struct{
		if(!typeof(T).IsEnum){
			throw new Exception("参数必须是枚举！");
		}
		Dictionary<TKey,string> ret=new Dictionary<TKey,string>();
		var titles=EnumHelper.GetItemAttributeList<T>().OrderBy(t=>t.Order);
		foreach(var t in titles){
			if(!isAll&&(!t.IsDisplay()||t.Key.ToString()=="None")){
				continute;
			}
			if(t.key.ToString()=="None"&&isAll){
				ret.Add((TKey)(object)t.Key,"全部");
			}else{
				if(!string.isNullOrEmpty(t.Value.Title)){
					ret.Add((TKey)(object)t.Key,t.Value.Title);
				}
			}

		}
		return ret;
	}
	public static Dictionary<T,EnumTitleAttribute> GetItemAttributeList<T>(Enum language=null) where T:struct{
		if(!typeof(T).IsEnum){
			throw new Exception("参数必须是枚举");
		}
		Dictionary<T,EnumTitleAttribute> ret=new Dictionary<T,EnumTitleAttribute>();
		Array arr=typeof(T).GetEnumValues();
		for(object t in arr){
			EnumTitleAttribute att=GetEnumTitleAttribute(t as Enum,language);
			if(att!=null){
				ret.Add((T)t,att);
			}
		}
		return ret;
	}
	public static EnumTitleAttribute GetEnumTitleAttribute(Enum e,Enum language=null){
		if(e==null){
			return null;
		}
		string[] valueArray=e.ToString().Split(',');
	}

}

写不下去了。
public ActionResult Create(){
	var businessPermissionList=EnumHelper.GetItemValueList<EnumBusinessPermissionList>();
	ViewBag.BusinessPermissionList=new SelectList(businessPermissionList,"keys","values");
	var model=new Role();
	return View("Edit",model);
}
//

public ActionResult Create(){
	var businessPermissonList=EnumHelper.GetItemValueList<EnumBusinessPermission>();
	ViewBag.BusinessPermissionList=businessPermissionList;
	var model=new Role();
	return View("Edit",role);
}
public ActionResult Index(RoleRequest request){
	var result=this.AccountService.GetRoleList(request);
	return View(result);
}
<td>
	@StringUtil.CutString(string.Join(",",m.BusinessPermissionList.Select(m=>EnumGetEnumTitle(m))),40);
</td>

public class EnumHelper
{
	public static string GetEnumTitle(Enum e,Enum language=null){
		if(e==null){
			return "";
		}
		string[] valueArray=e.ToString().Split(',',StringSplitOptions.RemoveEmptyEntries);
		Type type=e.GetType();
		string ret="";
		foreach(string enumValue in valueArray){
			FieldInfo fi=type.GetField(enumValue.Trim());
			if(fi==null){
				continute;
			}
			EnumTitleAttribute[] attrs=fi.GetCustomeAttributes(typeof(EnumTitleAttribute),false) as EnumTitleAttribute;
			if(attrs!=null&&attrs.length>0&&attrs[0].IsDisplay){
				ret+=attrs[0].Title+",";
			}
		}
		return ret.TrimEnd(',');
	}
}

checkbox ,获取选中的枚举的Title值。

public static string GetEnumTitle(Enum e,Enum language=null)
{
	if(e==null){
		return "";
	}
	string[] valueArray=e.ToString().Split(",".ToCharArray(),StringSplitOptions.IgnoreEmptyEntries);
	Type type=e.GetType();
	string ret="";
	foreach(string enumValue in valueArray){
		FieldInfo fi=type.GetField(enumValue.Trim());
		if(fi==null){
			continue;
		}
		EnumTitleAttribute[] attrs=fi.GetCustomAtttributes(typeof(EnumTitleAttribute),fase) as EnumTitlesAttrbute[];
		if(attrs!=null&&attrs.Length>0&&attrs[0].IsDisplay){
			ret+=attrs[0].Title+',';
		}
	}
	return ret;
}

进度表，有问题。
栈的操作
public interface IStack<T>
{
	T Pop();
	void Push(T item);
	void Clear();
	void GetTop();
	int GetLength();
}
栈分为两种
	顺序栈
	链栈
栈分为两种
	顺序栈
	链栈
顺序栈
public class SeqStack<T>:IStack
{
	private T[] data;
	public int maxSize;
	public int top;

	public T Data{
		get{
			return this.data;
		}
		set{
			this.data.value;
		}
	}

	pubkic int MaxSize{
		get{
			return maxSize;
		}
		set{
			this.maxSize=value;
		}
	}
	public SeqStack(int size){
		data=new T[size]
	}
}
链栈 
public class LinkedStack<T>:IStack
{
	
	public Node<T> top{get;set;}
	public int num{get;set;}

	public Node<T> Top{
		get{return this.top;}
		set{this.top=value;}
	}
	public int Num{
		get{return this.num;}
		set{this.num=value;}
	}
	public bool isEmpty(){
		if(top==null&&num=-1){
				return true;
		}else{
				return false;
		}
	}

	public void Clear(){
		this.num=-1;
	}
	public void GetLength(){
		return this.num+1;
	}
	public T Pop(){
		if(isEmpty()){
			Console.WriteLine("SeqStack Empty");
			return default(T);
		}
		var q=top;
		top=top.Next;
		return top.Data;
	}
	public void Push(T item){
		if(isEmpty()){
			top=item；
		}
		Node<T> q=new Node<T>(item);
		q.Next=top;
		top=q;
	}
	public T GetTop(){
		if(isEmpty()){
			Console.WriteLine("SeqStack Empty");
			return default(T);
		}
		return top.Data;
	}
}

public class RoleController:AdminController
{
	public ActionResult Index(RoleRequest request){
		var roles=this.AccountService.GetRoleList(request);
		return View(result);
	}
	public ActionResult Create(){
		var businessPermissions=EnumHelper.GetItemValueList<EnumPermissionList>();
		ViewBag.BusinessPermissionList=new SelectList(businessPermissionList,"key","value");
		var role=new Role();
		return View("Edit",role);
	}

	[HttpPost]
	public ActionResult Create(FormCollection collection){
		var model=new Role();
		this.TryUpdateModel<Role>(model);
		this.AccountService.SaveRole(model);
		return this.RefreshParent();
	}

	public ActionResult Edit(int id){
		
	}
}