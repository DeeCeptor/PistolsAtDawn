using UnityEngine;
using System.Collections;

public class ThreadString : Minigame 
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
		controller.threadString = true;
		base.endGame ();
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "String")
		{
			// Thread has reached end point. Done!
			endGame();
		}
	}
}
