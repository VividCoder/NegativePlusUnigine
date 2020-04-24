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
	public string img1_file;

	private void Init()
	{
		// write here code to be called on component initialization
//		var ui = Gui.Get();

		Gui ui = ObjUI.GetGui();


		WidgetLabel lab1 = new WidgetLabel(ui,"Testing and work!");
		lab1.SetToolTip("Works!");
		lab1.Arrange();
		lab1.SetPosition(10,10);


		ui.AddChild(lab1,Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);


	Image i1 = new Image(img1_file);
	
	WidgetSprite s1 = new WidgetSprite(ui);
		s1.SetImage(i1,0);
		s1.SetPosition(20,20);
		s1.Width = 128;
		s1.Height = 128;

		ui.AddChild(s1,Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);
	

	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}