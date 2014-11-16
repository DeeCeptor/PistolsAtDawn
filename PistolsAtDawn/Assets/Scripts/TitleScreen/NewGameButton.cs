using UnityEngine;
using System.Collections;

public class NewGameButton : MonoBehaviour {

	void OnMouseDown(){
		CameraFade.StartAlphaFade( Color.white, false, 2f, 0f, () => { Application.LoadLevel(2); } );
	}

	void OnLevelWasLoaded(int level) {
		CameraFade.StartAlphaFade( Color.white, true, 2f, 0f );
	}
}
