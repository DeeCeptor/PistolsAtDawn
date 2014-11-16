using UnityEngine;
using System.Collections;

/**
 * Key meant to open the gun box by entering the keyhole.
 */ 
public class Key : MonoBehaviour {

	private bool inLock = false;

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.name == "Key Hole")
		{
			if(!inLock)
			{
				UnlockGun();
			}
		}
	}


	void UnlockGun()
	{
		Debug.Log ("Key is in keyhole!");
		inLock = true;
		transform.rotation = Quaternion.identity;
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
		rigidbody.useGravity = false;

		DraggableObject draggableObj = this.GetComponent<DraggableObject>();
		draggableObj.draggable = false;
	}
}
