package
{
	import ui.GameStartUI;
	import laya.events.Event;
	
	public class GameStart extends GameStartUI
	{
		public function GameStart()
		{
			super();
			this.startBtn.on(Event.CLICK,this,this.StartGame);
		}
		private function StartGame():void{
			//移除游戏开始界面
			this.removeSelf();
			//在舞台上添加游戏界面
			if(!Main.gameView){
				Main.gameView=new GameView();
			}
			Main.gameView.GameStart();
			Laya.stage.addChild(Main.gameView);
		}
	}
}