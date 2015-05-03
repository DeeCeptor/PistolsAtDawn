using UnityEngine;
using System.Collections;

public class GunShoot : MonoBehaviour 
{
	ShootEnemy script;

	void Start () 
	{
		script = GameObject.Find("ShootEnemy").GetComponent<ShootEnemy>();
	}


	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
			Shoot();
	}
	void Shoot()
	{
		// Determine if shot hit
		RaycastHit2D hit = Physics2D.Raycast (this.transform.position, Vector2.zero, Mathf.Infinity, -1);
		Debug.Log("Shot " + hit.transform.name);
		if (hit.transform.tag == "Enemy")
		{
			script.endGame();
		}
	}
}
