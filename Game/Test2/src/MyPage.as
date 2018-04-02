// ActionScript file
package{
	import laya.ui.Box;
	import laya.ui.Clip;
	import laya.utils.Handler;
	
	import ui.test.MyPageUI;
	
	public class MyPage extends MyPageUI{
		
		public function MyPage(){
			btn.on("click",this,btnClick);
		}
		private function btnClick(e:*=null):void{
		
			//inputBox.dataSource={input1:"Hello world!",input2:"welcome to World!"};
			inputBox.dataSource={input1:{text:"Hello world!",color:"#ff0000",fontSize:14},
				input2:{text:"welcome to Game!",bold:true}};
			var arr:Array=[];
			for(var i:int=0;i<100;i++){
				arr.push({label:"item"+i});
			}
			tlist.array=arr;
			tlist.renderHandler=new Handler(this,onListRender);
		}
		private function onListRender(box:Box,index:int):void{
			var clip:Clip=box.getChildByName("clip") as Clip;
			clip.index=index % 9;
		}
	}
}