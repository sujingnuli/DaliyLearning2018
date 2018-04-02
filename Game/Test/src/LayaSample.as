package {
	import laya.webgl.WebGL;
	import laya.display.Text;
	import laya.utils.Browser;
	import laya.display.Stage;
	import laya.display.Sprite;
	public class LayaSample {
		
		public function LayaSample() {
			//初始化引擎
			Laya.init(Browser.clientWidth,Browser.clientHeight,WebGL);
			Laya.stage.alignV=Stage.ALIGN_MIDDLE;
			Laya.stage.alignH=Stage.ALIGN_MIDDLE;

			Laya.stage.scaleMode="showall";
			Laya.stage.stage.bgColor="#232628";

			showApe();

		}		
		private function showApe():void{

			var ape:Sprite=new Sprite();
			Laya.stage.addChild(ape);
			ape.loadImage("../../res/monkey1.jpg");
		}
	}
}