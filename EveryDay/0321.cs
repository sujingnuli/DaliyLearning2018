//Sprite ��������ʾͼ�ε���ʾ�б�ڵ㡣

//ͬʱ�������࣬����������Ӷ���ӽڵ㡣

�л�ͼƬ�� 
	�� ��ʾͼƬ�� ������ ����������գ����ơ�ͨ�������߼�����ȡ�µ�ͼƬ��Դ ���»��ơ�

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
//�л����ơ�һ��flag�㶨��
private var flag:Boolean=false;
var imgUrl:String=(flag=!flag)?monkey1:monkey2;

laya.display.graphics.  ���ڴ�����ͼ��ʾ����
Graphics ����ͬʱ���ƶ��λͼ����ʸ��ͼ�������Խ��save,restore,transform,scale,rotate,translate,alpha �ȶԻ�ͼ���б任��
Graphics ����������ʽ�洢��cmds ���Է���������������Graphics �Ǳ�Sprite�������Ķ��󡣺����ʹ��������ܡ�
����Ѵ����Ľڵ��ͼ���ĳ�һ���ڵ��Graphics ����ϡ����ٴ����ڵ㴴�������ġ�
drawTexture����������
namespace laya.display
{
	public class Graphics
	{
		//��������
		//m:����
		//alpha:
		public function drawTexture(tex:Texture,x:Number=0,y:Number=0,width:Number=0,Height:Number=0,m:Matrix=null,alpha:Number=1):void{
		
		}
	}
}

// Sprite.loadImage ����ͼƬ����on("click",this,func) �л�ͼƬ
package
{
	import laya.display.Sprite;
	import laya.utils.Browser;
	import laya.utils.Handler;
	import laya.webgl.WebGL;
	//Sprite: ��ʾͼ�εĽڵ��б�Ĭ��û�п�ߡ�ͨ��graphics ���Ի���ͼƬ����ʸ��ͼ��
	//֧����ת�����ţ�λ�ƵȲ�����SpriteͬʱҲ�������࣬����Ӷ���ڵ㡣
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
				//�����¼���������ʹ�������ܹ����ܵ�ʱ��֪ͨ���������¼���Ӧһ�κ��Զ��Ƴ�������
				//�������������¼����������Լ��͸��ڵ������MouseEnabledΪtrue.
				
				Laya.stage.addChild(img);
				
		}
		private function switchImg(e:*=null):void{
			img.graphics.clear();
			//graphics: ��ͼ���󣬷�װ�˻���λͼ��ʸ��ͼ�Ľӿڡ�
			var imgUrl:String=(flag=!flag)?monkey1:monkey2;
			img.loadImage(imgUrl,100,50);
		}
		
	}
}

//loadImage ���Լ�ʱ�����ⲿ��ԴͼƬ��Ҳ���Դӻ�������ȡͼƬ��
//drawTexture () �����ȼ�����ͼƬ���ٻ��Ƶ���̨�У���ʵ�������У�Ҫʹ�õ�����laya.loader.load()��ص�����Handler.Create����������
drawTexture .
laya.loader.load(,Handler.create());
//Handler ���¼������ࡣ
//Handler �¼������࣬ Handler.create() �����Ӷ���ش����� ʹ�������Ի��� Handler.recover(); ���պ󲻿�ʹ�á�