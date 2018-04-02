/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class GameOverUI extends View {
		public var newStartBtn:Button;
		public var scoreNums:Box;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":500,"height":400},"child":[{"type":"Image","props":{"y":195,"x":256,"width":490,"skin":"ui/bg2.png","sizeGrid":"12,12,12,12","pivotY":188,"pivotX":251,"height":373}},{"type":"Button","props":{"y":214,"x":149,"var":"newStartBtn","stateNum":1,"skin":"ui/newStart.png","sizeGrid":"0,115,-4,64"}},{"type":"Box","props":{"y":160,"x":139,"width":269,"var":"scoreNums","height":27},"child":[{"type":"Clip","props":{"width":27,"skin":"ui/clip_num.png","name":"item0","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":27,"width":27,"skin":"ui/clip_num.png","name":"item1","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":54,"width":27,"skin":"ui/clip_num.png","name":"item2","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":81,"width":27,"skin":"ui/clip_num.png","name":"item3","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":108,"width":27,"skin":"ui/clip_num.png","name":"item4","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":135,"width":27,"skin":"ui/clip_num.png","name":"item5","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":162,"width":27,"skin":"ui/clip_num.png","name":"item6","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":189,"width":27,"skin":"ui/clip_num.png","name":"item7","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":216,"width":27,"skin":"ui/clip_num.png","name":"item8","index":0,"height":27,"clipX":10}},{"type":"Clip","props":{"x":243,"width":27,"skin":"ui/clip_num.png","name":"item9","index":0,"height":27,"clipX":10}}]}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}