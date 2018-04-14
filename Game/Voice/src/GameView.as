package
{
	import ui.GameViewUI;
	import laya.events.Event;
	import laya.media.SoundManager;
	import laya.display.Sprite;
	import laya.maths.Rectangle;
	import laya.media.Sound;
	import laya.media.SoundChannel;
	import laya.d3.shadowMap.ParallelSplitShadowMap;
	import laya.utils.Handler;
	
	public class GameView extends GameViewUI
	{
		private var rains:String="sounds/rain_s.mp3";
		private var rainm:String="sounds/rain_m.mp3";
		private var rainb:String="sounds/rain_b.mp3";
		private var lights:String="sounds/light_s.mp3";
		private var lightm:String="sounds/light_m.mp3";
		private var lightb:String="sounds/light_b.mp3";
		private var windm:String="sounds/wind_m.mp3";
		private var sea:String="sounds/sea.mp3";
		private var piano:String="sounds/piano.mp3";
		private var soundc:SoundChannel;
		private var run:Boolean=false;
		private var now:String;
		private var crs:Boolean=false;//循环位
		public function GameView()
		{
			super();
			Init();
		}
		private function Init():void{
			SoundManager.autoStopMusic=false;
			this.btnRains.on(Event.CLICK,this,this.Play,[this.rains,"小雨"]);
			this.btnRainm.on(Event.CLICK,this,this.Play,[this.rainm,"中雨"]);
			this.btnRainb.on(Event.CLICK,this,this.Play,[this.lights,"大雨"]);
			this.btnLights.on(Event.CLICK,this,this.Play,[this.lights,"雷雨【小】"]);
			this.btnLightm.on(Event.CLICK,this,this.Play,[this.lightm,"雷雨【中】"]);
			this.btnLightb.on(Event.CLICK,this,this.Play,[this.lightb,"雷雨【大】"]);
			this.btnWind.on(Event.CLICK,this,this.Play,[this.windm,"沙漠风声"]);
			this.btnSea.on(Event.CLICK,this,this.Play,[this.sea,"海浪"]);
			this.btnPiano.on(Event.CLICK,this,this.Play,[this.piano,"钢琴"]);
			this.btnStop.on(Event.CLICK,this,this.Stop);
			this.voiceBar.on(Event.MOUSE_DOWN,this,this.Slider,[1]);
			this.btnBreak.on(Event.CLICK,this,this.Break);
			this.btnCircle.on(Event.CLICK,this,this.Circle);
			this.voiceBar.value=1;
		}
		private function Play(url:String,name:String):void{
			// if(now!=null){
			// 	SoundManager.destroySound(now);
			// }
			now=url;
			soundc=SoundManager.playMusic(url,1,Handler.create(this,this.Complete));
			this.plays.text=name;
			this.run=true;
			this.btnBreak.skin="ui/btn_stop.png";
			Laya.timer.loop(1000,this,this.ShowTime);
			this.btnStop.skin="ui/btn_stops.png";
		}
		private function ShowTime():void{
			if(soundc!=null&&!soundc.isStopped){
				this.lbTimer.text=soundc.position.toFixed(2)+"/"+soundc.duration.toFixed(2);
			}
		}
		private function Complete():void{
			if(crs){
				soundc=SoundManager.playMusic(now,1,Handler.create(this,this.Complete));
			}else{
				this.Stop();
			}
		}
		private var i:int=0;
		private function CheckStop():void{
			if(!crs){
				this.plays.text=(i++)+"";
				this.Stop();
			}
		}
		private function Break():void{
			if(!soundc.isStopped){
				soundc.pause();
				this.btnBreak.skin="ui/btn_start.png";
				Laya.timer.clear(this,this.ShowTime);
			}else{
				soundc.resume();
				this.btnBreak.skin="ui/btn_stop.png";
				Laya.timer.loop(1000,this,this.ShowTime);
			}
		}
		private function Stop():void{
			if(soundc!=null){
				soundc.stop();
			}else{
				SoundManager.stopAll();
			}
			SoundManager.destroySound(now);
			now=null;
			Laya.timer.clear(this,this.ShowTime);
			this.btnStop.skin="ui/btn_stopsf.png";
		}
		private function Circle():void{
			if(!crs){
				this.btnCircle.skin="ui/btn_circle2.png";
				this.crs=true;
			}else{
				this.btnCircle.skin="ui/btn_circle.png";
				this.crs=false;

			}
		}
		private function Slider(type:int=0):void{
			//var remain:int=(this.voiceBar.width-(this.voiceBar.mouseX-this.voiceBar.x));
			//this.plays.text=this.voiceBar.mouseX+":"+this.voiceBar.x+":"+this.voiceBar.width;
			var per:Number=this.voiceBar.mouseX/this.voiceBar.width;
			this.voiceBar.value=per;
			if(type==1){
				// if(soundc!=null){
				// 	soundc.volume=per;
				// }
				SoundManager.setMusicVolume(per);
			}
		}
	}
}