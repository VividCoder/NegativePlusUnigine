using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "173ca1975aa4520a527119e10375e9cc397f1abb")]
public class UITitlesNG : Component
{
	
	private Gui tg;

	[ShowInEditor]
	public ObjectGui ObjUI;

	[ParameterMaterial]
	public Material ppMat;
	
	[ParameterFile]
	public List<string> Titles;

	[ParameterSlider(Min = 0.1f,Max = 30.0f)]
	public float TitleTime = 5.0f;

	private int curTitle = 0;
	private float titleEnd = 0;

	private Widget curWid = null;

	private Gui ui = null;

	private void nextTile(){

		if(curTitle>=Titles.Count)
		{
			return;
		}


		titleEnd = Game.Time + TitleTime;
		if(curWid!=null){

			ui.RemoveChild(curWid);

		}

		
string img_file = Titles[curTitle];

	Image i1 = new Image(img_file);
	
	WidgetSpriteShader s1 = new WidgetSpriteShader(ui,ppMat.Name);
	s1.Material = ppMat;
		s1.SetImage(i1,0);
		s1.SetPosition(20,20);
		s1.Width = 512;
		s1.Height = 128;

	

		ui.AddChild(s1,Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);

		curWid = s1;

		curTitle++;

	}

	private void Init()
	{
		// write here code to be called on component initialization
//		var ui = Gui.Get();

		titleEnd = Game.Time;

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
		
		if(Game.Time > titleEnd){

			Log.Message("Changing Title");
			nextTile();

		}

	}
}