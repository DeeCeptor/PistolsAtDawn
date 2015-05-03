using UnityEngine;
using System.Collections;

public class CutStringTrigger : MonoBehaviour 
{
	CutString script;

	void Start () 
	{
		script = GameObject.Find("CutString").GetComponent<CutString>();
	}
	void Update () 
	{
	
	}


	void OnMouseDown()
	{
		Debug.Log("String cut!");
		cut ();	// Use Invoke ("cut", time) to delay and play an animation
	}
	void cut()
	{
		script.endGame();
	}
}
