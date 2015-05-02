using UnityEngine;
using System.Collections;

public class PowderBarrelTrigger : MonoBehaviour 
{
	PowderBarrel script;


	void Start () 
	{
		script = GameObject.Find("PowderBarrel").GetComponent<PowderBarrel>();
	}
	
	void Update () 
	{
	
	}


	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.tag == "Powder") 
		{
			Debug.Log("Powder put in barrel");
			script.powderEntered();
			Destroy (other.gameObject);		
		}
	}
}
