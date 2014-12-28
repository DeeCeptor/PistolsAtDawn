using UnityEngine;
using System.Collections;

// Class handling features of the gun
public class Gun : MonoBehaviour {

	bool sideways = false;	// Whether the gun is viewed from the rear, or sideways
	GameObject sidewaysGun;	// Gun viewed sideways
	GameObject defaultGun;	// Gun not sideways

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}


	// Update is called once per frame
	void Update () 
	{
		// If the gun is rotated, change its properties
		if (Input.GetButtonDown("Rotate Gun"))
		{
			RotateGun(sideways);
		}

		if (sideways) 
		{

		}
	}


	void RotateGun(bool currentlyFacingSideways)
	{
		if (currentlyFacingSideways) 
		{
			RotateGunToDefaultPosition();
		} 
		else 
		{
			RotateGunSideways();
		}
	}


	public void RotateGunToDefaultPosition()
	{
		//spriteRenderer.sprite
	}


	public void RotateGunSideways()
	{

	}
}
