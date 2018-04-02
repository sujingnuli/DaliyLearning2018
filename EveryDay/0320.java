//如何读取cache的xml配置，如何用

<xml version='1.0' encoding='utf-8'>
<CacheConfig>
	<CacheProviderItems>
		<CacheProviderItem name="LocalProviderItem" type='GMS.Core.Cache.LocalCacheProvider,GMS.Core.Cache' Desc="本地缓存"/>
	</CacheProviderItems>
	<CacheConfigItems>
		<CacheConfigItem desc="全局缓存" keyRegex=".*" moduleRegex=".*" priority="0" providerName="LocalProvider" minutes='20' isAbsoluteExpiration=true/>
		<CacheConfigItem desc="logInfo缓存" keyRegex="LoginInfo.*" moduleRegex=".*" priority="1" providerName="LocalProvider" mintues="20" isAbsoluteExpiration=true/>
	</CacheConfigItems>
</CacheConfig>

public class ConfigFileBase
{
	public int Id;
}
public class ConfigNodeBase
{
	public int Id;
}
[Serailizable]
public class CacheConfig:ConfigFileBase
{
	public CacheConfigItem[] CacheConfigItems{get;set;}
	public CacheProviderItem[] CacheProviderItems{get;set;}
}
public class CacheConfigItem:ConfigNodeBase
{
	[XmlAttribute(AttributeName="desc")]
	public string Desc{get;set;}
	[XmlAttribute(AttributeName="priority")]
	public int Priority{get;set;}
	[XmlAttribute(AttributeName="keyRegex")]
	public string KeyRegex{get;set;}
	[XmlAttribute(AttributeName="moduleRegex")]
	public string ModuleRegex{get;set;}
	[XmlAttribute(AttributeName="providerName")]
	public string ProviderName{get;set;}
	[XmlAttribute(AttributeName="minutes")]
	public int Minutes{get;set;}
	[XmlAttribute(AttributeName="isAbsoluteExpiration")]
	public bool IsAbsoluteExpiration{get;set;}
}

public class SerializationHelper
{
	public static object XmlDeserialize(Type type,string str){
		if(str=null||str.Trim()==""){
			return null;
		}
		XmlSerializer ser=new XmlSerializer(type);
		StringReader sr=new StringReader(str);
		return ser.Deseriaze(sr);
	}
	public static string XmlSerialize(object obj){
		if(obj==null){
			return null;
		}
		XmlSerialzier ser=new XmlSerializer(obj.GetType());
		StringWriter sw=new StringWriter();
		ser.Serializer(sw,obj);
		return sw.ToString();
	}
}

public class ConfigContext
{
	public IConfigService ConfigService{get;set;}
	public ConfigContext():this(new FileConfigService()){
		
	}
	public ConfigContext(IConfigService configService){
		this.ConfigService=configServcie;
	}

	public virtual T Get<T>(string index=null) where T:ConfigFileBase,new(){
		return this.GetConfigFile<T>(index);
	}
	private T GetConfigFile<T>(string index=0)where T:ConfigFileBase,new(){
		var result=T();
		var fileName=this.GetConfigFileName<T>(index);
		var content=ConfigService.Get(fileName);
		if(content==null){
			this.ConfigService.Set(fileName,string.Empty);
		}else{
			if(!string.IsNullOrEmpty(content)){
				try{
					result=(T)SerializationHelper.XmlDserialzie(typeof(T),content);
				}catch(Exception e){
					result=new T();
				}
			}
		}
		return result;
	}
	public string GetConfigFileName<T>(string index){
		string name=typeof(T).Name;
		if(!string.IsNullOrEmpty(index)){
			name=string.Format("{0}_{1}",name,index);
		}
		return name;
	}

}
public class CachedConfigContext:ConfigContext
{
	public override T Get<T>(string index=null)where T:ConfigFileBase,new(){
		var fileName=this.GetConfigFileName(index);
		var key="ConfigFile_"+fileName;
		var content=Caching.Get(key);
		if(content!=null){
			return (T)content;
		}
	    var value=base.Get<T>(index);
		Caching.Set(key,value,new CacheDpendency(ConfigService.GetFilePath(fileName)));
	}
	public static CachedConfigContext Current=new CachedConfigContext();
}
public class CacheConfigContext
{
	private static readonly object olock=new object();
	internal static CacheConfig CacheConfig{
		get{
			return CachedConfigContext.Current.CacheConfig;
		}
	}

	private static List<WrapCacheConfigItem> wrapCacheConfigItems;
	internal List<WrapCacheConfigItem> WrapCacheConfigItems{
		get{
			if(wrapCacheConfigItems==null){
				lock(olock){
					if(wrapCacheConfigItems==null){
						wrapCacheConfigItems=new List<WrapCacheConfigItem>();
						foreach(var item in CacheConfig.CacheConfigItems){
							var wrapItem=new WrapCacheConfigItem();
							wrapItem.CacheConfigItem=item;
							wrapItem.CacheProviderItem=CacheConfig.CacheProviderItems.SingleOrDefault(a=>a.Name=item.ProviderName);
							wrapItem.CacheProvider=CacheProviders[item.ProviderName];
							wrapCacheConfigItems.Add(wrapItem);
						}
					}
				}
			}
			return wrapCacheConfigItems;
		}
	}

	private static IDictionary<string,ICacheProvider> cacheProviders;
	internal static IDictionary<string,ICacheProvider> CacheProviders{
		if(cacheProviders==null){
			lock(olock){
				if(cacheProviders==null){
					cahceProviders=new Dictionary<string,ICacheProvider>();
					foreach(var item in CacheConfig.CacheProviderItems){
						cacheProviders.Add(item.Name,(ICacheProvider)Activator.CreateInstance(Type.GetType(item.Type)));
					}
				}
			}
		}
		return cacheProviders;
	}

	//获取满足条件的WrapCacheConfigItem 
	private static IDictionary<string,WrapCacheConfigItem> wrapCacheConfigItemDic;
	public static WrapCacheConfigItem GetCurrentWrapCacheConfigItem(string key){
		if(wrapCacheConfigItemDic==null){
			wrapCacheConfigItemDic=new Dictionary<string,WrapCacheConfigItem>();
		}
		if(wrapCacheConfigItemDic.ContainsKey(key)){
			return wrapCacheConfigItemDic[key];
		}
		var currentWrapCacheConfigItem=WrapCacheConfigItems.Select(item=>
			Regex.IsMatch(ModuleName,item.ModuleRegex,RegexOptions.IgnoreCase)&&
			Regex.IsMatch(key,item.KeyRegex,RegexOptions.IgnoreCase)
			.OrderBy(item=>item.priority).FirstOrDefault());
		lock(olock){
			if(!wrapCacheConfigItemDic.ContainsKey(key)){
				wrapCacheConfigItemDic.Add(key,currentWrapCacheConfigItem);
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
							moduleName=new DirectoryInfo(AppDoamin.CurrentDomain.BaseDirectory).Name;
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

//config的整体内容的获取
public interface IConfigService
{
	string GetConfig(string name);
	void SaveConfig(string name,string content);
	string GetFilePath(string name);
}

public interface IConfigService
{
	string GetConfig(string name);
	void SetConfig(string name,string content);
	void GetFilePath(string name);
}

public interface IConfigService
{
	string GetConfig(string fileName);
	void SetConfig(string name,string content);
	string GetFilePath(string name);
}
public class FileConfigService:IConfigService
{
	private static readonly configFoler=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config");
	public string GetConfig(string fileName){
		if(!Directory.Exists(configFolder)){
			Directory.CreateDirectory(configFolder);
		}
		var filePath=GetFilePath(fileName);
		if(!File.Exists(filePath)){
			return null;
		}
		var str=File.ReadAllText(filePath);
		return str;
	}

	public void SetConfig(string fileName,string content){
		var configPath=GetFilePath(fileName);
		File.WriteAllText(configPath,content)l
	}
	public string GetFilePath(string fileName){
		var result=string.Format(@"{0}\{1}.xml",configFolder,fileName);
		return result;
	}
}
//ConfigContext
public class ConfigContext
{
	private IConfigService ConfigService{get;set;}
	public ConfigContext():this(new FileConfigService()){
	
	}
	public ConfigContext(IConfigService configService){
		this.ConfigService=configService;
	}

	public virtual void Get<T>(string index=null) where T:ConfigFileBase,new(){
		return this.GetConfigFile<T>(index);
	}

	public void Save<T>(T configFile,string index) where T:ConfigFileBase,new(){
		var name=GetFileName<T>(index);
		var content=SerializationHelper.XmlSerialize(configFile);
		ConfigService.SetConfig(name,content);
	}
	private T GetConfigFile<T>(string index=null) where T:ConfigFileBase,new(){
		var result=new T();
		string name=GetFileName<T>(index);
		var content=ConfigService.GetConfig(name);
		if(content==null){
			return null;
		}else if(!string.IsNullOrEmpty(content)){
			try{
				result=(T)SerializationHelper.XmlDeSerizalize(typeof(T),content);
			}catch(Exception e){
				return result;
			}
			
		}
		return result;
	}

	public string GetFileName<T>(string index=null){
		var fileName=typeof(T).Name;
		if(!string.IsNullOrDemtpy(index)){
			fileName=string.Format("{0}_{1}",fileName,index);
		}
		return fileName;
	}
}

public class CachedConfigContext:ConfigContext
{
	public override T Get<T>(string index=null){
		var name=this.GetFileName(index);
		var key="ConfigFile_"+name;
		var result=Caching.Get(key);
		if(result!=null){
			return (T)result;
		}
		result=base.Get<T>(index);
		Caching.Set(key,result,new CacheDependency(ConfigService.GetFilePath<T>(index));
		return result;
	}
	public static CachedConfigContext Current=new CachedConfigContext();
	public CacheConfig CacheConfig{
		get{
			return this.Get<CacheConfig>();
		}
	}

}
//CacheConfigContext
public class CacheConfigContext
{
	public CacheConfig CacheConfig{
		get{
			return CachedConfigContext.Current.CacheConfig;
		}
	}
}
public class CachedCOnfigContext:ConfigContext{
	public static CachedConfigContext Current=new CachedConfigContext();

	public override T Get<T>(string index=null) where T:ConfigFileBase,new(){
		
	}
	public CacheConfig CacheConfig{
		get{
			return this.Get<CacheConfig>();
		}
	}
}