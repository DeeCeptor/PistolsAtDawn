using UnityEngine;
using System.Collections;

public class Shake : Minigame 
{
	int numTimesSpacePressed = 0;
	int threshold = 20;
	float tickTime = 0.5f;
	float curTime;
	
	void Start () 
	{
	
	}
	void Update () 
	{
		curTime += Time.deltaTime;
		if (curTime >= tickTime)			// MAke it so you must hit space very quickly
		{
			numTimesSpacePressed--;
			numTimesSpacePressed = Mathf.Max(0, numTimesSpacePressed);
			curTime -= tickTime;
		}
	}


	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		controller.shaken = true;
		base.endGame ();
	}


	public void SpacePressed()
	{
		numTimesSpacePressed++;

		if (numTimesSpacePressed >= threshold)
		{
			Debug.Log("Gun shaken enough");
			endGame();
		}
	}

	public int getNumTimesPressed()
	{
		return numTimesSpacePressed;
	}


	void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(10, 10, 200, 100), numTimesSpacePressed + " / " + threshold);
	}



}
