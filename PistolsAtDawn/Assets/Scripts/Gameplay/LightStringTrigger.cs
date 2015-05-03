using UnityEngine;
using System.Collections;

public class LightStringTrigger : MonoBehaviour 
{
	LightString script;

	void Start () 
	{
		script = GameObject.Find("LightString").GetComponent<LightString>();
	}
	void Update () 
	{
	
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "MatchHead")
		{
			// Play animation of string being lit
			
			// Use invoke to delay ending of minigame, so we can show animation of match being lit
			script.endGame();
			//Invoke("endGame", 1);
		}
	}
}
