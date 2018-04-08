/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class animalMoveUI extends View {
		public var move:FrameAnimation;
		public var crab:Image;
		public var word:Image;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":130,"height":70},"child":[{"type":"Image","props":{"y":35,"x":69,"width":201,"var":"crab","skin":"ui/animal_red.png","scaleY":0.5,"scaleX":0.5,"pivotY":60,"pivotX":105,"height":123},"compId":2},{"type":"Image","props":{"y":17,"x":50,"visible":false,"var":"word","skin":"ui/haha.png"}}],"animations":[{"nodes":[{"target":2,"keyframes":{"rotation":[{"value":-20,"tweenMethod":"linearNone","tween":true,"target":2,"key":"rotation","index":0},{"value":0,"tweenMethod":"linearNone","tween":true,"target":2,"key":"rotation","index":2},{"value":20,"tweenMethod":"linearNone","tween":true,"target":2,"key":"rotation","index":5}]}}],"name":"move","id":1,"frameRate":24,"action":0}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}