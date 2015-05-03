using UnityEngine;
using System.Collections;

public class InsertBarrelTrigger : MonoBehaviour 
{
	InsertIntoBarrel script;

	void Start()
	{
		script = GameObject.Find("InsertIntoBarrel").GetComponent<InsertIntoBarrel>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		script.taggedObjectEntered(other.gameObject);
	}

}
