1.
StackExchange.Redis.dll
��StackExchange.Redis�У�����Ҫ���ǣ�ConnectionMultiplexer ��
StackExchange.Redis .

ConnectionMultipiexer �����е���֮�䣬�������Ϊ ��������õġ�

��Ӧ��Ϊÿһ������������һ��ConnectionMultiplexer �࣬ConnectionMultiplexer ���̰߳�ȫ�ģ�

�����еĺ���ʾ���У��ٶ� ���Ѿ�ʵ������һ��ConnectionMultiplexer�࣬����һֱ�����á�

public class RedisCacheManager:ICacheManager{
	private readonly string redisConnectionString;
	
	public volatile ConnectionMultiplexer redisConnection;

	private readonly object redisConnectionLock=new object();

	public RedisCacheManager(){
		string redisConfiguration=ConfigurationManager.ConnectionStrings["redisCache"].ToString();
		if(string.IsNullOrEmpty(redisConfiguration)){
			throw new ArgumentException("redis config is empty",,nameof(redisConfiguration));
		}
		this.redisConnectionString=redisConfiguration;
		this.redisConnection=GetRedisConnection();
	}

	private ConnectionMultiplexer GetRedisConnect(){
		if(this.redisConnection!=null&&this.redisConnection.IsConnected){
			return this.redisConnection;
		}
		lock(redisConnectionLock){
			if(this.redisConnection!=null){
				this.redisConnection.Dispose();
			}
			this.redisConnection=ConnectionMultiplexer.Connect(redisConnectionString);
		}
		return this.redisConnection;
	}
	public void Claer(){
		foreach(var endPoint in this.GetRedisConnection().GetEndPoints()){
			var server=this.GetRedisConnection().GetServer(endPoint);
			foreach(var key in server.keys){
				redisConnection.GetDabase().KeyDelete(key);
			}
		}
	}
	public bool Contains(string key){
		return redisConnection.GetDatabase().KeyExists(key);
	}
	public void Remove(string key){
		redisConnection.GetDatabase().KeyDelete(key);
	}
	public void Get<T>(string key){
		var value=redisConnection.GetDatabase().StringGet(key);
		if(value.HasValue){
			return SerializerHelper.Deserizliable<T>(value);
		}else{
			return defualt(T);
		}
	}
	public void Set(string key,object value,TimeSpan cacheTime){
		if(value!=null){
			redisConnection.GetDatabase().StringSet(key,SerializerHelper.Serialize(value),cacheTime);
		}
	}

}

MemeryCacheManager
public class MemoryCacheManager:ICacheManager
{
	public void Clear(){
		foreach(var item in MemoryCache.Default){
			this.Remove(item.Key);
		}
	}
	public void Remove(string key){
		MemoryCache.Default.Remove(key); 
	}
	public void Set(string key,object value,TimeSpan cacheTime){
		MemoryCache.Defualt.Add(key,value,new CacheItemPolicy{SlidingExpiration=cacheTime});
	}
	public T Get<T>(string key){
		return (T)MemoryCache.Default.Get(key);
	}
	public void Contains(string key){
		return MeoryCache.Default.Contains(key);
	}
}


public class MemoryCacheManager:ICacheManager
{
	public void Set(string key,object value,TimeSpan cacheTime){
		MemoryCache.Default.Add(key,value,new CacheItemPolicy{SlidingExpireation=cacheTime});
	}
	public T Get<T>(string key){
		return (T)MemoryCache.Default.Get(key);
	}
	public bool Contains(string key){
		return MemoryCache.Default.Contains(key);
	}
	public void Remove(string key){
		MemoryCache.Default.Remove(key);
	}
	public void Clear(){
		foreach(var item in MemoryCache.Default){
			this.Remove(item.Key);
		}
	}
}

public class MemoryCacheManager:ICacheManager
{
	public void Set(string key,object value,TimeSpan cacheTime){
		MemoryCache.Default.Add(key,value,new CacheItemPolicy(SlidingExpiration=cacheTime));
	}
	public T Get<T>(string key){
		return (T)MemoryCache.Default.Get(key);
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

public interface ICacheManager
{
	void Set(string key,object value,TimeSpan cacheTime);
	T Get<T>(string key);
	void Remove(string key);
	void Clear();
	bool Contains(string key);
}