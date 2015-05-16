using UnityEngine;
using System.Collections;

public class Wound : MonoBehaviour 
{
	SpriteRenderer sprite;

	void Start () 
	{
		sprite = this.GetComponent<SpriteRenderer>();
	}
	
	void Update () 
	{
		if (!sprite.isVisible)
		{
			Debug.Log("Invisible");
		}
	}


	void OnWillRenderObject()
	{

	}
}
