using UnityEngine;
using System.Collections;

public class AnimatorHeroScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		//Use changeTo 'animation' to change to that animation,
		//bear in mind the invoke that occurs a bit below
/*
		if (Input.GetKeyDown (KeyCode.Space)) {
			changeToNoGun();
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			changeToHit();
		}


		//**IMPORTANT**
		//Notice here that you will need to tell the animator to
		//"returnInvoke" on some animations, specifically aiming,
		// noGun, and shuffling (which will be maintained otherwise) 
		if(Input.GetKeyUp(KeyCode.Space)){
			Invoke ("returnInvoke", 0.1f);
		}
*/
		//anim.SetInteger ("AnimInt", 0);
	}

	//This should be used to return animations like 'Aiming' which must
	//be maintained back to idle. Essentially it allows for a return to idle
	//instead of being trapped in any one animation thing, but it doubles
	//as a convenient way of allowing an animation like 'Smacking' to get
	//its call to return to idle. It's just for convenience.
	void returnInvoke(){
		changeToIdle ();
	}

	public void changeToIdle(){
		anim.SetInteger ("AnimInt", 0);
	}
	public void changeToSmacking(){
		anim.SetInteger ("AnimInt", 1);
		Invoke ("returnInvoke", 0.1f);
	}
	public void changeToShuffle(){
		anim.SetInteger ("AnimInt", 2);
	}
	public void changeToHit(){
		anim.SetInteger ("AnimInt", 3);
		Invoke ("returnInvoke", 0.1f);
	}
	public void changeToDodge(){
		anim.SetInteger ("AnimInt", 4);
		Invoke ("returnInvoke", 0.1f);
	}
	public void changeToAiming(){
		anim.SetInteger ("AnimInt", 5);
	}
	public void changeToNoGun(){
		anim.SetInteger ("AnimInt", 6);
	}

}
