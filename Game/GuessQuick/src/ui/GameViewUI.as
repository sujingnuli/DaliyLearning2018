/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class GameViewUI extends View {

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":800,"height":600},"child":[{"type":"Image","props":{"y":1,"x":-1,"skin":"ui/GameView.png"}},{"type":"Image","props":{"y":195,"x":64,"skin":"ui/animal_red.png","scaleY":0.5,"scaleX":0.5,"rotation":0}},{"type":"Image","props":{"y":271,"x":70,"skin":"ui/animal_yellow.png","scaleY":0.5,"scaleX":0.5}},{"type":"Image","props":{"y":348,"x":70,"skin":"ui/animal_blue.png","scaleY":0.5,"scaleX":0.5}},{"type":"Image","props":{"y":421,"x":70,"skin":"ui/animal_green.png","scaleY":0.5,"scaleX":0.5}},{"type":"Label","props":{"y":52,"x":403,"width":535,"text":"猜一猜，那个跑的更快啊？","pivotY":29,"pivotX":266,"height":59,"fontSize":45,"font":"SimHei","color":"#0a0909","bold":true}}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}