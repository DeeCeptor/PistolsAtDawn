using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

/**
 * Script attached to objects that are draggable by the mouse.
 * Camera: 	0 6 0
 * 			40 0 0
 * 
 * http://en.wikipedia.org/wiki/Musket#Operation
 */ 
public class DraggableObject : MonoBehaviour 
{
	public bool enabled = true;		// Is the object currently draggable?
	public bool rotate = false;

	private Rigidbody rigidbody;

	private Vector3 screenPoint;
	private Vector3 offset;

	private float interactionPlaneOffset = 3;	// The distance in FRONT of the camera that the interaction plane
												// is located. The plane is viewed head-on from the camera.


	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody>();
		rigidbody.velocity = Vector3.zero;
	}


	/**
	 * Called when left mouse is clicked while it's over this collider.
	 */ 
	void OnMouseDown()
	{
		if(enabled)
		{
			// Completely stop object from moving after it's selected
			rigidbody.useGravity = false;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;

			// Set the Z of the screenPoint to be the plane with which the gun is situated
			screenPoint = Camera.main.WorldToScreenPoint(new Vector3(gameObject.transform.position.x,
			                                                         gameObject.transform.position.y,
				                                                     interactionPlaneOffset));

			// Offset of center of object to where the mouse cursor is when it's first clicked
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}


	/**
	 * Called when the mouse is released ovr this collider.
	 */ 
	void OnMouseUp()
	{
		if(enabled)
		{
			rigidbody.useGravity = true;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;
		}
	}


	/**
	 * Called when the mouse is moving while left mouse is being held down and OnMouseDown was called previously.
	 */ 
	void OnMouseDrag()
	{
		if(enabled)
		{
			// screenPoint.z is the distance in front of the camera (the interaction plane)
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

			// Translate the mouse's position to a point in the world
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
			rigidbody.MovePosition(curPosition);	// Use rigidbody to collide properly with other objects
			//transform.position = curPosition;
		}
	}

}