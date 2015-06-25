using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Player types insults to slow down the enemies' shot.
 * A list of insults is given in a scroll window.
 * Player must guess which insult would  
 * Incorrect insults just make the enemy laugh it off and load even faster.
 * Correctly guessed insults slow down the loading of the enemy.
 * 
 * Insults are removed after they've been used, as reusing insults is just not classy.
 */ 
public class Insult : Minigame 
{
	[System.Serializable]
	public class InsultEffectivenessPairs
	{
		public string insult;	// Pattern matched against what the player types
		public float strength;	// Can be positive or negative, as they add or remove time off the enemy's loading speed
								// Positive strength delays the enemies loading by that many seconds
								// Negative strength speeds up the enemies loading by that many seconds
	}

	public List<InsultEffectivenessPairs> insults;
	public string saved_input;
	private string insult_text_list;
	private Text insult_text_area; 
	private InputField insult_input;
	private GameObject insult_canvas;

	void Start()
	{
		insult_text_area = GameObject.Find("InsultText").GetComponent<Text>();
		insult_input = GameObject.Find("InsultInput").GetComponent<InputField>();
		insult_canvas = GameObject.Find("InsultCanvas");

		setInsultListText();

		// Turn off minigame
		insult_canvas.SetActive(false);
		GameObject.Find("Minigames").transform.FindChild("Insult").gameObject.SetActive(false);
	}


	void setInsultListText()
	{
		insult_text_list = "";
		foreach (InsultEffectivenessPairs insult_entry in insults)
		{
			insult_text_list += insult_entry.insult + "\n";
		}
		insult_text_area.text = insult_text_list;
	}


	void Update () 
	{
		if (!PauseController.pause.paused)
		{
			// Check if player is done typing
			if (Input.GetKeyDown(KeyCode.Return))
			{
				// Check if input matches any saved insults
				ShoutInsult();
			}
		}
	}


	public void ShoutInsult()
	{
		Debug.Log("Shouted " + insult_input.text);
		InsultEffectivenessPairs found_entry = null;

		// Check input against insult list
		foreach (InsultEffectivenessPairs insult_entry in insults)
		{
			if (insult_input.text.Equals(insult_entry.insult))
			{
				// Found matching insult, resolve its effects on the enemy
				Debug.Log(insult_entry.insult + " shouted! Affecting enemy by " + insult_entry.strength);
				insult_input.text = "";	// Clear input field
				found_entry = insult_entry;
				EnemyController.enemy_controller.alterCurrentLoadTime(insult_entry.strength);
				break;
			}
		}
		if (found_entry != null)
		{
			insults.Remove(found_entry);	// Remove the used insult
		}

		setInsultListText();
	}


	public override void hideGame ()
	{
		base.hideGame ();
		insult_canvas.SetActive(false);
	}

	
	public override void startGame()
	{
		base.startGame ();
		insult_canvas.SetActive(true);
	}
	
	
	public override void endGame()
	{
		base.endGame ();
	}
}
