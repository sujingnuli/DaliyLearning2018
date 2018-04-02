package 
{
	/**
	 * ...
	 * @author
	 */
	import laya.net.Loader;
	import laya.utils.Handler;
	public class Main{
		private var gameStart:GameStart;
		public function Main(){
			Laya.init(800,600);
			Laya.stage.bgColor="#ffcccc";
			var resArr:Array=[
				{url:"res/atlas/ui.atlas",type:Loader.ATLAS},
				{url:"ui/start.png",type:Loader.IMAGE}
			];
			Laya.loader.load(resArr,Handler.create(this,this.GoStart));
		}
		private function GoStart(){
			gameStart=new GameStart();
			Laya.stage.addChild(gameStart);
		}
	}

}