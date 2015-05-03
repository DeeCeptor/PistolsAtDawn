using UnityEngine;
using System.Collections;

public class ClickToCockHammer : MonoBehaviour 
{
	CockHammer script;

	void Start () 
	{
		script = GameObject.Find("CockHammer").GetComponent<CockHammer>();
	}
	void Update () 
	{
	
	}


	void OnMouseDown()
	{
		Debug.Log("Hammer clicked");
		this.transform.Rotate(0, 0, 90);	// Rotate hammer to show it's cocked
		script.endGame();
	}
}
