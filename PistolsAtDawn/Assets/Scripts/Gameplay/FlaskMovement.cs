using UnityEngine;
using System.Collections;

public class FlaskMovement : MonoBehaviour 
{
	Rigidbody2D rigidbody;
	private float xMovementRate = 3f;
	private float yMovementRate = 3f;
	private float rotationRate = 100f;
	private float maxRotationRate = 140f;

	void Start () 
	{
		rigidbody = this.GetComponent<Rigidbody2D> ();
	}
	
	void Update () 
	{
		// Take input to move
		Vector2 curPosition = rigidbody.position;
		
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
		
		rigidbody.MovePosition (curPosition);
		
		
		// Set rotation
		float curTorque = 0;
		
		// Only allow the gun to rotate in this direction if we aren't already going too fast
		if (rigidbody.angularVelocity < maxRotationRate) 
		{
			if (Input.GetKey (KeyCode.Q))
				curTorque = rotationRate * Time.deltaTime;
		}
		
		if (rigidbody.angularVelocity > -maxRotationRate) 
		{
			if (Input.GetKey (KeyCode.E))
				curTorque = -rotationRate * Time.deltaTime;
		}
		
		rigidbody.AddTorque (curTorque);
	}
}
