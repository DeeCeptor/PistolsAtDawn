using UnityEngine;
using System.Collections;

public class Alcohol : Minigame 
{
	int desiredAlcoholLevel = 20;	// Game is over when get to this level

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
		base.endGame ();
	}
	public void AlcoholEnteredMouth()
	{
		controller.alcoholLevel++;
		if (controller.alcoholLevel >= desiredAlcoholLevel)
		{
			// Game is over if we got enough alcohol
			this.endGame();
		}
	}


	void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(10, 10, 200, 100), "Alcohol Level: " + controller.alcoholLevel + " / " + desiredAlcoholLevel);
	}
}
