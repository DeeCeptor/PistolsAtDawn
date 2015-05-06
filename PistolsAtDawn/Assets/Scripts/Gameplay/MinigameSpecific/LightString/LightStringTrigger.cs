using UnityEngine;
using System.Collections;

public class LightStringTrigger : MonoBehaviour 
{
	LightString script;
	GameObject stringFire;

	void Start () 
	{
		script = GameObject.Find("LightString").GetComponent<LightString>();
		stringFire = GameObject.Find ("FireSpriteSheet 2");
	}
	void Update () 
	{
	
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "MatchHead")
		{
			// Play animation of string being lit
			stringFire.GetComponent<SpriteRenderer>().enabled = true;
			
			// Use invoke to delay ending of minigame, so we can show animation of match being lit
			script.Invoke("endGame", 1);
			//script.endGame();
			//Invoke("endGame", 1);
		}
	}
}
