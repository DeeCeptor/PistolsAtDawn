using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoScrollText : MonoBehaviour {

	public Text contentText;
	public float scrollSpeed = 0.1f;
	public RectTransform scrollRectTransform;
	private float endScrollYPos;

	void Start(){
		endScrollYPos = scrollRectTransform.rect.height - scrollRectTransform.offsetMax.y;
	}

	void OnGUI(){
		if (!hasFinishedScrolling()) {
			Vector3 pos = contentText.rectTransform.position;
			pos.y += scrollSpeed;
			contentText.rectTransform.position = pos;
		}
	}

	bool hasFinishedScrolling(){
		if (contentText.rectTransform.position.y > endScrollYPos) {
			return true;
		}
		return false;
	}
}
