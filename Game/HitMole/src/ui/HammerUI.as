/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class HammerUI extends View {
		public var hit:FrameAnimation;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":100,"height":100},"child":[{"type":"Image","props":{"y":52,"x":65,"width":96,"skin":"ui/Hammer.png","rotation":20,"pivotY":41,"pivotX":59,"height":78},"compId":2}],"animations":[{"nodes":[{"target":2,"keyframes":{"rotation":[{"value":20,"tweenMethod":"linearNone","tween":true,"target":2,"key":"rotation","index":0},{"value":-20,"tweenMethod":"linearNone","tween":true,"target":2,"key":"rotation","index":1},{"value":20,"tweenMethod":"linearNone","tween":true,"target":2,"key":"rotation","index":5}]}}],"name":"hit","id":1,"frameRate":24,"action":0}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}