using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class DragObject : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Rigidbody2D rigidbody;

	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
	}

	void OnMouseDown() {
		rigidbody.velocity = Vector2.zero;
		rigidbody.angularVelocity = 0;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		rigidbody.MovePosition(curPosition);
	}
}