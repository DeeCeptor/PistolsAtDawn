using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoScrollText : MonoBehaviour {

	public Text contentText;
	public float scrollSpeed = 0.1f;
	public RectTransform scrollRectTransform;
	public Button continueButton;
	private float endScrollYPos;

	void Start(){
		continueButton.gameObject.SetActive (false);
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
			continueButton.gameObject.SetActive (true);
			return true;
		}
		return false;
	}
}
