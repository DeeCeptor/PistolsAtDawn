using UnityEngine;
using System.Collections;

public class PowderBarrel : Minigame {

	public int powderNeeded = 20;	// How many powder particles need to hit the pan


	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}


	public void powderEntered()
	{
		powderNeeded--;
		if (powderNeeded <= 0)
		{
			endGame();
		}
	}


	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		controller.powderInBarrel = true;
		base.endGame ();
	}
	
	
	
	void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(10, 10, 200, 100), "Powder needed: " + powderNeeded);
	}
}
