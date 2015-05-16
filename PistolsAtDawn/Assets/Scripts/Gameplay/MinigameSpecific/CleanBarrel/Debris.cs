using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {

	//Array containing potential individual sprites
	//this would be better in some sort of debris controller that also instantiates prefabs
	public Sprite[] debrisSprites;

	void Start () 
	{
		//declare a random sprite from a set
		int spriteRandomizer = Random.Range (0, debrisSprites.Length - 1);
		GetComponent<SpriteRenderer> ().sprite = debrisSprites [spriteRandomizer];
	}
	
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		// If ramrod touches the debris, turn on gravity
		if (other.gameObject.tag == "Ramrod") 
		{
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}
}
