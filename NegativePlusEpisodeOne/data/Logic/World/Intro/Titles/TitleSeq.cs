using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "591626ef636927820a35c0f9045df604eb9e0993")]
public class TitleSeq : Component
{
	private void Init()
	{
		// write here code to be called on component initialization
		Unigine.Console.Run("show_messages 1");
		



	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
			//	Unigine.Log.Message("Begun title sequence./n");
	}
}