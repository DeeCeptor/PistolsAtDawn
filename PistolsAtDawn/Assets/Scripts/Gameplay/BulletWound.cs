using UnityEngine;
using System.Collections;

// Class that controls wounds and damage
// Lives inside of HealthController and has references to actual wound gameobjects on the body.
public class BulletWound 
{
	public bool majorWound = false;
	public bool bleeding = true;
	public float timeTillBleedsAgain;
	public float curTimeTillBleedsAgain;
	public Wound wound_sprite;


	public BulletWound(float timeTillBandageFallsOff)
	{
		curTimeTillBleedsAgain = timeTillBandageFallsOff;
		timeTillBleedsAgain = timeTillBandageFallsOff;
		startBleeding();
	}


	public void startBleeding()
	{
		bleeding = true;
	}
	public void stopBleeding()
	{
		bleeding = false;
		curTimeTillBleedsAgain = timeTillBleedsAgain;
		wound_sprite.stopBleeding();
	}
}
