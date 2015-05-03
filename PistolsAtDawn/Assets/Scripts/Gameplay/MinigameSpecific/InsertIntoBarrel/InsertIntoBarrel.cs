using UnityEngine;
using System.Collections;

public class InsertIntoBarrel : Minigame 
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
	
	
	public void taggedObjectEntered(GameObject obj)
	{
		if (obj.tag == "Bullet") 
		{
			Debug.Log("Bullet put in barrel");
			controller.numBulletsfound--;
			controller.bulletInBarrel = true;
			Destroy (obj);
		}
		else if (obj.tag == "Paper" && controller.bulletInBarrel) 
		{
			Debug.Log("Paper in barrel");
			controller.paperInBarrel = true;
			Destroy (obj);
			this.endGame();
		}
	}}
