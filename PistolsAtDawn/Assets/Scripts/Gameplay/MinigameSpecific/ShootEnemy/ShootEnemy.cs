using UnityEngine;
using System.Collections;

public class ShootEnemy : Minigame 
{
	void Start () 
	{
	
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
		controller.shotFired = true;
		controller.afterShot();
		base.endGame ();
	}



}
