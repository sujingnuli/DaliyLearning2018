
//通过反射 获取 内容

public class AssemblyHelper
{
	public static T GetTypeByInterface<T>(string searchPattern="*.dll") where T:class{
		var interfaceType=typeof(T).Name;
		var domain=GetBaseDirectory();
		var dllFiles=Directory.GetFiles(domain,searchPattern,SearchOption.TopDirectoryOnly);
		foreach(var dllFile in dllFiles){
			foreach(Type in Assembly.LoadFrom(dllFile).GetLoadableTypes()){
				if(interfaceType!=type&&interfaceType.IsAssignableFrom(type)){
					var instance=Activator.Create(type);
					return instance;
				}
			}
		}
		return null;
	}
	public static IEnumerable<T> GetLoadableTypes(this Assembly assembly){
		if(assembly==null){throw ArgumentNullException("assembly");}
		try{
			return assembly.GetTypes();
		}catch(ReflectionLoadTypeException e){
			return e.Types.Where(e=>e!=null);
		}
	}
	public static string GetBaseDirectory(){
		var baseDirectory=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInforamtion.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirectory;
		}
		return baseDirectory;
	}
}

//从 本地 dll文件，根据Interface 创建Type
public class Assembly
{
	public static T GetTypeByInterface<T>(string searchPattern="*.dll")where T:class{
		var interfaceName=typeof(T).Name;
		var baseDirectory=GetBaseDirectory();
	}
	public static string GetBaseDirectory(){
		var baseDirectory=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirectory;
		}
		return baseDirectory;
	}
}


public class AssemblyHelper
{
	public static T FindTypeByInterface<T>(string searchPattern="*.dll") where T:class{
		var interfaceName=typeof(T);
		var baseDomain=GetBaseDirectory();
		string[] dllFiles=Directory.GetFiles(baseDomain,searchPattern,SearchOption.TopDirectoryOnly);
		foreach(var dllFile in dllFiles){
			foreach(Type type in Assembly.LoadFrom(dllFile).GetLoadableTypes()){
				if(type!=type&&interfaceType.IsAssignableFrom(type)){
					return Activator.CraeteInstance(type);
					
				}
			}
		}
		return null;
	}
	public static IEnumerable<T> GetLoadableTypes(this Assmebly assembly){
		if(assembly==null) throw new ArgumentNullException("assembly");
		try{
			return assembly.GetTypes();
		}catch(ReflactionTypeLoadException e){
			return e.Types.Where(t=>t!=null);
		}
	}
	public static string GetBaseDirectory(){
		var baseDirectory=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirectory;
		}
		return baseDirectory;
	}
}

要继承Exception ,jiu 
new BusinessException();---- Name:"error",message:String.Empty
new BusinessException("错了哦")--Name:"error",message:"错了哦"
new BusinessException("Account","账户名为空")--Name:"Account",message:"账户名为空"
new BusinessException("账户错了呢",-1)-- Name:"error",message="账户错了呢",errorCode=-1
new BusinessException("Account","账户错了呢",-1)--Name:"Account",message:"账户错了呢",errorCode=-1
public class BusinessException:Exception 
{
	public BusinessException():this(string.Empty){
		
	}
	public BusinessException(string message):this("error",message){
	
	}
	public BusinessException(string name,string messpage):base(message){
		this.Name=name;
	}
	public BusinessException(string message,Enum errorCode):this("error",message,errorCode){
		
	}
	public BusinessException(string name,string message,Enum errorCode):base(message){
		this.Name=name;
		this.ErrorCode=errorCode;
	}

	public string Name{get;set;}
	public Enum ErrorCode{get;set;}
}

public class BusinessException:Exception
{
	public BusinessException():this(string.Empty){
	
	}
	public BusinessException(string message):this("error",message){
	
	}
	public BusinessException(string name,string message):base(message){
		this.Name=name;
	}
	public BusinessException(string message,Enum errorCode):this("error",message,errorCode){
		
	}
	public BusinessException(string name,string message,Enum businessException):base(message){
		this.Name=name;
		this.ErrorCode=errorCode;
	}
	public string Name{get;set;}
	public Enum ErrorCode{get;set;}
}

public abstract class ServiceFactory
{
	public abstract T CreateService<T>() where T:class;
}
//通过引用方式返回Service
//给我接口，找个类，然后返回给你。就是Service层。
public class RefServiceFactory:ServiceFactory
{
	public override T CreateService<T>()where T:class{
		return CacheHelper.Get<T>(string.Format("Service_{0}",typeof(T).Name),()=>{
			return AssemblyHelper.FindTypeByInterface<T>();
		});
	}
}
public static class AssemblyHelper
{
	public static T FindTypeByInterface<T>(string searchPattern="*.dll")where T:class{
		var interfaceType=typeof(T);
		var baseDomain=GetBaseDoamin();
		string[] dllFiles=Directory.GetFilles(baseDomain,searchPattern,SearchOption.TopDirectoryOnly);
		foreach(var dllFile in dllFiles){
			foreach(Type type in Assembly.LoadFrom(dllFile).GetLoadableTypes()){
				if(interfaceType!=type&&interfaceType.IsAssignableFrom(type)){
					return Activator.CreateInstance(type);
				}
			}
		}
		return null;
	}
	public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly){
		if(assembly==null) throw new ArgumentNullException("assembly");
		try{
			return assembly.GetTypes();
		}catch(ReflectionTypeLoadException e){
			return e.Types.Where(t=>t!=null);
		}
	}
	public static string GetBaseDomain(){
		var baseDomain=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath==null){
			baseDomain=AppDomain.CurrentDomain.BaseDirectory;
		}
		return baseDomain;
	}
}
//通过注入方式返回Service层
public class ServiceHelper
{
	private static ServiceFactory serviceFactory=new RefServiceFactory();
	public static T CreateService<T>()where T:class{
			var service=serviceFactory.CreateService<T>();
			var generator=new ProxyGenerator();
	}
}

public class ServiceHelper
{
	private static ServiceFactory serviceFactory=new RefServiceFactory();
	public static T CreateService<T>()where :class{
		var service=serviceFactory.CreateService<T>();

		//做拦截器，对方法进行拦截，做日志记录。AOP 。异常的一直记录，把异常摘录出来
		//Castle.Core.dll Castle AOP 
		var generator=new ProxyGenerator();
		var dynamicProxy=generator.CreateInterfaceProxyWithTargetInterface<T>(service,new InvokeInterceptor());
		return dynamicProxy;
	}

}
internal class InvokeInterceptor:IInterceptor
{
	public InvokeInterceptor(){
	
	}
	public void Intercept(IInovation invocation){
		try{
			invocation.Proceed();
		}catch(Exception e){
			if(Exception is BusinessException)
				throw;
			var message=new{
				exception=exception.Message,
				exceptionContent=new{
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