using UnityEngine;
using System.Collections;

public class SpawnPowderParticles : MonoBehaviour 
{
	public GameObject powderPrefab;		// Drag prefab here
	float curDelay = 0;
	float spawnDelay = 0.05f;	//Spawn a powder particle every spawnDelay seconds

	void Start () 
	{
	
	}
	
	void Update () 
	{
		curDelay += Time.deltaTime;

		if(curDelay > spawnDelay)
		{
			// Time to spawn new particle
			curDelay = 0;
			Instantiate (powderPrefab, new Vector3(this.transform.position.x, 
			                                       this.transform.position.y,
			                                       0),
			             						   Quaternion.identity);
		}
	}



}
