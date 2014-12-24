using UnityEngine;
using System.Collections;


public class DragObject : MonoBehaviour 
{
	private Vector3 screenPoint;
	private Vector3 offset;

	private Rigidbody2D rigidbody;		// Our rigidbody


	private GameObject hand;			// Hand we may or may not be connected to via a hinge joint
	private Rigidbody2D handRigidbody;
	private HingeJoint2D connectingHinge;


	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		hand = GameObject.Find("Hand");
		handRigidbody = hand.GetComponent<Rigidbody2D>();
	}


	void OnMouseDown() {
		//rigidbody.velocity = Vector2.zero;
		//rigidbody.angularVelocity = 0;

		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//offset = this.transform.localPosition - hand.transform.localPosition;
		//offset = transform.InverseTransformPoint(offset) - transform.position;
		//gameObject.transform.localPosition

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if(hit.collider != null)
		{
			Debug.Log ("Target Position: " + hit.point + " " + this.transform.TransformPoint(hit.point));
			offset = this.transform.TransformPoint(hit.point) - transform.position;
		}

		BoxCollider2D collider = this.GetComponent<BoxCollider2D>();


		//Debug.Log(offset);

		// Create a hinge joint between the hand and this object so object will slowly rotate
		// around the hinge point
		//hand.AddComponent("HingeJoint2D");
		this.gameObject.AddComponent("HingeJoint2D");
		//connectingHinge = hand.GetComponent<HingeJoint2D>();
		connectingHinge = this.GetComponent<HingeJoint2D>();
		connectingHinge.connectedBody = handRigidbody;

		// Set anchor to offset of current hand position relative to the object.
		//connectingHinge.anchor = new Vector2(offset.x, offset.y);
	}


	void OnMouseUp() 
	{
		// Destroy the connecting hinge to let go of this object
		Destroy(connectingHinge);
	}


	void OnMouseDrag()
	{
		//Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		//rigidbody.MovePosition(curPosition);
	}
}