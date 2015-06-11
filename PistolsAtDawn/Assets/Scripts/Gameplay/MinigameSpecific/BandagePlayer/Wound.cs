using UnityEngine;
using System.Collections;

/**
 * Wounds need to covered by a bandage to stop bleeding.
 */ 
public class Wound : MonoBehaviour 
{
	SpriteRenderer sprite;
	public BulletWound woundController;	// Script controlling this wound
	BandagePlayer minigame;


	void Start () 
	{
		sprite = this.GetComponent<SpriteRenderer>();
		minigame = GameObject.Find("BandagePlayer").GetComponent<BandagePlayer>();
	}


	void Update () 
	{

	}


	public void stopBleeding()
	{
		Debug.Log("Wound covered");
		this.gameObject.SetActive(false);
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
