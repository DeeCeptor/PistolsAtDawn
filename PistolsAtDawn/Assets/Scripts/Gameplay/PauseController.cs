using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour 
{
	public static PauseController pause;
	public float pause_time = 1;	// 1 if unpaused, 0 if paused. Multiplied by all things that execute on timers in update.
	public bool paused = false;
	GameObject text;


	void Start () 
	{
		pause = this;
		text = GameObject.Find("Paused_Text");
		text.GetComponent<Text>().enabled  = false;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;

			if (paused)
			{
				Pause();
			}
			else
			{
				UnPause();
			}
		}
	}


	public void Pause()
	{
		Time.timeScale = 0;
		pause_time = 0;
		text.GetComponent<Text>().enabled  = true;
	}
	public void UnPause()
	{
		Time.timeScale = 1;
		pause_time = 1;
		text.GetComponent<Text>().enabled  = false;
	}
}
