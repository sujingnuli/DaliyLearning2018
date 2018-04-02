package 
{
	/**
	 * ...
	 * @author
	 */
	import laya.display.Text;
	public class MyLaya{
		public function MyLaya(){
			Laya.init(500,200);
			var txt:Text=new Text();
			txt.text="Hello world";
			Laya.stage.addChild(txt);
		}
	}

}