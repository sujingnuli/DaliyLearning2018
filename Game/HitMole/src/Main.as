package 
{
	/**
	 * ...
	 * @author
	 */
	import laya.net.Loader;
	import laya.utils.Handler;
	import laya.utils.Stat;
	import laya.display.Stage;

	public class Main{
		public static var gameStart:GameStart;
		public static var gameView:GameView;
		public static var gameOver:GameOver;
		
		public function Main(){
			Laya.init(800,600);
			Laya.stage.scaleMode=Stage.SCALE_SHOWALL;//没有缩放
			Laya.stage.alignH=Stage.ALIGN_CENTER;//居中对齐
			Laya.stage.alignV=Stage.ALIGN_MIDDLE;//垂直居中
			Laya.stage.bgColor="#FFCCCC";
			
			var resArray:Array=[
				{url:"res/atlas/ui.atlas",type:Loader.ATLAS},
				{url:"ui/bg.jpg",type:Loader.IMAGE}
			];
			Laya.loader.load(resArray,Handler.create(this,this.OnLoaded,null,false));
			
		}
		private function OnLoaded():void{
			//显示界面
			gameStart=new GameStart();
			
			Laya.stage.addChild(gameStart);
		}
	}

}