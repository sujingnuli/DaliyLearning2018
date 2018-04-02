/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class GameStartUI extends View {
		public var startBtn:Button;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":800,"height":600},"child":[{"type":"Image","props":{"y":1,"x":2,"width":798,"skin":"ui/start.jpg","height":605}},{"type":"Button","props":{"y":322,"x":559,"width":250,"var":"startBtn","stateNum":1,"skin":"ui/login.png","height":285}}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}