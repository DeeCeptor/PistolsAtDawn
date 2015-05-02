using UnityEngine;
using System.Collections;

// Object is made kinematic if the mouse is not being clicked on it
public class MouseKinematic : MonoBehaviour 
{
	Rigidbody2D physics;

	void Start () 
	{
		physics = this.GetComponent<Rigidbody2D>();
		physics.isKinematic = true;
	}
	
	void Update () 
	{
	
	}


	void OnMouseDown()
	{
		physics.isKinematic = false;
	}
	void OnMouseUp()
	{
		physics.isKinematic = true;
	}
}
