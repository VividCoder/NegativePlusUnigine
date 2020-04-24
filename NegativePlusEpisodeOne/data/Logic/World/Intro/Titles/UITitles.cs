using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "7d31a23c3674186ba481d2cee722bbd527d65b30")]
public class UITitles : Component
{

	private Gui tg;

	[ShowInEditor]
	public ObjectGui ObjUI;

	
	[ParameterFile]
	public List<string> Titles;

	[ShowInEditor]
	public float TileTime;

	private int curTile = 0;
	private float tileEnd = 0;

	private Widget curWid = null;

	private Gui ui = null;

	private void nextTile(){

		if(curTile>=Titles.Count)
		{
			return;
		}


		tileEnd = Game.Time + TileTime; 
		if(curWid!=null){

			ui.RemoveChild(curWid);

		}

		
string img_file = Titles[curTile];

	Image i1 = new Image(img_file);
	
	WidgetSprite s1 = new WidgetSprite(ui);
		s1.SetImage(i1,0);
		s1.SetPosition(20,20);
		s1.Width = 512;
		s1.Height = 128;

		ui.AddChild(s1,Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);

		curWid = s1;

		curTile++;

	}

	private void Init()
	{
		// write here code to be called on component initialization
//		var ui = Gui.Get();

		tileEnd = Game.Time;

		ui = ObjUI.GetGui();


		WidgetLabel lab1 = new WidgetLabel(ui,"Testing and work!");
		lab1.SetToolTip("Works!");
		lab1.Arrange();
		lab1.SetPosition(10,10);


		ui.AddChild(lab1,Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);

		nextTile();
	
		Unigine.Console.Run("show_messages 1");

	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
		if(Game.Time > tileEnd){

			Log.Message("Changing Title");
			nextTile();

		}

	}
}