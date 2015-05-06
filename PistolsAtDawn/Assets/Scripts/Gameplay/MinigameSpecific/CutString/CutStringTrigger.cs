using UnityEngine;
using System.Collections;

public class CutStringTrigger : MonoBehaviour 
{
	CutString script;
	public Sprite newSprite;
	//SpriteRenderer spriteComponent;
	GameObject scissors;
	SpriteRenderer[] spriteRenderers;

	void Start () 
	{
		script = GameObject.Find("CutString").GetComponent<CutString>();

		//Scissors are hard
		//spriteComponent = GetComponent<SpriteRenderer> ();
		scissors = GameObject.Find ("Scissors");
		spriteRenderers = scissors.GetComponentsInChildren<SpriteRenderer> (true);

	}
	void Update () 
	{
		//scissors.transform.position = new Vector3 (Input.mousePosition.x,
		//                                        Input.mousePosition.y);
		 
	}


	void OnMouseDown()
	{
		Debug.Log("String cut!");

		foreach(SpriteRenderer sr in spriteRenderers)
		{
			sr.enabled = !sr.enabled; //flip it
		}

		//this is for string
		if(newSprite != null)
			GetComponent<SpriteRenderer> ().sprite = newSprite;
		Invoke ("cut", 1);
		//cut ();	// Use Invoke ("cut", time) to delay and play an animation
	}
	void cut()
	{
		script.endGame();
	}
}
