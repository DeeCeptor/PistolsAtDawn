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
public class DragParentTransform : MonoBehaviour 
{
	public bool draggable = true;		// Is the object currently draggable?
	public bool rotatable = true;
	public Vector3 scrollDirection = Vector3.up;
	public Vector3 scrollDirection2 = Vector3.forward;

	private bool dragging = false;
	
	private GameObject parent;
	
	private Vector3 screenPoint;
	private Vector3 offset;
	
	private float interactionPlaneOffset = 3;	// The distance in FRONT of the camera that the interaction plane
	// is located. The plane is viewed head-on from the camera.
	
	
	void Start()
	{
		parent = this.transform.parent.gameObject;
	}
	
	
	/**
	 * Called when left mouse is clicked while it's over this collider.
	 * Reset variables for dragging around screen
	 */ 
	void OnMouseDown()
	{
		if(draggable)
		{
			// Set the Z of the screenPoint to be the plane with which the gun is situated
			screenPoint = Camera.main.WorldToScreenPoint(new Vector3(gameObject.transform.position.x,
			                                                         gameObject.transform.position.y,
			                                                         interactionPlaneOffset));
			
			// Offset of center of object to where the mouse cursor is when it's first clicked
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			
			// Reset rotation of object
			//transform.rotation = Quaternion.identity;
			
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
			dragging = true;
			
			// screenPoint.z is the distance in front of the camera (the interaction plane)
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			
			// Translate the mouse's position to a point in the world
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
			//rigidbody.MovePosition(curPosition);	// Use rigidbody to collide properly with other objects
			parent.transform.position = curPosition;
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
				parent.transform.Rotate(scrollDirection2 * rotationAmount);
			}
		}
		// Rotate object left and right
		else
		{
			// Scroll wheel
			float rotationAmount = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 10000;
			
			if(rotationAmount != 0)
			{
				parent.transform.Rotate (scrollDirection * rotationAmount);
			}
		}
	}
}