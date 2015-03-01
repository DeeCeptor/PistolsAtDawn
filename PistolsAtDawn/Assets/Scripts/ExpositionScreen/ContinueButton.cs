using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	public void Click(){
		CameraFade.StartAlphaFade( Color.white, false, 2f, 0f, () => { Application.LoadLevel(3); } );
	}

	public void OnLevelWasLoaded(int level) {
		CameraFade.StartAlphaFade( Color.white, true, 2f, 0f );
	}
}
