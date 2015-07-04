using UnityEngine;
using System.Collections;

public class removeAfterTime : MonoBehaviour {

	public float destroyTime = 5; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, destroyTime);
	}


}
