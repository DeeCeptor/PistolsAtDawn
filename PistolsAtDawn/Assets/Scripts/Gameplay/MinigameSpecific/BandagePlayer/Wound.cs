using UnityEngine;
using System.Collections;

/**
 * Wounds need to covered by a bandage to stop bleeding.
 */ 
public class Wound : MonoBehaviour 
{
	SpriteRenderer sprite;
	public BulletWound woundController;	// Script controlling this wound


	void Start () 
	{
		sprite = this.GetComponent<SpriteRenderer>();
	}


	void Update () 
	{

	}


	public void stopBleeding()
	{
		Debug.Log("Wound covered");
		sprite.enabled = false;
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bandage" && woundController.bleeding)
		{
			// Bandage has entered our wound region and then left it. Wound is now covered
			woundController.stopBleeding();
		}
	}
}
