using UnityEngine;
using System.Collections;

public class SplashScreenDelay : MonoBehaviour {
	public float delayTime = 5;

	public string levelToLoad = "Level1";
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	public AudioSource audioSourceToPlay;
	
	private bool isSceneStarting = true;
	private bool hasSceneFinished = false;
	private bool hasFinishedSound = false;

	private Color fadeInTargetColor;
	private Color fadeOutTargetColor;


	void Start(){
		fadeInTargetColor = new Color (GetComponent<GUITexture>().color.r, GetComponent<GUITexture>().color.g, GetComponent<GUITexture>().color.b, 1f);
		fadeOutTargetColor = new Color(GetComponent<GUITexture>().color.r, GetComponent<GUITexture>().color.g, GetComponent<GUITexture>().color.b, 0f);
		GetComponent<GUITexture>().color = new Color (GetComponent<GUITexture>().color.r, GetComponent<GUITexture>().color.g, GetComponent<GUITexture>().color.b, 0f);
		GetComponent<GUITexture>().pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}

	void Update(){

		if (isSceneStarting) {
			FadeIn ();
		} else {
			StartCoroutine("PlaySound");
		}

		if (hasFinishedSound)
			FadeOut ();

		if (hasSceneFinished)
			StartCoroutine("LoadNextScene");
	}

	IEnumerator LoadNextScene(){
		yield return new WaitForSeconds (1f);
		Application.LoadLevel(levelToLoad);
	}

	IEnumerator PlaySound(){
		if(!audioSourceToPlay.isPlaying && !hasFinishedSound)
			audioSourceToPlay.Play ();

		yield return new WaitForSeconds(audioSourceToPlay.clip.length);
		hasFinishedSound = true;
	}

	void FadeOut ()
	{
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, fadeOutTargetColor, fadeSpeed * Time.deltaTime);

		//if texture is clear enough
		if(GetComponent<GUITexture>().color.a <= 0.005f)
		{
			// clamp color, disable texture
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;

			hasSceneFinished = true;
		}
	}

	public void FadeIn ()
	{
		GetComponent<GUITexture>().enabled = true;

		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, fadeInTargetColor, fadeSpeed * Time.deltaTime);
		
		// If the texture is faded in enough
		if(GetComponent<GUITexture>().color.a >= 0.98f)
			isSceneStarting = false;
	}
}
