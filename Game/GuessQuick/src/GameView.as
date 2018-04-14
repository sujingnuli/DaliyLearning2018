package
{
	import ui.GameViewUI;
	import laya.events.Event;
	import laya.utils.Tween;
	import laya.utils.Ease;
	import laya.utils.Handler;
	import laya.ui.Image;
	import ui.animalMoveUI;
	import ui.GameViewUI;
	import laya.media.SoundManager;
	public class GameView extends GameViewUI
	{
		
		private var len:Number=660;
		private var wins:int=-1;
		private var win:Boolean=false;
		private var chosv:int=0;
		private var chosf:Boolean=false;
		private var crabs:Vector.<Crab>;
		public var run:Boolean=false;
		
		public function GameView()
		{
			super();
			ViewStart();
			// Init();
		}
		//游戏开始的时候，动画不播放，等选择了的时候，开始播放
		public function ViewStart():void{
			// this.crab1.crab.skin="ui/animal_red.png";
			// this.crab2.crab.skin="ui/animal_yellow.png";
			// this.crab3.crab.skin="ui/animal_green.png";
			// this.crab4.crab.skin="ui/animal_blue.png";

			var arr:Array=["red","yellow","green","blue"];
			crabs=new Vector.<Crab>();
			var moves:Handler=new Handler(this,this.MoveOn);
			var stops:Handler=new Handler(this,this.StopOn);
			var lens:Array=GetDis();
			for(var i:int=0;i<4;i++){
				var t:int=i+1;
				var cab:animalMoveUI=this.getChildByName("crab"+t) as animalMoveUI;
				var crab:Crab=new Crab(cab,t,len,lens[i],arr[i],moves,stops);
				crabs.push(crab);
			}
			this.againBtn.on(Event.CLICK,this,this.overAgain);
		}
		private function overAgain():void{
			if(!run){
				this.EmptyAll();
			}
		}
		private function EmptyAll():void{
			this.len=660;
			this.win=false;
			var arr:Array=GetDis();
			for(var i:int=0;i<4;i++){
				crabs[i].EmptyInit();
				crabs[i].len=arr[i];
			}
			this.chosv=0;
			this.chosf=false;
			this.chos.text="";
			this.winer.text="猜一猜，哪个跑的更快啊？";
		}
		private function GetDis():Array{
		 	var arr:Array=new Array();
		 	for(var i:int=0;i<4;i++){
				arr.push(len-(Math.ceil((Math.random()*10%4)*10)));
			}
			wins=Math.ceil(Math.random()*10%4)-1;
			arr[wins]=len;
			return arr;
		}
		// private function Init():void{
		// 	this.crab1.on(Event.CLICK,this,this.MoveUp,["0"]);
		// 	this.crab2.on(Event.CLICK,this,this.MoveUp,["1"]);
		// 	this.crab3.on(Event.CLICK,this,this.MoveUp,["2"]);
		// 	this.crab4.on(Event.CLICK,this,this.MoveUp,["3"]);
		// 	this.againBtn.on(Event.CLICK,this,this.overAgain);
		// }
		public function MoveOn(num:int):void{
			if(!run){
				run=true;
				this.againBtn.visible=false;
				var name:String=GetName(num);
				this.chos.text=name;
				this.chosv=num;
				for(var i:int=0;i<4;i++){
					crabs[i].Move();
				}
			}

		}
		private function GetName(num:int):String{
			var res:String="";
			if(num==1){
				res="红螃蟹";
			}else if(num==2){
				res="黄螃蟹";
			}else if(num==3){
				res="绿螃蟹";
			}else if(num==4){
				res="蓝螃蟹";
			}
			return res;
		}
		private function StopOn(lent:int,index:int):void{
			if(lent==len){
				if(index==chosv){
					this.winer.text="恭喜你猜对了，小样！";
				}else{
					this.winer.text="这都猜不对，服了你了！";
				}
				for(var i:int=0;i<4;i++){
					crabs[i].Stop();
				}
				run=false;
				this.againBtn.visible=true;
			}
		}
		// private function overAgain():void{
		// 	//this.Empty();
		// 	this.removeSelf();
		// 	//Main.gameView.Init();
		// 	Laya.stage.addChild(Main.gameView);
		// }
		// private function Empty():void{
		// 	wins="";
		// 	win=false;
		// 	chosv="";
		// 	chosf=false;
		// 	this.crab1.x=122;
		// 	this.crab2.x=122;
		// 	this.crab3.x=122;
		// 	this.crab4.x=122;
		// 	this.crab1.word.visible=false;
		// 	this.crab2.word.visible=false;
		// 	this.crab3.word.visible=false;
		// 	this.crab4.word.visible=false;
		// }
		// private function MoveUp(clr:Array):void{
		// 	if(!chosf){
		// 		this.chos.text=clr[0];
		// 		chosf=true;
		// 		chosv=clr[0];
		// 		var name:String=clr[0]=="0"?"红":chosv=="1"?"黄":chosv=="2"?"绿":"蓝";
		// 		this.chos.text=name+"螃蟹";
		// 	}
		// 	//crab开始播放动画，并且向右移动
		// 	this.crab1.move.play();
		// 	this.crab2.move.play();
		// 	this.crab3.move.play();
		// 	this.crab4.move.play();
		// 	//随机获取 650左右的四个数字
		// 	var arr:Array=GetDis(len);
		// 	Tween.to(this.crab1,{x:arr[0]},3000,Ease.linearIn,Handler.create(this,this.Stop,["0"]));
		// 	Tween.to(this.crab2,{x:arr[1]},3000,Ease.linearIn,Handler.create(this,this.Stop,["1"]));
		// 	Tween.to(this.crab3,{x:arr[2]},3000,Ease.linearIn,Handler.create(this,this.Stop,["2"]));
		// 	Tween.to(this.crab4,{x:arr[3]},3000,Ease.linearIn,Handler.create(this,this.Stop,["3"]));
		// }
	
		// 	wins=Math.ceil(Math.random()*10%4)+"";
		// 	arr[wins]=len;
		// 	return arr;
		// }
		// private function Stop(arr:Array):void{
		// 	if(arr[0]==wins){
		// 		if(chosv==wins){
		// 			this.winer.text="恭喜你猜对了，小样！";
		// 		}else{
		// 			this.winer.text="笨蛋，这都猜错了，服了你了！";
		// 		}
		// 		var crab:animalMoveUI=arr[0]=="0"?this.crab1:arr[0]=="1"?this.crab2:arr[0]=="2"?this.crab3:this.crab4;
		// 		crab.word.visible=true;
		// 		Tween.to(crab.word,{y:crab.word.y-55},300,Ease.backIn);
		// 		this.crab1.move.stop();
		// 		this.crab2.move.stop();
		// 		this.crab3.move.stop();
		// 		this.crab4.move.stop();
		// 		this.crab1.off(Event.CLICK,this,this.MoveUp);
		// 		this.crab2.off(Event.CLICK,this,this.MoveUp);
		// 		this.crab3.off(Event.CLICK,this,this.MoveUp);
		// 		this.crab4.off(Event.CLICK,this,this.MoveUp);
		// 	}
		// }
	}
}