using UnityEngine;
using System.Collections;

public class DropIntoBarrel : Minigame 
{
	private bool bulletIn;


	void Start () {
	
	}
	void Update () {
		
	}


	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		base.endGame ();
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Bullet") 
		{
			Debug.Log("Bullet put in barrel");
			controller.numBulletsfound--;
			controller.bulletInBarrel = true;
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "Paper" && controller.bulletInBarrel) 
		{
			Debug.Log("Paper in barrel");
			controller.paperInBarrel = true;
			Destroy (other.gameObject);
			this.endGame();
		}
	}
}
