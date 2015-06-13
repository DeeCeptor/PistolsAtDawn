using UnityEngine;
using System.Collections;

public class BandagePlayer : Minigame 
{
	public GameObject wound_to_spawn;	// Drag prefab in inspector to this field. Spawns these when wounds are taken
	public GameObject topLeftRegion;		// Boundaries within to spawn wound objects. Drag them in inspector.
	public GameObject bottomRightRegion;

	
	void Update () 
	{
		
	}


	public GameObject createMinorWound()
	{
		GameObject obj = (GameObject) Instantiate(wound_to_spawn, new Vector3(Random.Range(topLeftRegion.transform.position.x, bottomRightRegion.transform.position.x), 
		                                        Random.Range(topLeftRegion.transform.position.y, bottomRightRegion.transform.position.y), -1), 
		            							Quaternion.identity);
		obj.transform.parent = this.transform;
		controller.setMinigameAvailable ("BandagePlayer");	// Make minigame available since there's a wound to fix
		return obj;
	}


	public override void startGame()
	{
		base.startGame ();
	}
	
	
	public override void endGame()
	{
		base.endGame ();
	}
}
