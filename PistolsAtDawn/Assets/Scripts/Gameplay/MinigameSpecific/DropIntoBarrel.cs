using UnityEngine;
using System.Collections;

public class DropIntoBarrel : Minigame {

	void Start () {
	
	}


	public override void startGame()
	{
		Debug.Log ("Clean");
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		base.endGame ();
	}


	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Bullet") 
		{
			Debug.Log("Bullet put in barrel");
			other.gameObject.GetComponent<DragObject>().stopDragging();
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "Powder") 
		{
			Debug.Log("Powder in barrel");
			Destroy (other.gameObject);
		}
	}
}
