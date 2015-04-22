using UnityEngine;
using System.Collections;


public class DragObject : MonoBehaviour 
{
	private Rigidbody2D rigidbody;		// Our rigidbody
	private BoxCollider2D ourCollider;

	private GameObject hand;			// Hand we may or may not be connected to via a hinge joint
	private Rigidbody2D handRigidbody;
	private HingeJoint2D connectingHinge;
	private CameraController cameraController;

	bool dragging = false;


	void Start()
	{
		cameraController = GameObject.Find ("CameraController").GetComponent<CameraController>();
		rigidbody = this.GetComponent<Rigidbody2D>();
		ourCollider = this.GetComponent<BoxCollider2D> ();
		hand = GameObject.Find("Hand");
		handRigidbody = hand.GetComponent<Rigidbody2D>();

		connectingHinge = gameObject.AddComponent<HingeJoint2D>();
		connectingHinge.enabled = false;
	}


	void OnMouseDown() 
	{
		setOffsetAnchor();
	}
	// Anchors this object to the mouse by creating a hinge joint.
	// The joint is attached to this object exactly where it's being clicked on.
	public void setOffsetAnchor()
	{
		rigidbody.velocity = Vector2.zero;
		rigidbody.angularVelocity = 0;
		dragging = true;
		
		// Set anchor to offset of current hand position relative to the object.
		Vector3 mouseWorldPosition = cameraController.mainCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector3 scale = transform.localScale;
		Vector3 inverseScale = new Vector3(1 / scale.x, 1 / scale.y, 1 / scale.z);
		Quaternion inverseRotation = Quaternion.Inverse(transform.rotation);
		Vector3 offset = mouseWorldPosition - transform.position;
		Vector3 mouseLocalPosition = Vector3.Scale(inverseScale, inverseRotation * offset);
		
		connectingHinge.enabled = true;
		connectingHinge.connectedBody = handRigidbody;
		//connectingHinge.connectedAnchor = mouseWorldPosition;
		connectingHinge.anchor = mouseLocalPosition;
	}
	// Attaches an anchor point to the hand at the center of the object
	public void setCenterAnchor()
	{
		rigidbody.velocity = Vector2.zero;
		rigidbody.angularVelocity = 0;
		dragging = true;

		connectingHinge.enabled = true;
		connectingHinge.connectedBody = handRigidbody;
		//connectingHinge.connectedAnchor = mouseWorldPosition;
		connectingHinge.anchor = this.transform.position;
	}


	void OnMouseUp() 
	{
		stopDragging ();
	}
	public void stopDragging()
	{
		dragging = false;
		connectingHinge.enabled = false;
	}


	void OnMouseDrag()
	{
		//Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		//rigidbody.MovePosition(curPosition);
	}

	void Update()
	{
		if (dragging)
		{
			//connectingHinge.connectedAnchor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}