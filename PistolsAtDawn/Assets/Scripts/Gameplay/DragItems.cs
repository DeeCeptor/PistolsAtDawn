using UnityEngine;
using System.Collections;


// Adds a sprint joint, resulting in springy movement if drags are low (<20), but it DOES NOT pass through walls
// http://forum.unity3d.com/threads/rigidbody2d-dragable-script.212168/

// Attach to object in scene. Any object with a rigidebody and a collider that is NOT kinematic can be dragged
public class DragItems : MonoBehaviour 
{
	public float distance = 0.0f;	// How far away the spring is set to move the object
	public float damper = 1.0f;
	public float frequency = 8.0f;
	public float drag = 30.0f;			// Resistance to movement. Lowering it makes the object oscillate due to the spring
	public float angularDrag = 30.0f;	// Resistance to rotation
	
	public bool attachToCenterOfMass = false;
	public LayerMask mask = -1;
	private SpringJoint2D springJoint;
	private Camera mainCamera;
	
	void Start() 
	{
		mainCamera = FindCamera ();
	}


	void Update () 
	{       
		if (!Input.GetMouseButtonDown (0))
			return;
		
		RaycastHit2D hit = Physics2D.Raycast (mainCamera.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);

		if (!hit.rigidbody || (hit.collider != null && hit.rigidbody.isKinematic == true)) 
			return;

		//if (hit.collider != null && hit.rigidbody.isKinematic == false) 

		if (!springJoint) 
		{
			GameObject go = new GameObject ("Rigidbody2D Dragger");
			Rigidbody2D body = go.AddComponent <Rigidbody2D>() as Rigidbody2D;
			springJoint = go.AddComponent <SpringJoint2D>() as SpringJoint2D;
			body.isKinematic = true;
			body.mass=0.0001f;
		}

		springJoint.transform.position = hit.point;

		if (attachToCenterOfMass) 
			springJoint.anchor = hit.rigidbody.centerOfMass;
		else 
			springJoint.anchor = Vector3.zero;
		
		springJoint.dampingRatio = damper;
		springJoint.distance = distance;
		springJoint.connectedBody = hit.rigidbody;

		// Make the anchor connected at the point we clicked on
		Vector3 localPoint = hit.transform.InverseTransformPoint (hit.point);
		springJoint.connectedAnchor = localPoint;
		/*
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//cameraController.mainCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector3 scale = transform.localScale;
		Vector3 inverseScale = new Vector3(1 / scale.x, 1 / scale.y, 1 / scale.z);
		Quaternion inverseRotation = Quaternion.Inverse(transform.rotation);
		Vector3 offset = mouseWorldPosition - transform.position;
		Vector3 mouseLocalPosition = Vector3.Scale(inverseScale, inverseRotation * offset);
		springJoint.anchor = mouseLocalPosition;*/

		StartCoroutine ("DragObject", hit.fraction);
	}


	IEnumerator DragObject (float distance) 
	{
		float oldDrag = springJoint.connectedBody.drag;
		float oldAngularDrag = springJoint.connectedBody.angularDrag;
		
		springJoint.connectedBody.drag = drag;
		springJoint.connectedBody.angularDrag = angularDrag;
		Camera mainCamera = FindCamera ();
		
		while (Input.GetMouseButton (0)) 
		{
			Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
			springJoint.transform.position = ray.GetPoint (distance);
			
			yield return null;
		}
		
		if (springJoint.connectedBody) 
		{
			Vector2 power = springJoint.connectedBody.velocity;
			power = power / (springJoint.connectedBody.mass + 1);

			springJoint.connectedBody.drag = 0.0f;//oldDrag;
			springJoint.connectedBody.angularDrag = 0.05f;//oldAngularDrag;
			springJoint.connectedBody = null;
		}
	}


	Camera FindCamera () 
	{
		/*if (this.camamera)
			return camera;
		else*/
			return Camera.main;
	}
}