using UnityEngine;
using System.Collections;

public class TextHighlight : MonoBehaviour {

	public Color highlightColor = Color.red;
	public Color defaultColor = Color.white;

	void OnMouseEnter() {
		renderer.material.color = Color.red;
	}

	void OnMouseExit() {
		renderer.material.color = Color.white;
	}
}
