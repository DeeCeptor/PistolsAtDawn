using UnityEngine;
using System.Collections;

public class DoIDie : MonoBehaviour {

	Animator anim;
	public bool die = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	//I am a terrible person...
	//If the player WINS the level, tell DeathAnimRIGHT to DIE
	//If the player LOSES the level, tell DeathAnimLEFT to DIE
	//sorry, brain fart.
	void Update () {
		if (die) {
			anim.SetBool ("Die", true);
		}
	}
}
