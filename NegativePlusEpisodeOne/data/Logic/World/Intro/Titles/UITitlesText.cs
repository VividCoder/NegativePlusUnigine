using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "061d2e37afb3362ada376f814b4602ec3d33215b")]
public class UITitlesText : Component
{
	private Gui tg;

	[ShowInEditor]
	public ObjectGui ObjUI;

	
	[Parameter]
	public List<string> Titles;

	[ParameterSlider(Min = 0.1f,Max = 30.0f)]
	public float TitleTime = 5.0f;

	private int curTitle = 0;
	private float titleEnd = 0;

	private Widget curWid = null;

	private Gui ui = null;

	private List<WidgetLabel> curSprites = new List<WidgetLabel>();

	private void nextTile(){

		if(curTitle>=Titles.Count)
		{
			Log.Error("Nope");
			return;
		}


		titleEnd = Game.Time + TitleTime;
		if(curSprites.Count>0){

			for(int i = 0; i < 8; i++)
			{
				ui.RemoveChild(curSprites[i]);
			}


			curSprites.Clear();
//			ui.RemoveChild(curWid);

		}

		
string img_file = Titles[curTitle];

//	Image i1 = new Image(img_file);

	Log.Message("Title:"+img_file);

		float ang = 0;

		for (int i = 0; i < 8; i++)
		{

			float mx = Unigine.MathLib.Cos(ang) * 80;
			float my = Unigine.MathLib.Sin(ang) * 80;



			WidgetLabel s1 = new WidgetLabel(ui,img_file);
			s1.SetPosition(200+(int)mx, 200+(int)my);
			s1.Width = 512;
			s1.Height = 128;

			//int sc = Gui.BLEND_ONE;

		//	s1.SetBlendFunc(sc,Unigine.Gui.BLEND_ONE_MINUS_SRC_ALPHA);
	//		s1.SetLayerBlendFunc(0,sc, Unigine.Gui.BLEND_ONE_MINUS_SRC_ALPHA);
			ui.AddChild(s1, Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);

			ang = ang + 45;

			curSprites.Add(s1);

		}


		//curWid = s1;


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

		float tv = titleEnd - Game.Time;
		float rv = tv / TitleTime;
		rv = 1.0f - rv;

		float ang = 0.0f;

		if (curSprites.Count > 0)
		{
			for (int i = 0; i < 8; i++)
			{
				WidgetLabel s1 = curSprites[i];
//				s1.Color = new vec4(rv*0.3f, rv*0.3f, rv*0.3f, rv*0.3f);


	//ang = ang * Unigine.MathLib.DEG2RAD;


				float mx = Unigine.MathLib.Cos(ang) * 80 * (1.0f-rv);
				float my = Unigine.MathLib.Sin(ang) * 80 * (1.0f-rv);

				s1.SetPosition(200 + (int)mx, 200 + (int)my);

				ang = ang + 45;
			}
		}

	}
}