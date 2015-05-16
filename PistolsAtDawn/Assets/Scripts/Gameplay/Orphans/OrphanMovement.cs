using UnityEngine;
using System.Collections;

public class OrphanMovement : MonoBehaviour 
{
	MinigameController controller;
	bool movingLeft = true;
	Rigidbody2D physics;
	float speed = 7f;
	bool holdingGun = false;
	bool spinning = false;
	GameObject gunSprite;

	void Start () 
	{
		controller = GameObject.Find("MinigameController").GetComponent<MinigameController>();
		physics = this.GetComponent<Rigidbody2D>();
		gunSprite = this.transform.FindChild("HeldGun").gameObject;

		if (movingLeft)
			moveLeft();
	}
	void Update () 
	{

	}


	void moveLeft()
	{
		physics.velocity = new Vector3(-speed, 0, 0);
	}
	void moveRight()
	{
		physics.velocity = new Vector3(speed, 0, 0);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (!spinning)
		{
			if (other.tag == "Player")
			{
				// Hit player, disable their minigames cause he stole their gun
				if (controller.hasGun)
				{
					Debug.Log("Gun stolen!");
					controller.hasGun = false;
					holdingGun = true;
					controller.abortGame();
					controller.hideIcons();
					gunSprite.SetActive(true);
				}

				moveRight();
			}
			else if (other.tag == "Boundary")
			{
				moveLeft();
			}
		}
	}


	void OnMouseDown()
	{
		// Remove orphan if clicked on
		Debug.Log("Smack!");
		if (holdingGun)
		{
			controller.hasGun = true;
			spinning = true;
			holdingGun = false;
			controller.showIcons();
			gunSprite.SetActive(false);
		}
		physics.angularVelocity = 300.0f;	// Set orphan spinning
		physics.velocity = new Vector3(physics.velocity.x, 30.0f, 0);
		Invoke ("remove", 2);	// Remove object after some time to let it spin out
	}
	void remove()
	{
		Destroy (this.gameObject);
	}
}
