using UnityEngine;
using System.Collections;

public class GunpowderFlask : MonoBehaviour {

	private bool pouring = false;	// Whether or not gunpowder is being poured
	private ParticleSystem emitter;


	// Use this for initialization
	void Start () {
		emitter = this.GetComponent<ParticleSystem>();
	}


	// Update is called once per frame
	void Update () {
		Debug.Log(Vector3.Magnitude(transform.localEulerAngles));

		float angleSummation = Vector3.Magnitude(transform.localEulerAngles);

		if(angleSummation > 20 && angleSummation < 350 && !pouring)
		{
			pouring = true;
			emitter.enableEmission = true;
			emitter.Play();
		}
		else if(angleSummation < 20 || angleSummation > 355 && pouring)
		{
			pouring = false;
			emitter.enableEmission = false;
			emitter.Stop();
		}
	}
}
