using UnityEngine;
using System.Collections;

public class ExitGameButton : MonoBehaviour {

	void OnMouseDown(){
		CameraFade.StartAlphaFade( Color.black, false, 2f, 0f, () => { Application.Quit(); } );
	}
}
