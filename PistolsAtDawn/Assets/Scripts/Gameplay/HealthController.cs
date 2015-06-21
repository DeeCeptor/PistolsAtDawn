using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Controls HP of character and controls wounds and damage.
 * Wounds have gameObjects with Wound objects
 * Each wound object has a BulletWound script living in HealthController
 */ 
public class HealthController : MonoBehaviour 
{
	public static HealthController health_controller;
	public float HP = 100;
	private float maxHP;
	float woundDamage = 1;
	public BandagePlayer bandage_game;	// Drag bandage minigame onto this field in the inspector

	LinkedList<BulletWound> all_wounds = new LinkedList<BulletWound>();


	void Start () 
	{
		health_controller = this;
		maxHP = HP;
		bandage_game.controller = GameObject.Find ("MainView").transform.FindChild("MinigameController").GetComponent<MinigameController> ();
	}


	public void minorlyWoundPlayer()
	{
		GameObject wound_obj = bandage_game.createMinorWound();
		BulletWound bullet_wound = new BulletWound(5.0f, wound_obj.GetComponent<Wound>());
		wound_obj.GetComponent<Wound>().woundController = bullet_wound;
		bullet_wound.wound_sprite = wound_obj.GetComponent<Wound>();
		all_wounds.AddFirst(bullet_wound);
	}

	
	void Update () 
	{
		// Update wounds
		foreach (BulletWound wound in all_wounds)
		{
			if (wound.bleeding)
			{
				// Apply damage if bleeding
				if (wound.majorWound)
					HP -= woundDamage * 2 * Time.deltaTime;	// Take double damage from major wounds
				else
					HP -= woundDamage * Time.deltaTime;
			}
			else
			{
				// Advance time till bandage comes off
				wound.curTimeTillBleedsAgain -= Time.deltaTime;

				if (wound.curTimeTillBleedsAgain <= 0)
				{
					// Resume bleeding
					Debug.Log("bandage came off");
					wound.startBleeding();
				}
			}
		}

		// Is our health at 0? Then we lose
		if (HP <= 0)
		{
			Debug.Log("HP < 0, BLED OUT!");
			Die ();
		}
	}


	//Wil William, place dying cutscene code here
	public void Die()
	{

	}


	// Display health
	void OnGUI()
	{
		GUI.contentColor = Color.red;
		GUI.Label(new Rect(10, 20, 200, 100), HP + " / " + maxHP);
	}
}
