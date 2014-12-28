using UnityEngine;
using System.Collections;


public class DragObject : MonoBehaviour 
{
	private Rigidbody2D rigidbody;		// Our rigidbody
	private BoxCollider2D ourCollider;

	private GameObject hand;			// Hand we may or may not be connected to via a hinge joint
	private Rigidbody2D handRigidbody;
	private HingeJoint2D connectingHinge;

	bool dragging = false;


	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		ourCollider = this.GetComponent<BoxCollider2D> ();
		hand = GameObject.Find("Hand");
		handRigidbody = hand.GetComponent<Rigidbody2D>();

		connectingHinge = gameObject.AddComponent<HingeJoint2D>();
		connectingHinge.enabled = false;
	}


	void OnMouseDown() {
		//rigidbody.velocity = Vector2.zero;
		//rigidbody.angularVelocity = 0;
		dragging = true;

		// Set anchor to offset of current hand position relative to the object.
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mouseLocalPosition = Quaternion.Inverse(transform.rotation) * (mouseWorldPosition - transform.position);
		connectingHinge.enabled = true;
		//connectingHinge.connectedBody = handRigidbody;
		connectingHinge.connectedAnchor = mouseWorldPosition;
		connectingHinge.anchor = mouseLocalPosition;
	}


	void OnMouseUp() 
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
			connectingHinge.connectedAnchor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}