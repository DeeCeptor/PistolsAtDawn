using UnityEngine;
using System.Collections;

public class LightString : Minigame 
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
		controller.stringLit = true;
		base.endGame ();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "MatchHead")
		{
			// Play naimation here

			// Use invoke to delay ending of minigame, so we can show animation of match being lit
			Invoke("endGame", 1);
		}
	}
}
