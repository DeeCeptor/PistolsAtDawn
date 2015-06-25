using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour 
{
	[HideInInspector]
	public MinigameController controller;

	void Start () 
	{
		controller = GameObject.Find ("MainView").transform.FindChild("MinigameController").GetComponent<MinigameController> ();
	}


	/**
	 * Called every time the game is clicked, to bring it into view.
	 */ 
	public virtual void startGame()
	{
		controller = GameObject.Find ("MainView").transform.FindChild("MinigameController").GetComponent<MinigameController> ();
		controller.currentlyPlayingMinigame = this.gameObject;
		controller.hideIcons ();
		controller.playingGame = true;
	}


	/**
	 * Called is the player hits escape, or finishes the game
	 */ 
	public virtual void hideGame()
	{
		controller.showIcons ();
		controller.minigameChecklist ();	// Add new minigames based on requirements
		controller.playingGame = false;
	}


	/**
	 * Called when this game is completed, and cannot be played again.
	 */ 
	public virtual void endGame()
	{
		hideGame();
		controller.setMinigameUnavailable (this.gameObject.name);
	}
}
