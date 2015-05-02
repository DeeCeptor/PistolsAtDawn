using UnityEngine;
using System.Collections;

public class Pan : MonoBehaviour 
{
	[HideInInspector]
	public GameObject pan;
	public PowderPan panScript;

	void Start () 
	{
		panScript = GameObject.Find("PowderPan").GetComponent<PowderPan> ();
	}
	
	void Update () 
	{
	
	}


	void OnMouseDown()
	{
		if (!panScript.panOpen) // Open pan if it's closed
		{	
			Debug.Log ("Pan Opened");
			panScript.panOpen = true;
			this.transform.Rotate(0, 0, 90);	// Change animation to show open pan
		}
		else 
		{
			Debug.Log("Pan closed");
			panScript.panOpen = false;
			this.transform.Rotate(0, 0, -90);	// Change animation to show closed pan
		}
	}


	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.tag == "Powder") 
		{
			Debug.Log("Powder put in barrel");
			panScript.powderEnteredPan();
			Destroy (other.gameObject);		
		}
	}
}
