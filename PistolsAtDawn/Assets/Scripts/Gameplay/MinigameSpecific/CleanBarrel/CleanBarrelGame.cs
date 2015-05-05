using UnityEngine;
using System.Collections;

public class CleanBarrelGame : Minigame 
{
	int objectsRemaining = 5;	// Spawns this many objects. All must be removed for game to finish

	//transform the shine before ending game
	GameObject shine;
	Vector3 translationPosition;
	bool shineSend = false;

	void Start () {
		shine = GameObject.Find ("CleanShine");
		translationPosition = shine.transform.position;
		translationPosition.y = 20.0f; //magic number to represent past top of screen
	}

	void Update () {
		if(shineSend)
		{
			shine.transform.position = Vector3.MoveTowards(shine.transform.position,//from
			                                        translationPosition,	//to
			                                        0.3f);					//time taken
		}
	}


	public override void startGame()
	{
		// Populate area with random objects
		//Random.Range


		base.startGame ();
	}


	public override void endGame()
	{
		controller.barrelCleaned = true;
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
				//send shine
				shineSend = true;

				Invoke("endGame", 1);
				//this.endGame();
			}
		}
	}
}
