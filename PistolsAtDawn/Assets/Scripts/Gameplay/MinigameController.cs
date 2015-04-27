using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MinigameController : MonoBehaviour
{
	public List<GameObject> minigames;	// Actual minigame objects

	[HideInInspector]
	public GameObject curMinigame;

	public List<GameObject> availableMinigames;		// Minigame icons
	public List<GameObject> unavailableMinigames;

	public GameObject currentlyPlayingMinigame;

	// Use this for initialization
	void Start () 
	{
		// Hide all minigames off the bat
		foreach (GameObject go in minigames) 
		{
			go.SetActive(false);
		}
		// Display available minigame icons
		foreach (GameObject go in availableMinigames) 
		{
			go.SetActive(true);
		}
		// Hide unavailable minigames
		foreach (GameObject go in unavailableMinigames) 
		{
			go.SetActive(false);
		}
	}


	public void setMinigameAvailable(string name)
	{
		// Remove icon from list and make it inactive
		GameObject icon = GameObject.Find ("MinigameIcons").transform.FindChild (name).gameObject;
		unavailableMinigames.Remove (icon);
		availableMinigames.Add (icon);
		icon.SetActive(true);
	}
	public void setMinigameUnavailable(string name)
	{
		Debug.Log ("unavailable " + name);

		// Remove icon from list and make it inactive
		GameObject icon = GameObject.Find ("MinigameIcons").transform.FindChild (name).gameObject;
		availableMinigames.Remove (icon);
		unavailableMinigames.Add (icon);
		icon.SetActive(false);

		// Make minigame itself inactive
		GameObject.Find("Minigames").transform.FindChild(name).gameObject.SetActive(false);
	}
}