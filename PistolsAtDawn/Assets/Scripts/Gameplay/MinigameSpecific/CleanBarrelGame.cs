using UnityEngine;
using System.Collections;

public class CleanBarrelGame : Minigame 
{

	void Start () 
	{
	
	}


	public override void startGame()
	{
		Debug.Log ("Clean");
		base.startGame ();
	}


	public override void endGame()
	{
		base.endGame ();
	}

	
	void Update () 
	{
	
	}
}
