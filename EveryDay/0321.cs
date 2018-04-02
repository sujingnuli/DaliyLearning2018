//Sprite 基本的显示图形的显示列表节点。

//同时是容器类，可以用来添加多个子节点。

切换图片： 
	在 显示图片的 基础上 。增加了清空，绘制。通过代码逻辑。获取新的图片资源 重新绘制。

public class Main
{
	private var monkey1:String="../../res/monkey1.jpg";
	private va monkey2:String="../../res/monkey2.jpg";
	private var img:Sprite;
	private var flag:Boolean=false;
	public function Main(){
		Laya.init(600,300);
		Laya.stage.bgColor="#ffffff";
		
		img=new Sprite();
		img.on("click",this,switchImage);
		
		switchImg();
		Laya.stage.addChild(img);
	}
	private function switchImg(e:*=null):void{
		img.graphics.clear();
		var imageUrl=(flag=!flag)?monkey1:monkey2;
		img.loadImage(imageUrl,0,0);
	}
}\


public class Main
{
	private var img:Sprite;
	public function Main(){
		Laya.init(600,300);
		Laya.stage.bgColor="#ffffff";
		
		img=new Sprite();
		img.on("click",this,switchImg);
		Laya.stage.addChild(img);
	}
	private function switchImg(e:*=null):void{
		img.graphics.clear();
		var imgUrl=(flag=!flag)?monkey1:monkey2;
		img.laodImage(imgUrl,0,0);
	}
}

public class Main
{
	private var img:Sprite;
	private var monkey1:String="../../res/monkey1.jpg";
	private var monkey2:String="../../res/monkey2.jpg";
	private var flag:Boolean =false;
	public function Main(){
		Laya.init(600,300);
		Laya.stage.bgColor="#ffffff";
		switchImg();
	    img=new Sprite();
		img.on("click",this,switchImg);
		Laya.stage.addChild(img);
	}
	private function switchImg(e:*=null):void{
		img.graphics.clear();
		var imgUrl:String=(flag=!flag)?monkey1:monkey2;
		img.loadImage(imgUrl,0,0);
	}
}
//切换控制。一个flag搞定。
private var flag:Boolean=false;
var imgUrl:String=(flag=!flag)?monkey1:monkey2;

laya.display.graphics.  用于创建绘图显示对象。
Graphics 可以同时绘制多个位图或者矢量图，还可以结合save,restore,transform,scale,rotate,translate,alpha 等对绘图进行变换。
Graphics 以命令流方式存储，cmds 属性访问所有命令流。Graphics 是比Sprite轻量级的对象。合理的使用提高性能。
比如把大量的节点绘图，改成一个节点的Graphics 命令集合。减少大量节点创建的消耗。
drawTexture：绘制纹理
namespace laya.display
{
	public class Graphics
	{
		//绘制纹理
		//m:矩阵
		//alpha:
		public function drawTexture(tex:Texture,x:Number=0,y:Number=0,width:Number=0,Height:Number=0,m:Matrix=null,alpha:Number=1):void{
		
		}
	}
}

// Sprite.loadImage 加载图片，用on("click",this,func) 切换图片
package
{
	import laya.display.Sprite;
	import laya.utils.Browser;
	import laya.utils.Handler;
	import laya.webgl.WebGL;
	//Sprite: 显示图形的节点列表。默认没有宽高。通过graphics 可以绘制图片或者矢量图。
	//支持旋转，缩放，位移等操作。Sprite同时也是容器类，可添加多个节点。
	public class Main 
	{
		private var monkey1:String="../../res/monkey2.jpg";
		private var monkey2:String="../../res/monkey1.jpg";
		
		private var flag:Boolean=false;
		private var img:Sprite;
		
		public function Main(){
				Laya.init(600,800);
				Laya.stage.bgColor="#ffffff";
				
				img=new Sprite();
				
				switchImg();
				
				img.on("click",this,switchImg);
				//Sprite:on (type:String,listener:Function,args:Array=null):EventDispatcher
				//增加事件侦听器，使侦听器能够接受到时间通知，此侦听事件响应一次后自动移除侦听。
				//如果侦听是鼠标事件，则设置自己和父节点的属性MouseEnabled为true.
				
				Laya.stage.addChild(img);
				
		}
		private function switchImg(e:*=null):void{
			img.graphics.clear();
			//graphics: 绘图对象，封装了绘制位图和矢量图的接口。
			var imgUrl:String=(flag=!flag)?monkey1:monkey2;
			img.loadImage(imgUrl,100,50);
		}
		
	}
}

//loadImage 可以即时加载外部资源图片，也可以从缓冲区读取图片。
//drawTexture () 必须先加载完图片，再绘制到舞台中，在实例代码中，要使用到加载laya.loader.load()与回掉方法Handler.Create（）方法。
drawTexture .
laya.loader.load(,Handler.create());
//Handler 是事件处理类。
//Handler 事件处理类， Handler.create() 方法从对象池创建。 使用完后可以回收 Handler.recover(); 回收后不可使用。