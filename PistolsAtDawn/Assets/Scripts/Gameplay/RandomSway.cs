using UnityEngine;
using System.Collections;

public class RandomSway : MonoBehaviour {

	Vector3 startPos;

	void Start () 
	{
		startPos = transform.position;
	}
	
	void Update () 
	{
		transform.position = (new Vector3(startPos.x + Mathf.PingPong(Time.time, 4), transform.position.y, transform.position.z));
	}
}
