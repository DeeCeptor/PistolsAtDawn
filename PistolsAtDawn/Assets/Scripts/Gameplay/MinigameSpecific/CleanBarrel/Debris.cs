using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {

	void Start () 
	{
	
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
