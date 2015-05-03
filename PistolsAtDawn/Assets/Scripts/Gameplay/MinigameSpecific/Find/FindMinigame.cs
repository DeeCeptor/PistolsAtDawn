using UnityEngine;
using System.Collections;

public class FindMinigame : Minigame 
{

	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		base.endGame ();
	}


	void loadBarrelCheck()
	{
		if (controller.numBulletsfound > 0 && 
			controller.paperFound &&
			controller.powderFound &&
		    controller.stringFound &&
		    controller.alcoholFound &&
		    controller.matchFound)
		{
			Debug.Log("All items found");
			this.endGame();
		}
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Bullet") 
		{
			Destroy (other.gameObject);
			controller.numBulletsfound++;
		}
		else if (other.gameObject.tag == "String") 
		{
			Destroy (other.gameObject);
			controller.stringFound = true;
		}
		else if (other.gameObject.tag == "Match") 
		{
			Destroy (other.gameObject);
			controller.matchFound = true;
		}
		else if (other.gameObject.tag == "Flask") 
		{
			Destroy (other.gameObject);
			controller.powderFound = true;
		}
		else if (other.gameObject.tag == "Alcohol") 
		{
			Destroy (other.gameObject);
			controller.alcoholFound = true;
		}
		else if (other.gameObject.tag == "Paper") 
		{
			Destroy (other.gameObject);
			controller.paperFound = true;
		}

		loadBarrelCheck();
	}
}
