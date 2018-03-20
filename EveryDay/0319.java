//数据结构
1.数据结构术语
	（1）数据（Data）
	（2）数据元素（Data）和 数据项（Data Item）
	
//代码
public static class CacheConfigContext
{
	private static readonly object olock=new object();

	//获取CacheConfig实例，还是缓存后的唯一实例
	public static CacheConfig CacheConfig{
		get{
			return CachedConfig.Current.CacheConfig;
		}
	}

	private static List<WrapCacheConfigItem> wrapCacheConfigItems;
	internal static List<WrapCacheConfigItem> WrapCacheConfigItems{
		get{
			if(wrapCacheConfigItems==null){
				lock(olock){
					if(wrapCacheConfigItem==null){
						wrapCacheConfigItem=new List<WrapCacheConfigItem>();
						foreach(var item in CacheConfig.CacheConfigItems){
							var wrapItem=new WrapCacheConfigItem();
							wrapItem.CacheConfigItem=item;
							wrapItem.CacheProviderItem=CacheConfig.CacheProviderItems.SingleOrDefault(a=>a.Name=item.ProviderName);
							wrapItem.CacheProvder=CacheProviders[item.ProviderName];
							wrapCacheConfigItems.Add(wrapItem);
						}
					}
				}
			}
			return wrapCacheConfigItems;
		}
	}

	private static IDictionary<string,ICacheProvider> cacheProviderItems;
	internal static IDictionary<string,ICacheProvider> CacheProviderItems{
		get{
			if(cacheProviderItems==null){
				lock(olock){
					if(cacheProviderItems==null){
						cacheProviderItems=new Dictionary<string,CacheProviderItems>();
						foreach(var  item in CacheConfig.CacheProviderItems){
							cacheProviderItems.Add(item.Name,(ICacheProvider)Activator.CreateInstance(Type.GetType(item.Type)));
						}
					}
				}
			}
		}
	}
	
	private static IDictionary<string,WrapCacheConfigItem> wrapCacheConfigItemsDic;
	internal static wrapCacheConfigItem GetWrapCacheConfigItem(string key){
		if(wrapCacheConfigItemsDic==null){
			wrapCacheConfigItemsDic=new Dictionary<string,WrapCacheConfigItem>();
		}
		if(wrapCacheConfigItemsDic.ContainsKey(key)){
			return wrapCacheConfigItems[key];
		}
		var currentWrapCacheConfigItem=WrapCacheConfigItems.Select(item=>
			Regex.IsMatch(ModuleName,item.CacheConfigItem.ModuleRegex,RegexOptions.IgnoreCase)&&
			Regex.IsMatch(key,item.CacheConfigItem.KeyRegex,RegexOptions.IgnoreCase)
			).OrderByDescending(item=>item.CacheConfigItem.Priority).FirstOrDefault();
		if(currentWrapCacheConfig==null){
			throw new Exception("没有符合此条件缓存");
		}
		lock(olock){
			if(!wrapCacheConfigItemsDic.Contains(key)){
				wrapCacheConfigItemsDic.Add(key,currentWrapCacheConfigItem);
			}
		}
		return currentWrapCacheConfigItem;
	}

	private static string moduleName;
	public static string ModuleName{
		get{
			if(moduleName==null){
				lock(olock){
					if(moduleName==null){
						var entryAssembly=Assembly.GetEntryAssembly();
						if(entryAssembly==null){
							moduleName=new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Name;
						}else{
							moduleName=entryAssembly.FullName;
						}
					}
				}
			}
			return moduleName;
		}
	}

}
public class WrapCacheConfigItem
{
	public CacheProviderItem CacheProviderItem{get;set;}
	public CacheConfigItem CacheConfigItem{get;set;}
	public ICacheProvider CacheProvider{get;set;}
}
