using UnityEngine;
using System.Collections;

public class Ramrod : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name == "End Of Barrel") 
		{
			Debug.Log ("enter barrel");
			this.gameObject.layer = LayerMask.NameToLayer ("Ramrod");
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "End of Barrel") 
		{
			Debug.Log ("exit barrel");
			this.gameObject.layer = LayerMask.NameToLayer ("Table");
		}
	}
}
