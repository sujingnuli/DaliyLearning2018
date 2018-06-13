//从内存缓存中，读取配置。如果缓存不存在，从文件中读取配置，存入缓存
private static Dictionary<string,string> GetConfigDictionary(string cacheKey){
	Dictionary<string,string> configs=null;

	ObjectCache cache=MemoryCache.Default;

	if(cache.Contains(cacheKey)){
		return cache.GetCacheItem(cacheKey).Value as Dictionary<string,string>;
	}else{
		configs=GetFormXml();
		if(configs!=null){
			//新建一个CacheItemPolicy对象，该对象用于声明配置对象在缓存中的处理策略
			CacheItemPolicy policy=new CacheItemPolicy();

			//因为配置文件，一直需要读取，所以设置缓存优先级为不删除。
			//实际情况斟酌考虑，同时可以为AbsoluteExpiration设置过期时间
			policy.Priority=CacheItemPolicy.NotRemoveable;

			cache.Set(cacheKey,configs,policy);
			//创建一个文件监视器对象，添加对资源文件的监视
			List<string> filePaths=new List<string>(){"c:/config.xml"};
			HostFileChanageMonitor monitor=new HostFileChangeMonitor(filePaths);
			//调用监视器的NotifyOnChanged方法，传入发生改变的回调方法
			monitor.NotifyOnChanged(new OnChangedCallback((o)=>{
				cache.Remove(cacheKey);
			}));
			//为配置对象的缓存策略，加上监视器
			policy.ChanageMonitors.Add(monitor);
		}
		return configs;
	}
}
MemoryCache ,和Redis，内存缓存，高速读取缓存。

private Dictionary<string,string> GetConfigDictioanry(string cacheKey){
	Dictionary<string,string> configs=null;
	ObjectCache cache=MemoryCache.Default;
	if(cache.ContainsKey(cacheKey)){
		return cache.GetCacheItem(cacheKey).Value as Dictionary<string,string>;
	}else{
		configs=GetFormXml();
		CacheItemPolicy policy=new CacheItemPolicy();
		policy.Priority=CacheItemPolicy.NotRemovable;
		cache.Add(key,valu,policy);

		//添加文件见监视
		List<string> filtPaths=new List<string>(){"c>/config.xml"}
		HostFileChangeMonitor monitor=new HostFileChangeMonitor();
		monitor.NotifyOnChanged(new OnChangeCallback(o=>{
			cache.Remove(cacheKey);
		}));
		return configs;
	}
}
publi class RedisCahceManager:ICacheManager
{
	private  readonly string redisConnectionStr;
	public ConnectionMultiplexer redisConnect;
	private readonly object redisConnectionLock;

	public RedisCacheManager(){
		var configs=ConfigManager.ConnectionStrings["redis"].ToString();
		if(configs==null){
			throw new ArgumentNullException("redis config is null",nameof(configs));
		}
		redisConnection=GetRedisConnection();
	}
	private ConnectionMultiplexer GetRedisConnection(){
		if(redisConnection!=null&&redisConnection.IsActive){
			return redisConnection;
		}else{
			lock(redisConnectionLock){
				if(redisConnection!=null){
					redisConnection.Dispose();
				}
				redisConnection=ConnectionMultiplexer.Connect(redisConnectionStr);
			}
			return redisConnection;
		}
	}
	public void Set(string key,object value,TimeSpan cacheItem){
		redisConnection.GetDatabase().StringSet(key,SerilizerHelper.Serialize(value),cacheItem);
	}

	public T Get<T>(string key){
		
	}

}

public static string GetTree(JsonData value, string state = "preserve")
{
    if (value == null)
    {
        return "没有树形数据";
    }
    List<JsonData> list = value.asList();
    string str = "";
    if (list.Count == 0)
    {
        return "没有树形数据";
    }
    foreach (JsonData data in list)
    {
        JsonData data2 = data["id"];
        JsonData data3 = data["pid"];
        JsonData data4 = data["name"];
        string str2 = data.Contains("bid") ? data["bid"].ToString() : "";
        string url = data.Contains("url") ? data["url"].ToString() : "";
        string str4 = (data.Contains("icon") && !string.IsNullOrEmpty(data["icon"].ToString())) ? ("<i class='am-icon-" + data["icon"] + "'></i>&nbsp;") : "";
        if (!string.IsNullOrEmpty(url))
        {
            if (url.Contains("/"))
            {
                if (url.Substring(url.Length - 1, 1) == "/")
                {
                    url = url.Remove(url.Length - 1, 1);
                }
                url = RouteHelper.GetUrl(url + (string.IsNullOrEmpty(str2) ? "" : ("/" + str2)));
            }
            else
            {
                url = "javascript:" + url + "(" + (string.IsNullOrEmpty(str2) ? "" : str2) + ");";
            }
            url = " href='" + url + "'";
        }
        string str5 = string.Concat(new object[] { "<li id='", string.IsNullOrEmpty(str2) ? "" : str2, "'><a", url, ">", str4, data4, "&nbsp;&nbsp;<i class='' id='sicon_", string.IsNullOrEmpty(str2) ? "" : str2, "'></i></a>[", data2, "]</li>" });
        int index = str.IndexOf("[" + data3 + "]");
        if (index >= 0)
        {
            if (str.Substring(index - 5, 5) == "</ul>")
            {
                index -= 5;
                str = str.Insert(index, str5);
            }
            else
            {
                str = str.Insert(index, "<ul>" + str5 + "</ul>");
            }
        }
        else
        {
            str = str + str5;
        }
    }
    foreach (JsonData data in list)
    {
        str = str.Replace("[" + data["id"] + "]", "");
    }
    return ("<ul class='tree tree-lines text-gray' data-ride='tree' data-animate='true' id='deftree'>" + str + "</ul><script type='text/javascript'>$('#deftree').tree({ initialState: '" + state + "' });</script>");
}