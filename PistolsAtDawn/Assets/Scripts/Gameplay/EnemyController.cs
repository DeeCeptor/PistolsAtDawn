using UnityEngine;
using System.Collections;

/**
 * Controls how often the enemy shoots.
 */ 
public class EnemyController : MonoBehaviour 
{
	public static EnemyController enemy_controller;

	// Set these in the inspector pane of the editor
	// All time is expressed in seconds.
	public float time_between_shots = 10;
	public float time_to_dodge = 1.0f;
	private float shot_counter = 0;

	void Start () 
	{
		enemy_controller = this;
	}
	
	void Update () 
	{
		shot_counter += Time.deltaTime * Time.timeScale;
		if (shot_counter >= time_between_shots)
		{
			if (time_to_dodge <= 0)
				Shoot();	// No chance to dodge the shot
			else
				Shot_Warning();
		}
	}


	/**
	 * Changes the amount of time needed to fire the current shot. 
	 * Amount is in seconds. Can be positive or negative. A negative amount of time speeds up the reloading process.
	 */ 
	public void alterCurrentLoadTime(float amount)
	{
		shot_counter += (-amount);
	}


	/**
	 * Spawns a warning object, that allows the player to dodge the upcoming shot
	 * if they press the correct key.
	 */ 
	public void Shot_Warning()
	{

	}


	/**
	 * Shoots the player. Played if the player has failed to dodge it.
	 */ 
	public void Shoot()
	{
		// Play cutscene of being shot
		Time.timeScale = 0;	// Disable time for cutscene

		// Place wound on player
		HealthController.health_controller.minorlyWoundPlayer();

		Time.timeScale = 1;	// Re-enable time after cutscene
	}
}
