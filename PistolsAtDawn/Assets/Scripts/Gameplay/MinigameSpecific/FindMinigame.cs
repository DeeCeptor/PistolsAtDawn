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
			controller.powderFound)
			controller.setMinigameAvailable ("InsertIntoBarrel");
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Bullet") 
		{
			//other.gameObject.GetComponent<DragObject>().stopDragging();
			Destroy (other.gameObject);
			controller.numBulletsfound++;
			loadBarrelCheck();
		}
		else if (other.gameObject.tag == "String") 
		{
			Destroy (other.gameObject);
			controller.stringFound = true;
		}
		else if (other.gameObject.tag == "Match") 
		{
			Destroy (other.gameObject);
			controller.stringFound = true;
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
			loadBarrelCheck();
		}

		controller.minigameChecklist ();
	}
}
