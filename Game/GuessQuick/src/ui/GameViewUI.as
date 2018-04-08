/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 
	import ui.animalMoveUI;

	public class GameViewUI extends View {
		public var winer:Label;
		public var chos:Label;
		public var againBtn:Button;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":800,"height":600},"child":[{"type":"Image","props":{"y":1,"x":-1,"skin":"ui/GameView.png"}},{"type":"Label","props":{"y":52,"x":403,"width":535,"var":"winer","text":"猜一猜，那个跑的更快啊？","pivotY":29,"pivotX":266,"height":59,"fontSize":45,"font":"SimHei","color":"#0a0909","bold":true}},{"type":"animalMove","props":{"y":226,"x":122,"width":130,"pivotY":39,"pivotX":70,"name":"crab1","height":70,"runtime":"ui.animalMoveUI"}},{"type":"animalMove","props":{"y":299,"x":122,"width":130,"pivotY":39,"pivotX":71,"name":"crab2","height":70,"runtime":"ui.animalMoveUI"}},{"type":"animalMove","props":{"y":379,"x":122,"width":130,"pivotY":41,"pivotX":66,"name":"crab3","height":70,"runtime":"ui.animalMoveUI"}},{"type":"animalMove","props":{"y":453,"x":122,"width":130,"pivotY":39,"pivotX":68,"name":"crab4","height":70,"runtime":"ui.animalMoveUI"}},{"type":"Label","props":{"y":542,"x":494,"width":117,"var":"chos","pivotY":21,"pivotX":60,"height":35,"fontSize":40,"font":"SimSun","color":"#000000","bold":true}},{"type":"Button","props":{"y":539,"x":631,"width":147,"var":"againBtn","stateNum":1,"skin":"ui/save.png","pivotY":79,"pivotX":74,"height":151}}]};
		override protected function createChildren():void {
			View.regComponent("ui.animalMoveUI",animalMoveUI);
			super.createChildren();
			createView(uiView);

		}

	}
}