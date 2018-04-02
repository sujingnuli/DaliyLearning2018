package
{
	import laya.ui.Box;
	import laya.ui.Image;
	import laya.utils.Handler;
	
	import ui.GameUI;
	
	public class GameView extends GameUI
	{
		private var moles:Vector.<Mole>;
		private var moleNum:Number=9;
		private var score:Number;
		private var hammer:Hammer;
		public function GameView()
		{
			super();
			moles=new Vector.<Mole>();
			var hitCallBack:Handler=new Handler(this,this.SetScore);
			for(var i:int=0;i<moleNum;i++){
				var box:Box=this.getChildByName("item"+i) as Box;
				var mole:Mole=new Mole(
					box.getChildByName("normal") as Image,
					box.getChildByName("hit") as Image,
					box.getChildByName("score") as Image,
					42,
					hitCallBack
				);
				moles.push(mole);
			}
			hammer=new Hammer();
			this.addChild(hammer);
			hammer.visible=false;
		}
		public function GameStart():void{
			this.timeBar.value=1;
			this.score=0;
			hammer.visible=true;
			this.updateScoreUI();
			hammer.Start();
			this.scoreNums.dataSource={item0:{index:4},item2:{index:2}};
			
			//定时执行
			Laya.timer.loop(1000,this,this.onLoop);
		}
		private function onLoop():void{
			this.timeBar.value -= 1/10;
			if(this.timeBar.value<=0){
				this.GameOvers();
				return;
			}
			var index:int=Math.floor(Math.random()*this.moleNum);
			moles[index].Show();
			
		}
		private function GameOvers():void{
			Laya.timer.clear(this,this.onLoop);
			hammer.visible=false;
			hammer.End();
			trace("游戏结束");
			if(!Main.gameOver){
				Main.gameOver=new GameOver();
			}
			Main.gameOver.centerX=0;
			Main.gameOver.centerY=40;
			Main.gameOver.SetScore(this.score);
			this.addChild(Main.gameOver);
		}
		//设置分数
		private function SetScore(type:int):void{
			this.score += type==1?-100:+100;
			if(this.score<=0){
				this.score=0;
			}
			this.updateScoreUI();
		}
		//分数更新
		private function updateScoreUI():void{
			var data:Object={};
			var temp:Number=this.score;
			for(var i:int=9;i>=0;i--){
				data["item"+i]={index:Math.floor(temp%10)};
				temp=temp/10;
			}
			this.scoreNums.dataSource=data;
		}
	}
}