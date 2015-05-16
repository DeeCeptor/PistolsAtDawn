using UnityEngine;
using System.Collections;

public class CleanBarrelGame : Minigame 
{
	public int numDebris = 5;	// Spawns this many objects. All must be removed for game to finish
	public GameObject topLeftRegion;	// Marker marking top left boundary for spawning debris
	public GameObject bottomRightRegion;
	public GameObject debris;	// Debris spawned

	//transform the shine before ending game
	private int objectsRemaining;
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
		objectsRemaining = numDebris;

		// Populate area with random objects
		for (int x = 1; x <= numDebris; x++)
		{
			Instantiate(debris, new Vector3(Random.Range(topLeftRegion.transform.position.x, bottomRightRegion.transform.position.x), 
			                           Random.Range(topLeftRegion.transform.position.y, bottomRightRegion.transform.position.y), 0), 
			            Quaternion.identity);
		}


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
