/**Created by the LayaAirIDE,do not modify.*/
package ui {
	import laya.ui.*;
	import laya.display.*; 

	public class GameViewUI extends View {
		public var btnLightm:Button;
		public var btnLightb:Button;
		public var btnWind:Button;
		public var btnRains:Button;
		public var btnRainm:Button;
		public var btnRainb:Button;
		public var btnSea:Button;
		public var btnLights:Button;
		public var plays:Label;
		public var btnBreak:Button;
		public var btnCircle:Button;
		public var voiceBar:ProgressBar;
		public var btnStop:Button;
		public var lbTimer:Label;
		public var btnPiano:Button;

		public static var uiView:Object =/*[STATIC SAFE]*/{"type":"View","props":{"y":-3,"x":-2,"width":800,"height":1000},"child":[{"type":"Image","props":{"y":407,"x":303,"width":806,"skin":"ui/bgm.jpg","pivotY":405,"pivotX":304,"height":999}},{"type":"Label","props":{"y":508,"x":391,"width":176,"text":"聆听世界的声音","height":31,"fontSize":12,"font":"Microsoft YaHei","color":"#29364c","bold":true}},{"type":"Button","props":{"y":250,"x":350,"width":154,"var":"btnLightm","stateNum":1,"skin":"ui/btn_ly2.png","height":65}},{"type":"Button","props":{"y":250,"x":578,"width":154,"var":"btnLightb","stateNum":1,"skin":"ui/btn_ly3.png","height":65}},{"type":"Button","props":{"y":371,"x":112,"width":154,"var":"btnWind","stateNum":1,"skin":"ui/btn_smf.png","height":65}},{"type":"Button","props":{"y":128,"x":112,"width":154,"var":"btnRains","stateNum":1,"skin":"ui/btn_y1.png","height":65}},{"type":"Button","props":{"y":128,"x":338,"width":154,"var":"btnRainm","stateNum":1,"skin":"ui/btn_y2.png","height":65}},{"type":"Button","props":{"y":128,"x":578,"width":154,"var":"btnRainb","stateNum":1,"skin":"ui/btn_y3.png","height":65}},{"type":"Button","props":{"y":371,"x":352,"width":154,"var":"btnSea","stateNum":1,"skin":"ui/btn_sea.png","height":65}},{"type":"Button","props":{"y":249,"x":112,"width":154,"var":"btnLights","stateNum":1,"skin":"ui/btn_ly1.png","height":65}},{"type":"Label","props":{"y":603,"x":165,"width":65,"var":"plays","height":28,"fontSize":20,"font":"Arial","color":"#f6f8f9"}},{"type":"Button","props":{"y":585,"x":521,"width":50,"visible":true,"var":"btnBreak","stateNum":1,"skin":"ui/btn_stop.png","height":50}},{"type":"Button","props":{"y":585,"x":673,"width":50,"visible":true,"var":"btnCircle","stateNum":1,"skin":"ui/btn_circle.png","height":50}},{"type":"ProgressBar","props":{"y":677,"x":312,"width":507,"var":"voiceBar","skin":"ui/bar.png","rotation":0,"pivotY":12,"pivotX":100,"height":25}},{"type":"Button","props":{"y":585,"x":597,"width":50,"var":"btnStop","stateNum":1,"skin":"ui/btn_stops.png","height":50}},{"type":"Button","props":{"y":649,"x":143,"width":62,"stateNum":1,"skin":"ui/btn_voice.png","height":57}},{"type":"Label","props":{"y":607,"x":264,"width":47,"var":"lbTimer","height":22,"fontSize":13,"color":"#3887c5"}},{"type":"Button","props":{"y":371,"x":578,"width":154,"var":"btnPiano","stateNum":1,"skin":"ui/btn_piano.png","height":65}}]};
		override protected function createChildren():void {
			super.createChildren();
			createView(uiView);

		}

	}
}