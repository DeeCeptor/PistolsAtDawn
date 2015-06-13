using UnityEngine;
using System.Collections;

public class SpawnParticles : MonoBehaviour 
{
	public GameObject prefab;		// Drag prefab here to spawn here
	public float spawnDelay = 0.05f;	//Spawn a powder particle every spawnDelay seconds
	private float curDelay = 0;

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
			GameObject obj = (GameObject) Instantiate (prefab, new Vector3(this.transform.position.x, 
			                                       this.transform.position.y,
			                                       0),
			             						   Quaternion.identity);
			obj.transform.parent = this.transform.parent;
		}
	}



}
