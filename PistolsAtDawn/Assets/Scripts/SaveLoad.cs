using UnityEngine;
using System.Collections;

/**
 * Manages the saving and loading of all player data including unlocked levels and score.
 * Place this in every scene where you neef to save or load a value.
 */ 
public class SaveLoad : MonoBehaviour
{
	public static SaveLoad settings_manager;	// Can be accessed by SaveLoad.settings_manager.<method_name()>

	private string level_key = "Highest_Unlocked_Level";	// Used to access the player's progress
	private string score_key = "Score_";	// Stored in format of a float of seconds taken to beat the level


	void Start ()
	{
		settings_manager = this;
	}


	/**
	 * Returns the level we have unlocked so far. Level 1 is always unlocked.
	 * Returns a value between 1 and 12.
	 * Ex: 5 is returned. This means the player has unlocked all levels up to 5, but has not beaten level 5.
	 */ 
	public int getUnlockedLevel()
	{
		return PlayerPrefs.GetInt("Unlocked_Level", 1);
	}
	/**
	 * Sets the level the player has unlocked.
	 * Ex: 4 means the player has just beaten level 3, and can now play level 4.
	 */ 
	public void setUnlockedLevel(int next_level)
	{
		PlayerPrefs.SetInt(level_key, next_level);
	}


	/**
	 * Returns an int representing the number of seconds taken to beat the level.
	 * Returns a 0 if no value was found.
	 * Can only retrieve a score if the player has beaten that level.
	 */ 
	public int getScore(int level)
	{
		return PlayerPrefs.GetInt(score_key + level, 0);
	}
	/**
	 * Sets the score (an integer representing seconds taken to beat the level) for a given level.
	 */ 
	public void setScore(int level, int score)
	{
		PlayerPrefs.SetInt(score_key + level, score);
	}
}
