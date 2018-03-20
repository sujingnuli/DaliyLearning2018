//���ݽṹ
1.���ݽṹ����
	��1�����ݣ�Data��
	��2������Ԫ�أ�Data���� �����Data Item��
	
//����
public static class CacheConfigContext
{
	private static readonly object olock=new object();

	//��ȡCacheConfigʵ�������ǻ�����Ψһʵ��
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
			throw new Exception("û�з��ϴ���������");
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
