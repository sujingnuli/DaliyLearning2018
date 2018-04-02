package
{
	import ui.HammerUI;
	import laya.events.Event;
	import laya.utils.Mouse;
	
	//小锤子，根据鼠标指针的位置，移动
	
	public class Hammer extends HammerUI
	{
		public function Hammer()
		{
			super();
		}
		
		//锤子开始
		public function Start():void{
			Mouse.hide();
			Laya.stage.on(Event.MOUSE_MOVE,this,onMouseMove);
			Laya.stage.on(Event.MOUSE_DOWN,this,onMouseDown);
			onMouseMove();
			
		}
		//鼠标点击，播放动画
		private function onMouseDown():void{
			this.hit.play(0,false);
		}
		private function onMouseMove():void{
			this.pos(Laya.stage.mouseX-this.width/2,Laya.stage.mouseY-this.height/3);
		}
		//结束
		public function End():void{
			Mouse.show();
			Laya.stage.off(Event.MOUSE_MOVE,this,onMouseMove);
			Laya.stage.off(Event.MOUSE_DOWN,this,this.onMouseDown);
		}
	}
}