using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dodge_Shot : MonoBehaviour 
{
	private string dodge_key;	// Player must press this to dodge
	private GameObject text;
	public float time_till_shot;	// Time the player has to dodge the enemy shot


	void Start () 
	{
		// Pick a dodge key and then display it
		dodge_key = keys[(int) Random.Range(0, keys.Length)];
		text = GameObject.Find("Warning_Text");
		text.GetComponent<Text>().enabled  = true;
		text.GetComponent<Text>().text = dodge_key;
	}
	
	void Update () 
	{
		// Check if we dodged the enemy shot
		if (PauseController.pause.pause_time != 0 && Input.GetKey(dodge_key))
		{
			// Player dodged the shot. play cutscene or just remove this object
			Debug.Log(dodge_key + " pressed, shot dodged");
			text.GetComponent<Text>().enabled  = false;
			Destroy (this.gameObject);
		}

		time_till_shot -= Time.deltaTime * Time.timeScale * PauseController.pause.pause_time;
		if (time_till_shot <= 0)
		{
			// Player did not dodge in time, they are shot by enemy.
			EnemyController.enemy_controller.Shoot();
			Debug.Log("Player failed to dodge. Initiating shot");
			text.GetComponent<Text>().enabled  = false;
			Destroy (this.gameObject);	// Remove this object
		}
	}

	// Eligible dodge keys
	private string[] keys = {
	                               "space",
	                               "0",
	                               "1",
	                               "2",
	                               "3",
	                               "4",
	                               "5",
	                               "6",
	                               "7",
	                               "8",
	                               "9",
	                               "a",
	                               "b",
	                               "c",
	                               "d",
	                               "e",
	                               "f",
	                               "g",
	                               "h",
	                               "i",
	                               "j",
	                               "k",
	                               "l",
	                               "m",
	                               "n",
	                               "o",
	                               "p",
	                               "q",
	                               "r",
	                               "s",
	                               "t",
	                               "u",
	                               "v",
	                               "w",
	                               "x",
	                               "y",
	                               "z"
	};
}
