
public class WebBaseController:Controller
{
	public IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
	public ICmsService CmsService{
		get{
			return ServiceContext.Current.CmsService;
		}
	}
}
//GMS.Web
public class ServiceContext
{
	public static ServiceContext Current{
		get{
			return CacheHelper.Get<ServiceContext>("ServiceContext",()=>{
				new ServiceContext()
			});
		}
	}

	public IAccountService AccountService{
		get{
			return ServiceHelper.CreateSevice<IAccountService>();
		}
	}
	public ICmsService CmsService{
		get{
			return ServiceHelper.CreateService<ICmsService>();
		}
	}
}
//GMS.Core.Service 
public class ServiceHelper
{
	public static ServiceFactory serviceFactory=new RefServiceFactory();

	public static T GetService<T>()where T:class{
		var service=serviceFactory.CreateService<T>();
		var generator=new ProxyGenerator();
		var dynamicProxy=generator.CreateInterfaceProxyWithTargetInterface<T>(service,new InvokeInterceptor());
		return dynamicProxy;
	}


}
internal class InvokeInterceptor:IInterceptor
{
	public InvokeInterceptor(){
	
	}
	public void Intercept(IInvocation invocation){
		try{
			invocation.Proceed();
		}catch(Exception exception){
			if(exception is BusinessException) throw; //�����ҵ��exception .ֱ��throw .
			var message=new{
				exception=exception.Message,
				exceptionContext=new{
					method=invocation.Method.ToString(),
					arguments=invocation.Arguments,
					returnValue=invocation.ReturnValue
				}
			};
			Log4NetHelper.Error(LoggerType.ServiceExceptionLog,message,exception);
			throw;
		}
	}
}

public abstract class ServiceFactory
{
	public abstract T CreateService<T>() where T:class;
}
public class RefServiceFactory:ServiceFactory
{
	public T CreateService<T>()where T:class{
		var interfaceName=typeof(T).Name;
		return CacheHelper.Get<T>(string.Format("Service_{0}",interfaceName),()=>{
			AssemblyHelper.GetTypeByInterface<T>();
		});
	}
}
//GMS.Framework.Utiliy
public class AssemblyHelper
{
	public static T GetTypeByInterface<T>(string searchPattern="*.dll"){
		var interfaceType=typeof(T);
		var domain=GetBaseDirectory();
		var dllFiles=Directory.GetFiles(domain,searchPattern,SearchOptions.TopDirectoryOnly);
		foreach(var fileName in dllFiles){
			foreach(Type type in Assembly.LoadForm(fileName).GetLoadableTypes()){
				if(type!=interfaceType&&interfaceType.isAssignForm(type)){
					return Activator.CreateInstance(type) as T;
				}
			}
		}
		return null;
	}
	public static IEnumerable<T> GetLoadableTypes(this Assembly assembly){
		if(assembly==null){
			throw new ArgumentNullException("assembly");
		}
		try{
			return assembly.GetTypes();
		}catch(Exception e){
			return e.Types.Where(t=>t!=null);
		}
	}
	public static string GetBaseDirectory()
	{
		var baseDirectory=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirectory;
		}
		return baseDirectory;
	}
}
IAuditable:����Ƶģ�������


public class AuditLog:ModelBase
{
	public int ModelId{get;set;}
	public string UserName{get;set;}
	public string ModuleName{get;set;}
	public string TableName{get;set;}
	public string EventType{get;set;}
	public string NewValues{get;set;}
}
//GMS.Framework.Contract .�������
public interface IAuditable
{
}

���Ա� ����������ݽṹ ��
���Ա��Ƕ��������ݽṹ�ĳ���Abstract .
���ݽṹ��	
	�߼��ṹ
	�洢�ṹ

DbContext.
DbContext��

T Find<T>(params object[] keyValues) where T:ModelBase;

//����û���Ϣ
public class UserController:ComBaseController
{
	public ActionResult Index(){
		//�û��ļ�¼��Ϣ
		//�û���Ȩ����Ϣ

		return View();
	}

	public ActionResult Create(){
		
	}
}
public class ComBaseController
{
	public AdminCookieContext CookieContext{
		get{
			return AdminCookieContext.Current;
		}
	}
	
	public AdminUserContext UserContext{
		get{
			return AdminUserContext.Current;
		}
	}

	public CachedConfigContext ConfigContext{
		get{
			return CachedConfigContext.Current;
		}
	}

	public override int PageSize{
		get{
			return 12;
		}
	}

	public override Operater Operater{
		get{
			return new Operater{
				Name=this.LoginInfo==nulll?"";
			}
		}
	}
}
//GMS.Framework.Web
protected override void OnActionExecuting(ActionExecutingContext filterContext){
	this.UpdateOperater(filterContext);
	base.OnActionExecuting(filterContext);
	filterContext.ActionParameters.Values.Where(v=>v I)
}
public class UserController:ComBaseController
{
	//��ȡ�û��б�
	public ActionResult Index(UserRequest request){
		var result=this.AccountService.GetUserList(request);
		return View(result);
	}

	public ActionResult Index(UserRequest request){
		var result=this.AccountService.GetUserList(request);
		return View(result);
	}
}

//IAccountSerivce 
public interface IAccountService{
	IEnumerable<User> GetUserList(UserRequest request=null);
}



public class UserController:ComBaseController{
	public ActionResult Index(){
		//��ȡ�û��б�
		var result=this.AccountService.GetUserList();
		return View(result);
	}	
}

public interface IAccountService
{
	IEnumerable<User> GetUserList(UserRequest request=null);
}
public class UserRequest:Request
{
	public string LoginName{get;set;}
	public string Mobile{get;set;}
}
public class AccountService:IAccountService
{
	public IEnumerable<User> GetUserList(UserRequest request=null){
		request=request??new UserRequest();
		using(var dbContext=new UserDbContext()){
			
		}
	}
}

