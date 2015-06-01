using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthController : MonoBehaviour 
{
	public float HP = 100;
	private float maxHP;
	float woundDamage = 1;

	LinkedList<BulletWound> all_wounds = new LinkedList<BulletWound>();

	void Start () 
	{
		maxHP = HP;
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
				wound.timeTillBleedsAgain -= Time.deltaTime;

				if (wound.timeTillBleedsAgain <= 0)
				{
					// Resume bleeding
					wound.startBleeding();
				}
			}
		}

		// Is our health at 0? Then we lose
		if (HP <= 0)
		{
			Debug.Log("HP < 0, BLED OUT!");
		}
	}


	// Display health
	void OnGUI()
	{
		GUI.contentColor = Color.red;
		GUI.Label(new Rect(10, 20, 200, 100), HP + " / " + maxHP);
	}
}
