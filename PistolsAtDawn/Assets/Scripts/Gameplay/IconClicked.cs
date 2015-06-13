using UnityEngine;
using System.Collections;

public class IconClicked : MonoBehaviour 
{
	private GameObject minigames;
	private Minigame game;

	void Start () 
	{
		minigames = GameObject.Find ("Minigames");
		game = minigames.transform.FindChild (this.gameObject.name).GetComponent<Minigame> ();
	}


	// User clicks on enabled minigame
	void OnMouseDown()
	{
		// Start minigame
		minigames = GameObject.Find ("Minigames");
		GameObject go = minigames.transform.FindChild (this.name).gameObject;
		game = go.GetComponent<Minigame>();
		go.SetActive (true);
		game.startGame ();
	}

	
	void Update () 
	{
	
	}
}
