using UnityEngine;
using System.Collections;

public class AlcoholMouthTrigger : MonoBehaviour 
{
	Alcohol script;

	void Start () 
	{
		script = GameObject.Find("Alcohol").GetComponent<Alcohol>();
	}
	void Update () 
	{
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Alcohol") 
		{
			Debug.Log("Alcohol in mouth");
			script.AlcoholEnteredMouth();
			Destroy (other.gameObject);		
		}
	}
}
