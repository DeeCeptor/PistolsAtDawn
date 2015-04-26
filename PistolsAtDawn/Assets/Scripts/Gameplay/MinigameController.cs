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


	public void setMinigameAvailable(GameObject gameIcon)
	{
		unavailableMinigames.Remove (gameIcon);
		availableMinigames.Add (gameIcon);
		gameIcon.SetActive(true);
	}
	public void setMinigameUnavailable(GameObject gameIcon)
	{
		availableMinigames.Remove (gameIcon);
		unavailableMinigames.Add (gameIcon);
		gameIcon.SetActive(false);
	}
}