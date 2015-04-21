using UnityEngine;
using System.Collections;

public class TextHighlight : MonoBehaviour {

	public Color highlightColor = Color.red;
	public Color defaultColor = Color.white;

	void OnMouseEnter() {
		GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = Color.white;
	}
}
