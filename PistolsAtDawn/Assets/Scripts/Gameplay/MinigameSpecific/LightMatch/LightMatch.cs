using UnityEngine;
using System.Collections;

public class LightMatch : Minigame 
{
	GameObject match;

	void Start () 
	{
		match = GameObject.Find ("FireSpriteSheet_0");
	}
	
	void Update () 
	{
	
	}


	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		Debug.Log("Match lit");
		controller.matchLit = true;
		base.endGame ();
	}

	public void lightMatch()
	{
		match.GetComponent<SpriteRenderer> ().enabled = true;
	}
}
