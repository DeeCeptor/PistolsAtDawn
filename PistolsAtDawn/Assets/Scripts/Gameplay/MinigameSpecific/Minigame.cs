using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {

	protected MinigameController controller;

	void Start () 
	{
		controller = GameObject.Find ("MinigameController").GetComponent<MinigameController> ();
	}


	public virtual void startGame()
	{
		controller.setMinigameUnavailable (this.gameObject);
	}


	public virtual void endGame()
	{
		controller.setMinigameUnavailable (this.gameObject);
	}


	void Update () 
	{
	
	}
}
