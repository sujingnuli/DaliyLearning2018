package
{
	import laya.events.Event;
	import laya.utils.Ease;
	import laya.utils.Tween;
	
	import ui.GameStartUI;
	public class GameStart extends GameStartUI
	{
		public function GameStart()
		{
			super();
			StartInit();
		}
		private function StartInit():void{
			Tween.to(this.startBtn,{scaleX:0.8,scaleY:0.8},3000,Ease.backOut);
			Tween.to(this.ImgR,{x:this.ImgR.x+90,y:this.ImgR.y-30,scaleX:1,scaleY:1},3000,Ease.backOut);
			Tween.to(this.ImgY,{x:this.ImgY.x-90,y:this.ImgY.y-30,scaleX:1,scaleY:1},3000,Ease.backOut);
			Tween.to(this.ImgB,{x:this.ImgB.x+90,y:this.ImgB.y-50,scaleX:1,scaleY:1},3000,Ease.backOut);
			Tween.to(this.ImgG,{x:this.ImgG.x-90,y:this.ImgG.y-30,scaleX:1,scaleY:1},3000,Ease.backOut);
			this.startBtn.on(Event.CLICK,this,this.Start);
		}
		private function Start():void{
			
			Tween.to(this.startBtn,{scaleX:1,scaleY:1},2000,Ease.backOut);
			this.removeSelf();
			if(!Main.gameView){
				Main.gameView=new GameView();
			}
			Laya.stage.addChild(Main.gameView);
		}
	}
}