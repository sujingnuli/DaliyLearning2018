package
{
	import laya.events.Event;
	import laya.ui.Image;
	import laya.utils.Ease;
	import laya.utils.Handler;
	import laya.utils.Tween;
	//Ease 定义了缓存函数，实现 Tween的缓动效果

	public class Mole
	{
		///地鼠的两个状态图：normal ,hit 
		
		private var normalState:Image;
		private var hitState:Image;
		
		//地鼠移动的最低点 和最高点的坐标值 
		private var downY:Number;
		private var upY:Number;
		
		//状态标志
		private var isActive:Boolean;
		private var isShow:Boolean;
		private var isHit:Boolean;
		private var type:int;
		private var scoreImg:Image;
		private var scoreY:Number;
		
		private var hitCallBack:Handler;
		
		///构造函数，normal,hit,downY
		public function Mole(normalState:Image,hitState:Image,scoreImg:Image,downY:Number,hitCallBack:Handler)
		{
			this.normalState=normalState;
			this.hitState=hitState;
			this.downY=downY;
			this.scoreImg=scoreImg;
			this.scoreY=scoreImg.y;
			this.upY=this.normalState.y;
			this.hitCallBack=hitCallBack;
			this.Reset();
			this.normalState.on("click",this,this.Hit);
		}
		
		//对地鼠的行为进行操作
		
		//地鼠可能钻出多次
		//重置
		private function Reset():void{
			this.normalState.visible=false;
			this.hitState.visible=false;
			this.isActive=false;
			this.isShow=false;
			this.isHit=false;
			this.scoreImg.visible=false;
		}
		
		//显示
		public function Show():void{
			if(this.isActive) return;
			this.isActive=true;
			this.isShow=true;
			this.type=Math.random()<0.3?1:2;
			this.normalState.skin="ui/mouse_"+this.type+".png";
			this.hitState.skin="ui/hit_"+this.type+".png";
			this.scoreImg.skin="ui/score_"+this.type+".png";
			this.normalState.y=this.downY;
			this.normalState.visible=true;
			
			//缓动的方式出现
			Tween.to(this.normalState,{y:this.upY},500,Ease.backOut,Handler.create(this,this.ShowComplete));
		}
		//停留
		private function ShowComplete():void{
			if(this.isShow&&!this.isHit){
				//一定时间后，执行某个函数
				Laya.timer.once(2000,this,this.Hide);
			}
		}
		//消失
		private function Hide():void{
			if(this.isShow&&!this.isHit){
				Tween.to(this.normalState,{y:this.downY},500,Ease.backIn,Handler.create(this,this.Reset));
			}
		}
		
		//受击
		private function Hit():void{
			if(this.isShow&&!this.isHit){
				this.isHit=true;
				Laya.timer.clear(this,this.Hide);
				this.normalState.visible=false;
				this.hitState.visible=true;
			
				Laya.timer.once(500,this,this.Reset);
				this.hitCallBack.runWith(this.type);
				this.ShowScore();
			}
		}
		//显示分数
		private function ShowScore():void{
			this.scoreImg.y=this.scoreY-30;
			this.scoreImg.scale(0,0);
			this.scoreImg.visible=true;
			//缓动向上放大效果
			Tween.to(this.scoreImg,{y:this.scoreY,scaleX:1,scaleY:1},300,Ease.backOut);
		}
	}
}