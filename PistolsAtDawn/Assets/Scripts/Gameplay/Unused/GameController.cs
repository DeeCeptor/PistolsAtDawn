using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameController 
{
	public static List<GameObject> minigames;	// Actual minigame objects
	
	[HideInInspector]
	public static GameObject curMinigame;
	
	public static List<GameObject> availableMinigames;		// Minigame icons
	public static List<GameObject> unavailableMinigames;
	
	public static GameObject currentlyPlayingMinigame;
}
