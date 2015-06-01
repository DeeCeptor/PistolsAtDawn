using UnityEngine;
using System.Collections;

/**
 * Wounds need to covered by a bandage to stop bleeding.
 */ 
public class Wound : MonoBehaviour 
{
	SpriteRenderer sprite;
	bool bleeding = true;

	void Start () 
	{
		sprite = this.GetComponent<SpriteRenderer>();
	}
	
	void Update () 
	{

	}

	void stopBleeding()
	{
		Debug.Log("Wound covered");
		bleeding = false;
		sprite.enabled = false;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bandage" && !bleeding)
		{
			// Bandage has entered our wound region and then left it. Wound is now covered

		}
	}
}
