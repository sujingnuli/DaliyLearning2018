package
{
	import laya.webgl.WebGL;
	import laya.utils.Handler;
	import laya.net.Loader;
	import ui.test.MyPageUI;
	public class Game
	{
		//Laya.net.Loader .Loader.ATLAS: 图集类型，
		public function Game()
		{
			Laya.init(1000,800,WebGL);
			///Laya.stage.bgColor="#ffffff";
			//加载页面中使用的资源
			//Laya.loader.load("comp.json",new Handler(this,onLoaded));
			Laya.loader.load([{"url":"res/atlas/comp.atlas",type:Loader.ATLAS}],Handler.create(this,onLoaded));
		}
		private function onLoaded(e:*=null):void{
			//实例化刚才的页面，添加在舞台上，进行显示
			Laya.stage.addChild(new MyPage());
		}
	}
}