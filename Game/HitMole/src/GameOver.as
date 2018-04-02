package
{
	import laya.events.Event;
	
	import ui.GameOverUI;
	public class GameOver extends GameOverUI
	{
		public function GameOver()
		{
			super();
			this.newStartBtn.on(Event.CLICK,this,this.ReStartGame);
		}
		private function ReStartGame():void{
			//移除游戏结束界面
			this.removeSelf();
			//移除游戏中
			Main.gameView.removeSelf();
			//添加游戏开始
			Laya.stage.addChild(Main.gameStart);
		}
		
		//设置结算分数
		public function SetScore(score:Number):void{
			var data:Object={};
			var temp:Number=score;
			for(var i:int=9;i>=0;i--){
				data["item"+i]={index:Math.floor(temp%10)};
				temp=temp/10;
			}
			this.scoreNums.dataSource=data;
		}
	}
}