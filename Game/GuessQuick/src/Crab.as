package 
{
	/**
	 * ...
	 * @author
	 */
	import ui.animalMoveUI;
	import ui.GameViewUI;
	import laya.utils.Ease;
	import laya.events.Event;
	import laya.utils.Handler;
	import laya.utils.Tween;
	import laya.media.SoundManager;
	import laya.ui.Image;
	public class Crab{
		public var box:animalMoveUI;
		public var len:int;
		private var moveHandler:Handler;
		private var stopHandler:Handler;
		private var dis:int;
		private var index:int;
		private var letter:Image=new Image();;
		public function Crab(box:animalMoveUI,index:int,dis:int,len:int,color:String,moves:Handler,stops:Handler){
			this.box=box;
			this.len=len;
			this.dis=dis;
			this.index=index;
			this.box.crab.skin="ui/animal_"+color+".png";
			this.letter.skin="ui/feet.png";
			this.letter.name="feet_"+index+"_0";
			this.letter.x=122;
			this.letter.y=this.box.y-10;
			this.box.on(Event.CLICK,this,this.Clicked);
			moveHandler=moves;
			stopHandler=stops;


		}
		public function Clicked():void{
			this.moveHandler.runWith(this.index);
		}
		public function Move():void{
			this.box.move.play();
			this.box.off(Event.CLICK,this,this.Clicked);
			Tween.to(this.box,{x:len},8000,Ease.linearIn,Handler.create(this,this.Stoped));
			for(var i:int=1;i<9;i++){
				Tween.to(this.letter,{x:this.letter.x},8000/50,Ease.backIn,Handler.create(this,this.addImage,[i]),i*1000);
			}
		}
		private function addImage(i:int):void{
			Laya.stage.addChild(this.letter);
			this.letter=new Image();
			this.letter.name="feet_"+index+"_"+i;
			this.letter.skin="ui/feet.png";
			this.letter.y=this.box.y-10;
			this.letter.x=122+i*60;
		}
		private function Stoped():void{
			var data:Array=new Array();
			data.push(this.len);	
			data.push(this.index);
			this.stopHandler.runWith(data);
		}
		private function Stop():void{
			this.box.move.stop();
			if(dis==this.len){
				this.box.word.visible=true;
				Tween.to(this.box.word,{y:this.box.word.y-40},300,Ease.backIn);
			}
			
		}
		public function EmptyInit():void{
			this.box.x=122;
			this.box.crab.rotation=0;
			//this.box.word.visible=false;
			if(this.box.word.visible){
				this.box.word.y=this.box.word.y+40;
				this.box.word.visible=false;
			}
			for(var i:int=0;i<9;i++){
				var img:Image=Laya.stage.getChildByName("feet_"+index+"_"+i) as Image;
				Laya.stage.removeChild(img);
			}
			this.letter=new Image();
			this.letter.skin="ui/feet.png";
			this.letter.x=122;
			this.letter.name="feet_"+index+"_0";
			this.letter.y=this.box.y-10;
			this.box.on(Event.CLICK,this,this.Clicked);
		}
	}

}