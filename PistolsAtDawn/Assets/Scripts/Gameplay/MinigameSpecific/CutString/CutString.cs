using UnityEngine;
using System.Collections;

public class CutString : Minigame 
{
	void Start () 
	{
	
	}
	void Update () 
	{
	
	}


	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		controller.stringCut = true;
		base.endGame ();
	}
}
