using UnityEngine;
using System.Collections;

public class PowderParticle : MonoBehaviour 
{
	float removeAfter = 2f;	// Despawn particle after removeAfter seconds
	float numSecondsAlive = 0;	// How long particle's been alive

	void Start () 
	{

	}
	
	void Update () 
	{
		numSecondsAlive += Time.deltaTime;
		if (numSecondsAlive > removeAfter)
			Destroy(this.gameObject);
	}
}
