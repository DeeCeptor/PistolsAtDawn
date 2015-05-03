using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MinigameController : MonoBehaviour
{
	public List<GameObject> minigames;	// Actual minigame objects

	[HideInInspector]
	public bool playingGame = false;
	public GameObject currentlyPlayingMinigame;
	public bool hasGun = true;		// Orphans steal your gun. Can't play minigames when gun is stolen
	private GameObject allIcons;
	private GameObject allMinigames;

	public List<GameObject> availableMinigameIcons;		// Minigame icons
	public List<GameObject> unavailableMinigameIcons;

	
	// Finding items
	public int numBulletsfound = 0;
	public int alcoholLevel = 0;
	public bool paperFound, powderFound, stringFound, matchFound, alcoholFound = false;

	// Preparing gun for firing
	public bool shaken, barrelCleaned, stringCut, powderInPan, bulletInBarrel, paperInBarrel, 
		powderInBarrel, ramrodBarrel, threadString, matchLit, stringLit, cockHammer, shotFired = false;


	// Checks requirements for all minigames and makes minigames available. Called at the end of every minigame.
	public void minigameChecklist()
	{
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
			Debug.Log(child.name);
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