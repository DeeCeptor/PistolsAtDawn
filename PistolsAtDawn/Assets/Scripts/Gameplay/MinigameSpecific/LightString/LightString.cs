using UnityEngine;
using System.Collections;

public class LightString : Minigame 
{


	void Update () 
	{
	
	}

	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		controller.stringLit = true;
		base.endGame ();
	}
}
