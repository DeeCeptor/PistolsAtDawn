using UnityEngine;
using System.Collections;

public class PowderPan : Minigame 
{
	public int powderRemaining = 1;	// How many powder particles need to hit the pan
	public bool panOpen = false;		// Pan must be open to pour powder in


	void Start () 
	{
	
	}
	void Update () 
	{
	
	}


	public void powderEnteredPan()
	{
		powderRemaining--;
		if (powderRemaining <= 0)
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
		controller.powderInPan = true;
		base.endGame ();
	}


	
	void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(10, 10, 200, 100), "Powder needed: " + powderRemaining);
	}
}
