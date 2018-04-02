package
{
	import laya.display.Sprite;
	public class Main{
		
		public function Main(){
			
			Laya.init(600,300);
			Laya.stage.bgColor="#000000";
			drawSomething();
		}
		private function drawSomething():void{
			var img:Sprite=new Sprite();
			Laya.stage.addChild(img);
			var points:Array=[
				["moveTo",100,100],
				["lineTo",150,100],
				["arcto",0,0,20,0,30]
			]
				img.graphics.drawPath(100,100,points,{fillStyle:"#ff0000"});
		}
	}
}
