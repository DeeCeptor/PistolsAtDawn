using UnityEngine;
using System.Collections;

public class FindMinigame : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Bullet") 
		{
			Debug.Log("Bullet found");
			other.gameObject.GetComponent<DragObject>().stopDragging();
			Destroy (other.gameObject);

		}
	}
}
