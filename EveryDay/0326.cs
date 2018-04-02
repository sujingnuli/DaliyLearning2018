1.��ʼ������
public class Game
{
	public function Game(){
		Laya.init(1000,800);
		Laya.loader.load({url:"/res/atlas/comp.atlas",type:Loader.ATLAS},Handler.create(this,onLoaded));
	}
	private function onLoaded():void{
		//��Դ������ɺ󣬼��ؽ���
		Laya.stage.addChild(new MyPage());
	}
}
public class MyPage:MyPageUI
{
	public function MyPage(){
		btn.on("click",this,onClicked);
	}
	private function onClicked(e:*=null):void{
		inputBox.dataSource={inputName:{text:"Hello world!",color:"#ff0000"},inputPwd:{text:"WELCOME ",bold:true}};
		var arr:Array=[];
		for(int i:int=0;i<100;i++){
			arr.push({label:"item"+i});
		}
		tList.array=arr;
		tlist.renderHandler=new Handler(this,onListRender);
	}
	private function onListRender(box:Box,index:int):void{
		var clip:Clip=box.getChildByName("Clip") as Clip;
		clip.index=index%9;
	}
}

public class MyPage:MyPageUI
{
	public function MyPage(){
		btn.on("click",Handler.create(this,onClicked));
	}
	private function onClicked(e:*=null):void{
		inputBox.dataSource={input1:{text="Hello world!",color:"#ff0000"},inputPwd:{text:"Welcome to Here",bold:true}};
		var arr:Array=[];
		for(var i:int=0;i<100;i++){
			arr.push({label:"item"+i});
		}
		tList.array=arr;
		tList.renderHandler=new Handler(this,onListHandler);
	}
	private function onListHanlder(box:Box,index:int):void{
		var clip:Clip=box.getChildByName("Clip") as Clip;
		clip.index=index%9;
	}
}

public class MyPage:MyPageUI
{
	public function MyPage(){
		btn.on("click",Handler.create(this,onClicked))
	}
	private function onClicked(e:*=null):void{
		inputBox.dataSource={inputName:{text:"Hello world!",color:"#ff00000"},inputPwd:{text:"Welcome",bold:true}};
		var arr:Array=[];
		for(var i:int=0;i<100;i++){
			arr.push({label:"item"+i});
		}
		tList.array=arr;
		tList.renderHandler=new Handler(this,onListRender);
	}
	private function onListRender(box:Box,index:int):void{
		var clip=box.getChlidByName("Clip") as Clip;
		clip.index=index%9;
	}

}


3dģ�͵�����
ʵ�ֲ��裺
1.ʹ��3DMax ��ģ�ͣ�����Ϊfbx��ʽ
2.ʹ��Laya��FBXת�����򹤾ߣ���FBXTools����������FBX�ļ�ת��ΪLayaAir��ʶ��ĸ�ʽ��
3.��ת�����ļ����Ƶ�ָ�����ļ�Ŀ¼��
4.��Laya�е����ļ���������������ơ�


���ݽṹ��
10��00-11��00 


�ݹ飺
	һ���㷨 �������Լ���������Ĳ��ֹ��� ���� ���ĳЩ����ʱ ��һ���㷨��Ҫ��������

дһ���׳˺�����c#����ʵ��

int num=n;
int sum=0;
public static void Mul(int num){
	sum=num*Mul(num-1);
	return sum;

}

��� n=0;n!=1;

public static long fact(int n){
	if(n<=1){
		return 1;
	}else{
		return n*fact(n-1);
	}
}

public static long fact(int n){
	if(n<=1){
		return 1;
	}else{
		return n*f(n-1);
	}
}

public interface IBook
{
	void ShowBook();
	string GetTitle();
	int GetPages();
	void SetPages(int pages);
}
public class NewBook:IBook
{
	public string Title;
	public int pages;
	public string author;

	public NewBook(string title,string author,int pages){
		this.Title=title;
		this.author=author;
		this.pages=pages;
	}
	public string GetTitle(){
		return title;
	}
	public string GetPages(){
		return pages;
	}
	public void SetPages(){
		this.pages=pages;
	}
	public void ShowBook(){
		Console.WriteLine("Title:{0}",title);
		Console.WriteLine("pages:{0}",pages);
	}
}

public class App
{
	static void Main(){
		var book=new Book("12","23",23);
		book.Show();
	}
}
//���ͱ�̡�
GMS.Core.Service .
ͨ���������Service��ͨ��ServiceFactory ����Service .
public abstract class ServiceFactory 
{
	public abstract T CreateService<T>()where T:class;
}
public class RefServiceFactory:ServiceFactory
{
	public T createService<T>(){
		var interfaceName=typeof(T).Name;
		return CacheHelper.Get<T>(string.Format("Service_{0}",interfaceName),()=>{
			return AssemblyHelper.FindByInterface<T>();
		});
	}
}

public class AssemblyHelper
{
	//ɨ����򼯣��ҵ�ʵ����ĳ���ӿڵĵ�һ��ʵ����
	public static T FindTypeByInterface<T>(string searchPattern="*.dll") where T:class{
		var interfaceType=typeof(T);
		string domain=GetBaseDirectory();
		string[] dllFiles=Directory.GetFiles(domain,searchPattern,SearchOption.TopDirectoryOnly);
		foreach(string dllFileName in dllFiles){
			foreach(Type type in Assembly.LoadForm(dllFileName).GetLoadableTypes()){
				if(interfaceType!=type&&interfaceType.IsAssignableForm(type)){
					var instance=Activator.CreateInstance(type) as T;
					return instance;
				}
			}
		}
		return null;
	}
	//��ȡdll�е�Types
	public static IEnumerable<Type> GetLoadableType(this Assembly assembly){
		if(assembly==null) throw new Exception("asembly");
		try{
			return assembly.GetTypes();
		}catch(ReflecttionTypeLoadException e){
			return e.Types.Where(t=>t!=null);
		}
	}
	public static string GetBaseDirectory(){
		var baseDirectory=AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInfomartion.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirectory;
		}
		return baseDirectory;
	}
}
//��μ���Service 
public abstract class ServiceFactory
{
	public abstract T CreateServcie<T>() where T:class;
}
public class RefServiceFactory:ServiceFactory
{
	public T GetService<T>() where T:class{
		var interfaceName=typeof(T).Name;
		return CacheHelper.Get(string.Format("Service_{0}",interfaceName),()=>{
			return AssemblyHelper.GetTypeByInterface<T>();
		});
	}
}
public class AssemblyHelper{
	public static T GetTypeByInterfaceName<T>(string searchPattern="*.dll") where T:class{
		var interfaceType=typeof(T);
		var domain=GetBaseDirectory();
		var dllFiles=Directory.GetFiles(domain,searchPattern,SearchOption.TopDirectoryOnly);
		foreach(var dllFileName in dllFiles){
			foreach(Type type  in Assembly.LoadForm(dllFileFile).GetLoadableTypes()){
				if(interfaceType!=type&&interfaceType.isAssignableForm(type)){
					return Activator.CreateInstance(type) as T;
				}
			}
		}
		return null;
	}
	public static IEnumerable<T> GetLoadableTypes(this Assembly assembly){
		if(assembly==null) throw new ArgumentNullException("assembly");
		try{
			return assembly.GetTypes();
		}catch(RefelctionTypeLoadException e){
			return e.Types.Where(t=>t!=null);
		}
	}
	public static string GetBaseDirectory(){
		var baseDirectory=AppDmain.CurrentDomain.SetupInformation.PrivateBinPath;
		if(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath==null){
			baseDirectory=AppDomain.CurrentDomain.BaseDirectory();
		}
		return baseDirectory;
	}
} 
//
public partial class ServiceHelper
{
	public static ServiceFactory serviceFactory=new RefServiceFactory();
	
	public static T CreateService<T>() where T:class{
		var service=serviceFactory.CreateService();

		//���أ�����д��־��

	}
}

//GMS.Web
public class ServiceContext
{
	public static ServiceContext Current{
		get{
			return CacheHelper.GetItem<ServiceContext>("ServiceContext",()=>new ServiceContext());
		}
	}
	public IAccountService AccountService{
		get{
			return ServiceHelper.CreateService<IAccountService>();
		}
	}
}

public class WebControllerBase:ControllerBase
{
	public virtual IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
	public virtual ICmsService CmsService{
		get{
			return ServiceContext.Current.CmsService;
		}
	}
}
//GMS.Web
public class ServiceContext
{
	public static ServiceContext Currrent{
		get{
			return CacheHelper.GetItem<ServiceContext>("ServiceContext",()=>{
				new ServiceContext();
			});
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

	public static T CreateService<T>()where T:class{
		var service=serviceFactory.CreateService<T>();
		//���أ�д��־
		var generator=new ProxyGenerator();
		var dynamicProxy=generator.CreateInterfaceProxyWithTargetInterface<T>(service,new InVokeInterceptor());
		return dynamicProxy;
	}
}

//castle 
Castle AOP :���෽�� ���õ����ء�

Castle 2.5 ���ϵİ汾�У��Ѿ��� Castle.DynamicProxy2.dll ������ ������ ��Castle.Core.dll��

ProxyGenerator ��һ����̬�� ���͹������� �������͡�������Ӧ�� ������  �����һ���µ����͡�
Castle.Core.dll 
ProxyGenerator 
var generator=new ProxyGenerator();
var dynamicProxy=generator.CreateInterfaceProxyWithTargetInterface<T>(SERVICE,new InvokeInterceptor());
return dynamicProxy;

internal class InvokeInterceptor:IInterceptor
{
	public InvokeInterceptor(){
	
	}

	public void Intercept(IInvocation invocation){
		try{
			invocation.Proceed();
		}catch(Exception exception){
			if(exception is BusinessException) throw;
			var message=new {
					exception=Exception.Message,
					exceptionContext=new{
						method=invocation.Method.ToString(),
						arguments=invocation.Arguments,
						returnValue=invocation.ReturnValue
					}
			}
		}
		Log4NetHelper.Error(LoggerType.ServiceExceptionLog,message,exception);
	}

}
//AOP 
castle  dynamic Proxy ��̬�����Է����������أ�����ǰ������¼�쳣��Ϣ����¼��־��Ϣ�ȡ�
�˴����Ƕ��쳣�����˴���

public class WebControllerBase:FrameControllerBase
{
	public IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
}
//GMS.Web
public class ServiceContext
{
	public static ServiceContext Current{
		get{
			return CacheHelper.GetItem<ServiceContext>("ServiceContext",()=>new ServiceContext());
		}
	}

	public IAccountService AccountService{
		get{
			return ServiceHelper.CreateService<IAccountService>();
		}
	}
}
//GMS.Core.Service 
public class ServiceHelper
{
	public static ServiceFactory serviceFactory=new RefServiceFactory();

	public static T CreateService<T>() where T:class{
		var service=serviceFactory.CreateService<T>();
		var generator=new ProxyGenerator();
		var dynamicProxy=generator.CreateInterfaceProxyWithTargetInterface<T>(service,new InvokeInterceptor());
	}
}
internal class IInvokeInterceptor:IInterceptor
{
	public void Intercept(IInvocation invocation){
		try{
			invocation.Proceed();
		}catch(Exception exception){
			if(exception is BusinessException) throw;
			var message=new{
				exception=exception.Message,
				exceptionContext=new{
					method=invocation.Method.ToStrng(),
					arguments=invocation.Arguments,
					returnValue=invocation.ReturnValue
				}
			}
		}
		Log4NetHelper.Error(LoggerType.ServiceExceptionLog,message,exception);
	} 
}
//ServiceFactory
public abstract class ServiceFactory
{
	public abstract T CreateService<T>() where T:class;
}
public class RefServiceFactory:ServiceFactory
{
	public T CreateService<T>()where T:class{
		var interfaceName=typeof(T).Name;
		return CacheHelper.Get<T>("Service_"+interfaceName,()=>{
			AssemblyHelper.GetTypeByInterface<T>();
		});
	}
}

castle .
public class WebControllerBase
{
	public IAccountService AccountService{
		get{
			return ServiceContext.Current.AccountService;
		}
	}
}

//GMS.Web
public class ServiceContext
{
	public static ServiceContext Current{
		get{
			return CacheHelper.Get<ServiceContext>("ServiceContext",()=>{
				return new ServiceContext();
			});
		}
	}
	public IAccountService AccountService{
		get{
			return ServiceHelper.CreateService<IAccountService>();
		}
	}
}
//GMS.Core.Service 
public class ServiceHelper
{

}