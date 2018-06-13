
Cache .

ICacheManager
public interface ICacheManager{
	T Get<T>(string key);
	void Set<T>(string key,T entity,TimeSpan cacheTime);
	void Clear();
	void Remove(string key);
	bool Contains(string key);
}

//MemoryCacheManager .cs

public class MemoryCacheManager:ICacheManager{
	public T Get<T>(string key){
		return (T)MemoryCache.Default.Get(key);
	}
	public void Set<T>(string key,T entity,TimeSpan cacheTime){
		MemoryCache.Default.Add(key,entity,new CacheItemPolicy(){SlidingExpiration=cacheTime});
	}
	public void Remove(string key){
		MemoryCache.Default.Remove(key);
	}
	public void Clear(){
		foreach(var item in MemoryCache.Default){
			this.Remove(item.Key);
		}
	}
	public bool Contains(string key){
		return MemoryCache.Default.Contains(key);
	}
}
//Redis cache
public class RedisCacheManager:ICacheManager
{
	private readonly string redisConnectionString;
	private volatile ConnectionMultiplexer redisConnection;
	private readonly object redisConnectionLock=new object();

	public RedisCacheManager(){
		string redisConfiguration=ConfigurationManager.ConnectionStrings["RedisCache"].ToString();
		if(string.IsNullOrEmpty(redisConfiguration)){
			throw new ArgumentNullException("redis config is empty",nameof(redisConfiguration));
		}
		this.redisConnectionString=redisConfiguration;
		this.redisConnection=GetRedisConnection();
	}

	private ConnectionMultiplexer GetRedisConnection(){
		if(this.redisConnection!=null&&this.redisConnection.IsConnected){
			return redisConnection;
		}
		lock(redisConnectionlock){
			if(this.redisConnection!=null){
				this.redisConnection.Dispose();
			}
			this.redisConnection=ConnectionMultiplexer.Connection(redisConnectionString);
		}
		return this.redisConnection;
	}
	public T Get<T>(string key){
		var value=redisConnection.GetBase().StringGet(key);
		if(value.HasValue){
			return SerializeHelper.Deserialize<T>(key);
		}else{
			return default(T);
		}
	}
	public void Set<T>(string key,T entity,TimeSpan cacheTime){
		redisConnection.GetDatabase().StringSet(key,SerialzierHelper.Serialize(value),cacheTime);
	}
	public void Remove(string key){
		redisConnection.GetDatabase().KeyDelete(key);
	}
	public void Clear(){
		foreach(var endPoint in this.RedisConnection().GetEndPoints()){
			var server=this.GetRedisConnection().GetServer(endPoint);
			foreach(var key in server.Keys()){
				redisConnection.GetDatabase().KeyDelete(key);
			}
		}
	}
	public bool Contains(string key){
		return redisConnection.GetDatabase.KeyExists(key);
	}
}

public class RedisCacheManager:ICacheManager
{
	private readonly string redisConnectionString;
	public volatile ConnectionMultiplexer redisConnection; 
	private readonly object redisConnectionLock=new object();

	public RedisCacheManager(){
		var redisConfugiration=ConfigurationMangaer.ConnectionStrings["RedisCache"].ToString();
		if(string.IsNullOrEmpty(redisConfiguration)){
			throw new ArgumentNulLException("redis configuration is null",nameof(redisConfiguration));
		}
		redisConnectionString=redisConfiguration;
		redisConnection=GetRedisConnection();
	}
	private ConnectionMultiplexer GetRedisConnection(){
		if(redisConnection!=null&&redisConnection.IsConection){
			return redisConnection;
		}else{
			lock(redisConnectionLock){
				if(redisConnection!=null){
					redisConnection.Dispose();
				}
				redisConnection=ConnectionMultiplexer.Connect(redisConnectionString);
			}
			return resiConnection;
		}

	}
	
	public T Get<T>(string key){
		var value= redisConnection.GetDatabse().StringGet(key);
		if(value.HasValue){
			return SerializeHelper.Deserialize<T>(Value);
		}else{
			return default(T);
		}
	}
	public void Set<T>(string key,T entity,TimeSpan cacheTime){
		redisConnection.GetDatabase.StringSet(key,entity,new CacheItemPolicy(){SlidingExpiration=cacheTime});
	}
	public void Remove(string key){
		redisConnection.GetDatabase().KeyDelete(key);
	}
	public void Clear(){
		foreach(var endPoint in this.GetRedisConnection().GetEndPoints()){
			var server=this.GetRedisConnection().GetServer(endPoint);
			foreach(var key in server.Keys){
				redisConnection.GetDatabase.KeyDelete(key);
			}
		}
	}
	public bool Contains(string key){
		return redisConnection.GetDatabase().KeyExists(key);
	}
}


//�������

public class CacheMgr
{
	public static T GetData<T>(string cacheKey){
		return HttpRuntime.Cache[cacheKey];
	}
	public static void SetData(string key,object val){
		HttpRuntime.Cache[key]=val;
	}
}

//Enum 
public class Enums
{
	//������ajax�����Ժ��Json״̬
	public enum EAjaxState{
		success=0,
		error=1,
		nologin=2
	}
	//�˵�ʹ��״̬
	public enum EState{
		//����
		Normal=0,
		//ͣ��
		Stop=1
	}
}

public class Keys
{
	//���ڴ����֤���session .
	public const string vcode="blogcode";

	//��¼�ɹ����û���Ϣ��session.
	public const string uinfo="bloguinfo";

	//��ŵ�¼�ɹ����û���id��cookie
	public const string IsMember="blogIsMember";

	//����autofac��������
	public const strign AutoFacContainer="crmautofacContainer";

	//�����û��� Ȩ������
	public const string PermissionFunctionsForUser="PermissionFunctionsForUser";
}

public class SerizalizeHelper
{
	public static byte[] Serialize(object item){
		var jsonString=JsonConvet.SerializeObject(item);
		return Encoding.UTF8.GetBytes(jsonString);
	}
	public static T Deseialize<T>(byte[] value){
		if(value==null){
			return default(T);
		}
		var jsonString=Encoding.UTF8.GetString(value);
		return JsonConvert.DeserailzieObject<T>(jsonString);
	}
}
//
public interface ILogger
{
	void Debug(string message);
	void Debug(string message,Exception exception);
	void Error(string message);
	void Error(string message,Exception exception);
	void Fatal(string message);
	void Fatal(string message,Exception exception);
	void Info(string message);
	void Info(string message,Exception exception);
	void Warn(string message);
	void Warn(string message,Exception exception)l
}

public class NLogLogger:ILogger
{
	private readonly Logger logger=LogManager.GetCurrentClassLogger();

	public void Debug(string message){
		logger.Debug(message);
	}
	public void Debug(string message,Exception exception){
		logger.Debug(exception ,message);
	}
	public void Error(string meeesage){
		logger.Error(message);
	}
	public void Error(string message,Exception exception){
		logger.Error(exception ,message);
	}
	//..
}

[AttributeUsage()]
public class SkipCheckLogin:Attribute
{

}


//WebCore 
//Filters
//Attrs 

BaseController
JsonNetResult 
UserMgr

public class UserMgr
{
	public static sysUserInfo GetCurrentUserInfo(){
		if(HttpContext.Current.Request.Cookies[Keys.uinfo]!=null){
			string sessionId=HttpContext.Current.Request.Cookies[Key.uinfo].Value;
			//�ӻ����л�ȡautofac����������
			var cont=CacheMgr.GetData<IContainer>(Keys.AutofacCotnainer);
			//��ȡ������ע������
			ICacheManager cacheManager=cont.Resolve<ICacheManager>();
			return cacheManager.Get<sysUserInfo>(sessionId);
		}
		return new sysUserInfo(){};
	}
}


Autofac  �� һ�� IOC��ܣ��Ƚ�������IOC��� �磬Spring.Net ,Unity,Castle ���������ģ����������ġ�



public class UserMgr
{
	public static sysUserInfo GetCurrentUserInfo(){
		if(HttpContext.Current.Request.Cookies[Keys.uinfo]!=null){
			string sessionId=HttpContext.Current.Request.Cookies[Keys.uinfo].Value;

			var cont=CacheMgr.GetData<IContainer>(Keys.AutofacContainer);

			ICacheManager cacheManager=cont.Resolve<ICacheManager>();

		}
	}
}

Nopcommerce . IOC ��ܣ�ʹ���� autofac . 
�Դ���û�������ԡ����ܺܺá�

���캯��ע�룺


public class AutofacConfig
{
	public static void Register(){
		var builder=new ContainerBuilder();
		//����Autofac ��ܣ�����Ҫ�����Ŀ�������������Ǹ�����
		Assembly controllerAss=Assembly.Load("Wchl.WMBlog.WebUI");
		builder.RegisterControllers(controllerAss);
		
		//����autofac ��� ע�����ݲִ����ڳ�����������Ķ���ʵ��
		Assembly respAss=Assembly.Load("Wchl.WMBLog.Repository");
		builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterface();
	
		//����autofac ��ܣ�ע�� ҵ���߼��� ���� ������ ������Ķ���ʵ��
		Assembly serpAss=Assembly.Load("Wchl.WMBlog.Services");
		builder.RegisterTypes(serpAss.GetTypes()).AsImplementedInterfaces();

		builder.RegisterType<RedisCacheManager>().As<ICacheManager>();





	}
}