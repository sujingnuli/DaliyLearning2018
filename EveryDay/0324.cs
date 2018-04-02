

public class Game
{
	public function Game{
		
		Laya.init(1000,800);
		Laya.loader.load([{url:"/res/alts/comp.atlas",type:Loader.ATLAS}],Handler.create(this,onLoaded));
	}
	private function onLoaded():void{
		//实例化界面
		Laya.stage.addChild(new MyPage());
	}
}

import laya.ui.Box;
public class MyPage:MyPageUI
{
	public function MyPage(){
		btn.on("click",this,onClick);
	}
	private function onClick(e:*=null):void{
		inputBox.dataSource={inputName:{text:"Hello World!",color:"#ffffff",font-size:14},inputPwd:{text:"welcome to Game!",bold:true}};
		var arr:Array=[];
		for(var i:int=0;i<100;i++){
			arr.push({label:"item"+i});
		}
		list.array=arr;
		list.renderHandler=Handler.create(this,onListRender);
	}
	private function onListRender(box:Box,index:int):void(
		var clip:Clip=box.getChildByName("clip") as Clip;
		 clip.index=index%9;
	)
}