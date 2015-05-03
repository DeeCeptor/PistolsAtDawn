using UnityEngine;
using System.Collections;

public class LightMatch : Minigame 
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
		Debug.Log("Match lit");
		controller.matchLit = true;
		base.endGame ();
	}
}
