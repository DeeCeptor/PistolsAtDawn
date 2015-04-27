using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {

	protected MinigameController controller;

	void Start () 
	{

	}


	public virtual void startGame()
	{
		Debug.Log ("Start minigame");
		controller = GameObject.Find ("MainView").transform.FindChild("MinigameController").GetComponent<MinigameController> ();
		controller.currentlyPlayingMinigame = this.gameObject;
		//controller.setMinigameUnavailable (this.gameObject);
	}


	public virtual void endGame()
	{
		controller.currentlyPlayingMinigame = null;
		controller.setMinigameUnavailable (this.gameObject.name);
		GameObject.Find("Hand").GetComponent<Hand>().stop
		//this.gameObject.SetActive (false);
	}


	void Update () 
	{
	
	}
}
