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


	public virtual void startGame()
	{
		controller = GameObject.Find ("MainView").transform.FindChild("MinigameController").GetComponent<MinigameController> ();
		Debug.Log (this.name + " " + controller.name);
		controller.currentlyPlayingMinigame = this.gameObject;
		controller.hideIcons ();
		controller.playingGame = true;
	}


	public virtual void endGame()
	{
		controller.showIcons ();
		controller.minigameChecklist ();	// Add new minigames based on requirements
		controller.playingGame = false;
		controller.setMinigameUnavailable (this.gameObject.name);
	}
}
