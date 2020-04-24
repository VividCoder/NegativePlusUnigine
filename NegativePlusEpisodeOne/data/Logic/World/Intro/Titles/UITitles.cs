using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "7d31a23c3674186ba481d2cee722bbd527d65b30")]
public class UITitles : Component
{

	private Gui tg;

	[ShowInEditor]
	public ObjectGui oui;

	private void Init()
	{
		// write here code to be called on component initialization
//		var ui = Gui.Get();

		Gui ui = oui.GetGui();


		WidgetLabel lab1 = new WidgetLabel(ui,"Testing and work!");
		lab1.SetToolTip("Works!");
		lab1.Arrange();
		lab1.SetPosition(10,10);


		ui.AddChild(lab1,Gui.ALIGN_OVERLAP | Gui.ALIGN_FIXED);



	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}