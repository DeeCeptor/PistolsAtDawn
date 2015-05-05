using UnityEngine;
using System.Collections;

public class ShakeGun : MonoBehaviour 
{
	Shake script;

	void Start () 
	{
		startPos = transform.position;
		script = GameObject.Find("Shake").GetComponent<Shake>();
	}


	float speed = 0.0f; 	// How fast it's currently shaking
	float speedUpAmount = 1.0f;		// How much speed is gained from hitting the space bar
	Vector2 startPos;
	float curTime;

	float timesPressed = 0.0f;

	void Update()
	{


		//transform.position = new Vector2(Mathf.Sin(Time.time * timesPressed), startPos.y);


		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			script.SpacePressed();
			timesPressed = script.getNumTimesPressed ();
			transform.position = new Vector2(startPos.x+(Random.Range(-1.0f,1.0f)/20*timesPressed), startPos.y+(Random.Range(-1.0f,1.0f)/20*timesPressed));
			Invoke ("ReturnToLastPos", 0.1f);

		}


		/*MICHAEL'S PREVIOUS CODE
		if (speed > 0)
			curTime += Time.deltaTime;			

		//this.transform.position = new Vector2(startPos.x, startPos.y + Mathf.Sin((curTime - Time.deltaTime) * speed));

		// Slow down shaking over time
		speed -= Time.deltaTime;
		speed = Mathf.Max (speed, 0);
		
		// Speed up shaking when player mashes space bar
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			speed += 0.5f;
			script.SpacePressed();
		}
		*/
	}

	private void ReturnToLastPos()
	{
		transform.position = startPos;
	}
}
