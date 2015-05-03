using UnityEngine;
using System.Collections;

public class CockHammer : Minigame 
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
		controller.cockHammer = true;
		base.endGame ();
	}
}
