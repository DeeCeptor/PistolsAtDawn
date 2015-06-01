using UnityEngine;
using System.Collections;

// Class that controls wounds and damage
// Lives inside of HealthController and has references to actual wound gameobjects on the body.
public class BulletWound : MonoBehaviour 
{
	public bool majorWound = false;
	public bool bleeding = true;
	public float timeTillBleedsAgain;

	void Start () 
	{
	
	}


	public void startBleeding()
	{
		bleeding = true;
	}
	public void stopBleeding()
	{

	}


	void Update () 
	{
	
	}
}
