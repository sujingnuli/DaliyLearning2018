/**Created by the LayaAirIDE,do not modify.*/
package ui.test {
	import laya.ui.*;
	import laya.display.*; 

	public class MyPageUI extends View {
		public var btn:Button;
		public var tlist:List;
		public var inputBox:Box;
		public var inputName:TextInput;
		public var inputPwd:TextInput;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"width":600,"height":400},"child":[{"type":"Image","props":{"y":1,"x":-2,"width":600,"skin":"comp/bg.png","sizeGrid":"40,4,4,4","height":400}},{"type":"Button","props":{"y":265,"x":157,"var":"btn","skin":"comp/button.png","label":"登录"}},{"type":"Label","props":{"y":192,"x":98,"width":36,"text":"名字：","height":12,"color":"#000000"}},{"type":"Label","props":{"y":223,"x":98,"width":36,"text":"密码：","height":12,"color":"#000000"}},{"type":"Tab","props":{"y":44,"x":19,"skin":"comp/tab.png","labels":"label1,label2,label3","labelSize":14,"labelBold":true}},{"type":"Tab","props":{"y":44,"x":295},"child":[{"type":"Button","props":{"y":2,"skin":"comp/button.png","name":"item0","label":"label"}},{"type":"Button","props":{"y":2,"x":80,"skin":"comp/button.png","name":"item1","labelBold":true,"label":"label"}},{"type":"Button","props":{"x":158,"skin":"comp/button.png","name":"item2","label":"label"}}]},{"type":"List","props":{"y":162,"x":342,"width":129,"var":"tlist","vScrollBarSkin":"comp/vscroll.png","repeatX":1,"height":110},"child":[{"type":"Box","props":{"name":"render"},"child":[{"type":"Clip","props":{"skin":"comp/clip_num.png","name":"clip","clipX":10}},{"type":"Label","props":{"y":4,"x":35,"width":27,"text":"label","name":"label","height":12}}]}]},{"type":"Box","props":{"y":187,"x":145,"var":"inputBox"},"child":[{"type":"TextInput","props":{"var":"inputName","skin":"comp/textinput.png","name":"input1"}},{"type":"TextInput","props":{"y":31,"var":"inputPwd","skin":"comp/textinput.png","name":"input2"}}]}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}