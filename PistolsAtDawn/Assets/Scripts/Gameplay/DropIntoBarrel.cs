using UnityEngine;
using System.Collections;

public class DropIntoBarrel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
	}
}
