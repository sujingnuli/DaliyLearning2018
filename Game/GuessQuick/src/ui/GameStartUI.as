/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class GameStartUI extends View {
		public var ImgY:Image;
		public var startBtn:Button;
		public var ImgR:Image;
		public var ImgB:Image;
		public var ImgG:Image;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":800,"height":600},"child":[{"type":"Image","props":{"y":1,"x":-1,"skin":"ui/start.png"}},{"type":"Image","props":{"y":122,"x":639,"width":217,"var":"ImgY","skin":"ui/animal_yellow.png","scaleY":0.5,"scaleX":0.5,"rotation":215,"pivotY":87,"pivotX":121,"height":148}},{"type":"Button","props":{"y":241,"x":338,"width":582,"var":"startBtn","stateNum":1,"skin":"ui/startBtn.png","scaleY":0.2,"scaleX":0.2,"pivotY":166,"pivotX":225,"height":434}},{"type":"Image","props":{"y":131,"x":128,"width":216,"var":"ImgR","skin":"ui/animal_red.png","scaleY":0.5,"scaleX":0.5,"rotation":135,"pivotY":74,"pivotX":109,"height":154}},{"type":"Image","props":{"y":524,"x":119,"width":226,"var":"ImgB","skin":"ui/animal_blue.png","scaleY":0.5,"scaleX":0.5,"rotation":40,"pivotY":78,"pivotX":117,"height":139}},{"type":"Image","props":{"y":509,"x":653,"width":221,"var":"ImgG","skin":"ui/animal_green.png","scaleY":0.5,"scaleX":0.5,"rotation":-40,"pivotY":85,"pivotX":114,"height":146}}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}