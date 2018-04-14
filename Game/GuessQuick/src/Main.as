package 
{
	/**
	 * ...
	 * @author
	 */
	import laya.net.Loader;
	import laya.utils.Handler;
	import laya.display.Stage;
	public class Main{
		public static var gameStart:GameStart;
		public  static var gameView:GameView;
		public function Main(){
			Laya.init(800,600);
			Laya.stage.scaleMode = Stage.SCALE_SHOWALL;
			Laya.stage.screenMode = Stage.SCREEN_HORIZONTAL;
			Laya.stage.alignV = Stage.ALIGN_MIDDLE;
			Laya.stage.alignH = Stage.ALIGN_CENTER;
			
			Laya.stage.bgColor="#ffcccc";
			var resArr:Array=[
				{url:"res/atlas/ui.atlas",type:Loader.ATLAS},
				{url:"ui/start.png",type:Loader.IMAGE}
			];
			Laya.loader.load(resArr,Handler.create(this,this.GoStart));
		}
		private function GoStart():void{
			gameStart=new GameStart();
			Laya.stage.addChild(gameStart);
		}
	}

}