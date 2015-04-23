using UnityEngine;
using System.Collections;

public class RandomSway : MonoBehaviour {

	Vector3 startPos;
	public int wanderDist = 4;

	void Start () 
	{
		startPos = transform.position;
	}
	
	void Update () 
	{
		transform.position = (new Vector3(startPos.x + Mathf.PingPong(Time.time, wanderDist), transform.position.y, transform.position.z));
	}
}
