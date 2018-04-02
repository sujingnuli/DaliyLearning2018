//DbContextBase ,基类的CRUD 是这么做的，所有的service ,都调用Db .
//所有的Db都调用一个

1.加载资源
2.画布局图
3.设置元素动作
3.建立元素动作
4.每个树洞都填充
5.老鼠随机在树洞显示
6.切换显示的背景

public class Main
{
	public function Main(){
		Laya.init(1000,800);
		Laya.stage.bgColor="#FFCCCC";

		var resArr:Array=[
		{url:"res/altas/ui.atlas",type:Loader.ATLAS},
		{url:"ui/bg.png",type:Loader.IMAGE}
		];
		Laya.Loader.load(resArr,Handler.create(this,this.OnLoaded));
	}
	private function OnLoaded():void{
		//创建游戏实例化
		var view:GameView=new GameView();
		Laya.stage.addChild(GameView);
	}
}
public class GameView extends GameUI
{
	private var moles:Vector.<Mole>;
	private var moleNum:int=9;
	public function GameView(){
		moles=new Vector.<Mole>();
		for(var i:int=0;i<moleNum;i++){
			var box:Box=this.getChildByName("item"+i);
			var mole:Mole=new Mole(
				box.getChildByName("normal"),
				box.getChildByName("hit"),
				42
			);
			moles.push(mole);
		}

		Laya.timer.Loop(300,this,this.OnLoop);
	}
	
	private function OnLoop():void{
		var index=Math.Floor(Math.random()*9);
		this.moles[index].Show();
	}
}
public class Mole
{
	prviate var normalState:Image;
	private var hitState:Image;
	private var downY:Number;
	private var upY:Number;
	private var isActive:Boolean;
	private var isShow:Boolean;
	private var isHit:Boolean;

	private var type:int;
	public function Mole(normalState:Image,hitState:Image,downY:int){
		this.normalState=normalState;
		this.hitState=hitState;
		this.downY=downY;
		this.upY=this.normalState.y;
		//切换不同的皮肤
		this.type=Math.random()<0.3?1:2;
		this.normalState.skin="ui/mouse_"+type+".png";
		this.hitState.skin="ui/hit_"+type+".png";
		this.Reset();
		this.normalState.on("click",this,this.Hit);
	}
	private function Reset():void{
		this.isActive=false;
		this.isShow=false;
		this.isHit=false;
		this.normalState.visible=false;
		this.hitState.visible=false;
	}
	public function Show():void{
		if(this.isActive) return;
		this.isActive=true;
		this.isShow=true;
		this.normalState.visible=true;
		Tween.to(this.normalState,{y:this.downY},500,Ease.backOut,Handler.create(this,this.ShowComplete));
	}
	public function showComplete():void{
		if(this.isShow&&!this.isHit){
			Laya.timer.once(2000,this,this.Hide);
		}
	}
	private function Hide():void{
		if(this.isShow&&!this.isHit){
			Tween.to(this.normalState,{y:downY},500,Ease.backIn,Handler.create(this,this.Reset));
		}
	}
	private function Hit():void{
		if(this.isShow&&!this.isHit){
			this.normalState.visible=false;
			this.hitState.visible=true;
			this.isHit=true;
			Laya.timer.once(500,this,this.Reset);
		}
	}
}