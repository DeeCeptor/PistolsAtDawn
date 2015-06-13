using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class MinigameController : MonoBehaviour
{
	public List<GameObject> minigames;	// Actual minigame objects

	[HideInInspector]
	public bool playingGame = false;
	public GameObject currentlyPlayingMinigame;
	public bool hasGun = true;		// Orphans steal your gun. Can't play minigames when gun is stolen
	private GameObject allIcons;
	private GameObject allMinigames;
	private string saved_minigame_prefab_loc = "Assets/Resources/Minigames.prefab";

	// Games we don't want to reset
	private Transform bandage_game;
	private Transform find_game;

	public List<GameObject> availableMinigameIcons;		// Minigame icons
	public List<GameObject> unavailableMinigameIcons;

	
	// Finding items
	public int numBulletsfound = 0;
	public int alcoholLevel = 0;
	public bool paperFound, powderFound, stringFound, matchFound, alcoholFound = false;

	// Preparing gun for firing
	public bool shaken, barrelCleaned, stringCut, powderInPan, bulletInBarrel, paperInBarrel, 
		powderInBarrel, ramrodBarrel, threadString, matchLit, stringLit, cockHammer, shotFired = false;


	/**
	 * Called after the gun has been shot.
	 * 1. Resets variables for loading gun
	 * 2. Loads and replaces minigames with saved prefab from beginning of level load, to reset minigames
	 */ 
	public void afterShot()
	{
		// Reset steps needed to load gun
		shaken = barrelCleaned = stringCut = powderInPan = bulletInBarrel = paperInBarrel = 
		powderInBarrel = ramrodBarrel = threadString = matchLit = stringLit = cockHammer = shotFired = false;

		abortGame();

		// Detatch games we don't want reset
		bandage_game.parent = null;
		find_game.parent = null;

		// Reset minigames except for finding materials and bandage minigame
		resetMinigames();

		// Readd minigames that were not reset
		bandage_game.parent = allMinigames.transform;
		find_game.parent = allMinigames.transform;

		// Check available games again
		minigameChecklist();
	}
	void resetMinigames()
	{
		Debug.Log("Resetting minigames");
		GameObject.Destroy(allMinigames);
		allMinigames = (GameObject) Instantiate((GameObject) Resources.Load("Minigames"), allMinigames.transform.position, Quaternion.identity);
		allMinigames.transform.SetParent(GameObject.Find("MainView").transform);	// Set parent
		allMinigames.name = "Minigames";	// Removes "(Clone)" part of name
	}


	// Checks requirements for all minigames and makes minigames available. Called at the end of every minigame.
	public void minigameChecklist()
	{
		setMinigameAvailable ("BandagePlayer");
		if ((numBulletsfound <= 0 && !bulletInBarrel) || !paperFound || !powderFound || !stringFound || !matchFound || !alcoholFound)
			setMinigameAvailable ("Find");
		if (!shaken)
			setMinigameAvailable("Shake");
		if (!barrelCleaned && shaken)
			setMinigameAvailable ("CleanBarrel");
		if (!stringCut && stringFound)
			setMinigameAvailable ("CutString");
		if (!powderInPan && powderFound)
			setMinigameAvailable ("PowderPan");
		if (!powderInBarrel && powderFound && barrelCleaned)
			setMinigameAvailable ("PowderBarrel");
		if (!bulletInBarrel && barrelCleaned && !paperInBarrel && powderInBarrel && numBulletsfound > 0 && paperFound)
			setMinigameAvailable ("InsertIntoBarrel");
		if (!threadString && stringCut)
			setMinigameAvailable ("ThreadString");
		if (!ramrodBarrel && bulletInBarrel && paperInBarrel && powderInBarrel)
			setMinigameAvailable ("RamrodBarrel");
		if (!matchLit && threadString && ramrodBarrel)
			setMinigameAvailable ("LightMatch");
		if (!stringLit && matchLit)
			setMinigameAvailable ("LightString");
		if (!cockHammer && stringLit)
			setMinigameAvailable ("CockHammer");
		if (!shotFired && cockHammer && ramrodBarrel && powderInPan && stringLit)
			setMinigameAvailable ("ShootEnemy");
	}


	void Start () 
	{
		allIcons = GameObject.Find ("MinigameIcons");
		allMinigames = GameObject.Find ("Minigames");

		// Remove bandage and find minigames because we don't want to reset those
		bandage_game = allMinigames.transform.FindChild("BandagePlayer");
		find_game = allMinigames.transform.FindChild("Find");
		bandage_game.parent = null;
		find_game.parent = null;

		// Save prefab of all minigames including children so we can reload it
		// later when we need to reset after each gun shot
		Object prefab = EditorUtility.CreateEmptyPrefab(saved_minigame_prefab_loc);
		EditorUtility.ReplacePrefab(allMinigames, prefab, ReplacePrefabOptions.ConnectToPrefab);

		// Readd games we don't want saved in prefab
		bandage_game.parent = allMinigames.transform;
		find_game.parent = allMinigames.transform;

		//Application.targetFrameRate = 40;
		// Hide all minigames off the bat
		foreach (GameObject go in minigames) 
		{
			//go.SetActive(false);
		}
		// Hide unavailable minigames
		foreach (GameObject go in unavailableMinigameIcons) 
		{
			//go.SetActive(false);
		}
		// Display available minigame icons
		foreach (GameObject go in availableMinigameIcons) 
		{
			//go.SetActive(true);
		}

		foreach( Transform child in allIcons.transform )
		{
			child.gameObject.SetActive(false);
		}

		minigameChecklist();
	}


	public void showIcons()
	{
		allIcons.SetActive (true);
	}
	public void hideIcons()
	{
		allIcons.SetActive (false);
	}


	public void setMinigameAvailable(string name)
	{
		// Remove icon from list and make it inactive
		GameObject icon = allIcons.transform.FindChild (name).gameObject;
		unavailableMinigameIcons.Remove (icon);
		availableMinigameIcons.Add (icon);
		icon.SetActive(true);
	}
	public void setMinigameUnavailable(string name)
	{
		// Remove icon from list and make it inactive
		GameObject icon = allIcons.transform.FindChild (name).gameObject;
		availableMinigameIcons.Remove (icon);
		unavailableMinigameIcons.Add (icon);
		icon.SetActive(false);

		// Make minigame itself inactive
		GameObject.Find("Minigames").transform.FindChild(name).gameObject.SetActive(false);
	}


	void Update () 
	{
		if (playingGame && Input.GetKeyDown (KeyCode.Escape)) 
		{
			abortGame();
		}
		if (Input.GetKeyDown (KeyCode.R))
			afterShot();
	}
	

	// Hides the current minigame, and shows minigame icons
	public void abortGame()
	{
		if (playingGame) 
		{
			playingGame = false;
			showIcons ();
			this.currentlyPlayingMinigame.SetActive (false);
		}
	}

	
}