using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

	Animator anim;
	public bool endCutscene = false;

	public GameObject leftMan;
	public GameObject rightMan;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		//You will be able to access the left and right man from here...
		leftMan = GameObject.Find("DeathAnimLeft");
		rightMan = GameObject.Find("DeathAnimRight");
	}
	
	// Update is called once per frame
	void Update () {
		if (endCutscene) {
			anim.SetBool ("EndTrigger", true);
		}
	}
}
