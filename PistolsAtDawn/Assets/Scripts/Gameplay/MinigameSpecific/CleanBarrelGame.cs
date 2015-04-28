using UnityEngine;
using System.Collections;

public class CleanBarrelGame : Minigame 
{
	int objectsRemaining = 5;	// Spawns this many objects. All must be removed for game to finish

	void Start () {
	
	}
	void Update () {
		
	}


	public override void startGame()
	{
		// Populate are with random objects
		//Random.Range


		base.startGame ();
	}


	public override void endGame()
	{
		controller.setMinigameAvailable ("InsertIntoBarrel");
		base.endGame ();
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Debris") 
		{
			objectsRemaining--;
			Destroy (other.gameObject);

			// End minigame if all objects have been removed from barrel
			if (objectsRemaining <= 0)
			{
				this.endGame();
			}
		}
	}
}
