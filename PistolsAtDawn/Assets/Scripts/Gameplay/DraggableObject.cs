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
	public bool draggable = true;		// Is the object currently draggable?
	public bool rotatable = true;
	public Vector3 scrollDirection = Vector3.up;
	public Vector3 scrollDirection2 = Vector3.forward;

	private bool dragging = false;

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
	 * Reset variables for dragging around screen
	 */ 
	void OnMouseDown()
	{
		if(draggable)
		{
			// Completely stop object from moving after it's selected
			rigidbody.useGravity = false;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;

			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

			// Set the Z of the screenPoint to be the plane with which the gun is situated
			screenPoint = Camera.main.WorldToScreenPoint(new Vector3(gameObject.transform.position.x,
			                                                         gameObject.transform.position.y,
				                                                     interactionPlaneOffset));

			// Offset of center of object to where the mouse cursor is when it's first clicked
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

			// Reset rotation of object
			transform.rotation = Quaternion.identity;

			v3StartPos = Input.mousePosition;
			v3StartRot = transform.eulerAngles;
			v3ChangedPos = v3StartPos;
		}
	}


	/**
	 * Called when the mouse is released ovr this collider.
	 */ 
	void OnMouseUp()
	{
		if(draggable)
		{
			dragging = false;

			rigidbody.constraints = RigidbodyConstraints.None;
			rigidbody.useGravity = true;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.velocity = Vector3.zero;
		}
	}

	private float horizontalRotationalFactor = 3f;
	private float verticalRotationalFactor = 5f;
	private Vector3 v3StartPos;
	private Vector3 v3StartRot;
	private Vector3 v3ChangedPos;
	
	/**
	 * Called when the mouse is moving while left mouse is being held down and OnMouseDown was called previously.
	 */ 
	void OnMouseDrag()
	{
		if(rotatable)
			Rotate ();

		if(draggable)
		{
			// Move object around screen
			Screen.lockCursor = false;
			dragging = true;
			
			// screenPoint.z is the distance in front of the camera (the interaction plane)
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			
			// Translate the mouse's position to a point in the world
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
			rigidbody.MovePosition(curPosition);	// Use rigidbody to collide properly with other objects
		}
	}


	void Rotate()
	{
		// Holding right click and scrolling rotates object up and down
		if(Input.GetButton ("Right Mouse"))
		{
			// Scroll wheel
			float rotationAmount = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 10000;
			
			if(rotationAmount != 0)
			{
				transform.Rotate(scrollDirection2 * rotationAmount);
			}
			
			//Screen.lockCursor = true;
			/*
				// Record how much the mouse position has changed since the start of the rotation
				v3ChangedPos.x += Input.GetAxis("Mouse X");
				v3ChangedPos.y += Input.GetAxis("Mouse Y");

				// Rotate object left and right
				transform.localEulerAngles = v3StartRot + Vector3.up * (v3StartPos - v3ChangedPos).x * horizontalRotationalFactor;

				// USe the mouse's change in Y position to rotate the object UP
				transform.Rotate (Vector3.left * v3ChangedPos.y * verticalRotationalFactor);
				*/
		}
		// Rotate object left and right
		else
		{
			// Scroll wheel
			float rotationAmount = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 10000;
			
			if(rotationAmount != 0)
			{
				transform.Rotate (scrollDirection * rotationAmount);
			}
		}
	}
	
	
	void Update()
	{
		if(dragging && rotatable)
		{

		}
	}
}