//���������Σ�����Σ�����ָ����·�����ݻ����š�
drawpoly();
//Ҫ����һ��������
public class Main
{

	public function Main(){
		
		Laya.init(600,300);
		Laya.stage.bgColor="#ffffff";
		drawSomething();
	}
	private function drawSomething():void(){
		var img:Sprite=new Sprite();
		Laya.stage.addChild(img);
		img.graphics.drawPoly(100,50,[0,0,50,25,100,100],"#ffff00");
	}
}
//
public class Tool
{
	public static rand(num:number=10):number{
		return Math.round(Math.random()*m);
	}
}

//IRouteHelper ,ֻ�践��һ������IHttpHandler .
public class ContextCollectHandler:IHttpHandler,IRouteHanlder
{
	public IHttpHanlder GetHttpHandler(RequestContext requestContext){
		return this;
	}

	public bool IsReusable{
		get{return false;}
	}
	public void ProcessRequest(HttpContext context){
		
	}
}

Config .
<?xml version='1.0' encoding='utf-8'?>
<AdminMenuConfig>
	<AdminMenuGroups>
		<AdminMenuGroup  name="������ҳ" url='/Account/Auth/Index' icon="icon-home" info="��ӭ��¼GMSϵͳ">
		</AdminMenuGroup>
		<AdminMenuGroup name="ϵͳ����" icon="icon-cog">
			<AdminMenuArray>
				<AdminMenu name="�û�����" url='/Account/User/Index' info="����޸�ɾ���û�" permission="AccountManage_User"/>
				<AdminMenu name="��ɫ����" url='/Account/Role/Index' Info="����޸�ɾ����ɫ" permission="AccountManage_Role"/>
			</AdminMenuArray>
		</AdminMenuGroup>
		<AdminMenuGroup name="CMS����" icon="icon-leaf">
			<AdminMenu name="���¹���" url="/Cms/Article/Index" info="����޸�ɾ������" permission="CmsManage_Article"/>
			<AdminMenu name="����Ƶ������" url="/Cms/Channel/Index" info="����޸�ɾ������Ƶ��" permission="CmsManage_Channel"/>
		</AdminMenuGroup>
		<AdminMenuGroup name="OA����" icon="icon-sitemap">
			<AdminMenu name="Ա������" url="/OA/Staff/Index" info="����޸�ɾ��Ա����Ϣ" permission="OAManage_Staff"/>
		</AdminMenuGroup>
	</AdminMenuGroups>
</AdminMenuConfig>

//��ζ�ȡConfig ����Ϣ����ΰ������ڻ����еġ�
//_Core .
	GMS.Core.Config
		_// AdminMenuConfig 
		1.
		[Serailizable]
		public class AdminMenuConfig:ConfigFileBase
		{
			public AdminMenuGroup[] AdminMenuGroups{get;set;}
		}
		[Serializable]
		public class AdminMenuGroup
		{
			[XmlAttribute(AttribtueName="id")]
			public int Id{get;set;}
			[XmlAttribute(AttributeName="name")]
			public string Name{get;set;}
			[XmlAttribute(AttributeName="url")]
			public string Url{get;set;}
			[XmlAttribute(AttributeName="icon")]
			public string Icon{get;set;}
			[XmlAttribute(AttribtueName="info")]
			public string Info{get;set;}

			public List<AdminMenu> AdminMenuArray{get;set;}
		}

		[Serializable]
		public class AdminMenu
		{
			[XmlAttribute(AttributeName="id")]
			public int Id{get;set;}
			[XmlAttribtue(AttributeName="name")]
			public string Name{get;set;}
			[XmlAttribtue(AttributeName="url")]
			public string Url{get;set;}
			[XmlAttribute(AttributeName="info")]
			public string Info{get;set;}
			[XmlAttribute(AttributeName="permission")]
			public string permisson{get;set;}
		}
//��ζ�ȡConfig 
//ConfigContext 
//CacheConfigContext .
//IConfigService 
//FileConfigService 
//ConfigFileBase ,ConfigNodeBase 

public class ConfigContext
{
	private IConfigService ConfigService{get;set;}

	public  ConfigContext():this(new FileConfigService()){
		
	}
	public ConfigContext(IConfigService configService){
		this.ConfigService=configService;
	}

	public T Get<T>(string index=null) where T:ConfigFileBase,new(){
		return this.GetConfigFile<T>(index);
	}
	public T GetConfigFile<T>(string index=null) where T:ConfigFileBase,new(){
		var result=new T();
		var name=this.GetConfigFileName<T>(index);
		var content=ConfigService.GetConfig(name);
		if(content==null){
			ConfigService.Save(name,String.Empty);
		}else if(!string.IsNullOrEmpty(content)){
			try{
				result=SerializationHelper.XmlDeserialize(typeof(T),content);
			}catch(Excpetion e){
				result=new T();
			}
		}
		return result;
	}
	public string GetConfigFileName<T>(string index=null){
		var name=typeof(T).Name;
		if(!string.IsNullOrEmpty(index)){
			name=string.Format("{0}_{1}",name,index)
		}
			return name;
	}
}

public interface IConfigService
{
	string GetConfig(string name);
	void SetConfig(string name,string content);
	string GetFilePath(string name);
}
public class FileConfigService:IConfigService
{
	private static readonly string configFolder=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config");
	public string GetConfig(string name){
		if(!Directory.Exists(configFolder)){
			Directory.CreateDirectory(configFolder);
		}	
		var path=GetFilePath(name);
		if(!File.Exists(path)){
			return null;
		}else{
			return File.ReadAllText(path);
		}
	}
	public void SetConfig(string name,string content){
		var path=GetFilePath(name);
		File.WriteAllText(path,content);
	}
	public string GetFilePath(string name){
		var path=string.Format(@"{0}\{1}.xml",configFolder,name);
		return path;
	}
}

//
public class CachedConfigContext:ConfigContext
{
	public static CachedConfigContext Current=new CachedConfigContext();
	
	public override T Get<T>(string index=null){
		var name=this.GetConfigFileName(index);
		var key="ConfigFile_"+name;
		var content=Caching.Get(key);
		if(content!=null){
			return (T)content;
		}
		var value=base.Get<T>(index);
		if(value!=null){
			Caching.Set(key,value,new CacheDependency(this.ConfigService.GetFilePath(name)));
		}
		return value;
	}

	public AdminMenuConfig AdminMenuConfig{
		get{
			return this.Get<AdminMenuConfig>();
		}
	}

	public CacheConfig CacheConfig{
		get{
			return this.Get<CacheConfig>();
		}
	}
}

<?xml version="1.0" encoding="utf-8"?>
<CacheConfig>
	<CacheProviderItems>
		<CacheProviderItem name="LocalCacheProvider" type="GMS.Core.Cache.LocalCacheProvider,GMS.Core.Cache" desc="���ػ���"/>
	<CacheProviderItems>
	<CacheConfigItems>
		<CacheConfigItem priority="0" desc="ȫ�ֻ���" keyRegex=".*" moduleRegex=".*"  minutes="30" providerName="LocalProviderName" isAbsoluteExpiration=true/>
		<CacheConfigItem priority="1" desc="��¼��Ϣ����" keyRegex="LoginInfo.*" moduleRegex=".*"  minutes="20" providerName="LocalProviderName" isAbsoluteExpiration="true"/>
	</CacheConfigItems>
</CacheConfig>


//����Cache �����ݡ�
Cache�����õĶ�ȡ��
[Serializable]
public class CacheConfig:ConfigFileBase
{
	public CacheProviderItem[] CacheProviderItems;
	public CacheConfigItem[] CacheConfigItems;
}
public class CacheProviderItem:ConfigNodeBase
{
	[XmlAttribute(AttributeName="desc")]
	public string Desc{get;set;}
	[XmlAttribute(AttributeName="type")]
	public string Type{get;set;}
	[XmlAttribtue(AttribtueName="name")]
	public string Name{get;set;}
}
public class CacheConfigItem:ConfigNodeBase
{
	[XmlAttribute(AttributeName="desc")]
	public string Desc{get;set;}
	[XmlAttribute(AttributeName="providerName")]
	public string ProviderName{get;set;}

}

//Cache ������

//GMS.Core.Cache 
ICacheProvider 
LocalCacheProvider 
CacheConfigContext 
CacheHelper
//GMS.Framwork.Utility.
Caching 

public class ICacheProvider
{
	object Get(string key);
	void Set(string key,object value,int mintues,bool isAbsoluteExpiration,Action<string,object,string> onRemove);
	void Clear(string keyRegex);
	void Remove(key)
}


