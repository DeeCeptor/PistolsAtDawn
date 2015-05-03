using UnityEngine;
using System.Collections;

public class RamrodBarrel : Minigame 
{
	bool paperIn, bulletIn = false;	// Have these objects been pushed down the barrel enough?


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
		controller.ramrodBarrel = true;
		base.endGame ();
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		// Check if paper and bullet have been pushed in
		if (other.gameObject.tag == "Bullet")
		{
			bulletIn = true;
			Debug.Log("Bullet in");
			CheckEnd();
		}
		if (other.gameObject.tag == "Paper")
		{
			paperIn = true;
			Debug.Log("Paper in");
			CheckEnd();
		}
	}
	void CheckEnd()
	{
		if (paperIn && bulletIn)
			endGame();
	}
}
