using UnityEngine;
using System.Collections;

public class MoveWithMouse : MonoBehaviour {
	int depth = -2;	// Z position


	void Start () 
	{
	
	}
	
	void Update () 
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
		mousePos.z = depth;
		this.transform.position = mousePos;
	}
}
