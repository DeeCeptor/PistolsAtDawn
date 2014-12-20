using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoScrollText : MonoBehaviour {

	public Text contentText;
	public float scrollSpeed = 0.1f;

	void OnGUI(){
		Vector3 t = contentText.rectTransform.position;
		t.y += scrollSpeed;
		contentText.rectTransform.position = t;
	}
}
