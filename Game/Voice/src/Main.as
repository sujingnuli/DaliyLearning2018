package
{
	import laya.net.Loader;
	import laya.utils.Handler;
	import laya.webgl.WebGL;
	import laya.display.Stage;
	public class Main
	{
		private var gameView:GameView;
		public function Main()
		{
			Laya.init(800,1000,WebGL);
			Laya.stage.scaleMode=Stage.SCALE_NOSCALE;
			Laya.stage.screenMode=Stage.SCREEN_VERTICAL;
			Laya.stage.alignV=Stage.ALIGN_MIDDLE;
			Laya.stage.alignH=Stage.ALIGN_CENTER;
			Laya.stage.bgColor="#000000";
			var resArr:Array=[
				{url:"res/atlas/ui.atlas",type:Loader.ATLAS},
				{url:"ui/bgm.jpg",type:Loader.IMAGE}
			];
			Laya.loader.load(resArr,Handler.create(this,this.GoStart));
		}
		private function GoStart():void{
			if(gameView==null){
				gameView=new GameView();
				Laya.stage.addChild(gameView);
			}
		}
	}
}