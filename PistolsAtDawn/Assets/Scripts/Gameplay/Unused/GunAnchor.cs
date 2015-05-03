using UnityEngine;
using System.Collections;

public class GunAnchor : MonoBehaviour 
{
	// Gun that we're attached to
	private GameObject gun;
	private Rigidbody2D gunRigidbody;
	private Rigidbody2D rigidbody;

	private float xMovementRate = 3f;
	private float yMovementRate = 3f;
	private float rotationRate = 2000f;
	private float maxRotationRate = 140f;

	void Start () 
	{
		this.rigidbody = this.GetComponent<Rigidbody2D> ();
		gun = GameObject.Find("Gun");
		gunRigidbody = gun.GetComponent<Rigidbody2D> ();
		this.transform.position = gun.transform.position;
	}
	
	void Update () 
	{
		// Take input to move
		Vector2 curPosition = this.rigidbody.position;

		// Vertical movement
		if (Input.GetKey (KeyCode.W))
			curPosition.y += yMovementRate * Time.deltaTime;
		else if (Input.GetKey (KeyCode.S))
			curPosition.y -= yMovementRate * Time.deltaTime;

		// Horizontal movement
		if (Input.GetKey (KeyCode.A))
			curPosition.x -= xMovementRate * Time.deltaTime;
		else if (Input.GetKey (KeyCode.D))
			curPosition.x += xMovementRate * Time.deltaTime;

		this.rigidbody.MovePosition (curPosition);


		// Set rotation
		float curTorque = 0;

		// Only allow the gun to rotate in this direction if we aren't already going too fast
		if (gunRigidbody.angularVelocity < maxRotationRate) 
		{
			if (Input.GetKey (KeyCode.Q))
				curTorque = rotationRate * Time.deltaTime;
		}

		if (gunRigidbody.angularVelocity > -maxRotationRate) 
		{
			if (Input.GetKey (KeyCode.E))
				curTorque = -rotationRate * Time.deltaTime;
		}

		this.gunRigidbody.AddTorque (curTorque);
	}
}
