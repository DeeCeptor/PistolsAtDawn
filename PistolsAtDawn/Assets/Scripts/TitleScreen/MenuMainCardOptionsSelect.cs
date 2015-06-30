using UnityEngine;
using System.Collections;

public class MenuMainCardOptionsSelect : MonoBehaviour {

	private GameObject menuController;//script

	// Use this for initialization
	void Start () {
		menuController = GameObject.Find ("CanvasMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//not used
	void OnMouseDown()
	{
		Debug.Log("OnMouseDown on Options");
		menuController.GetComponent<MenuCardManager> ().ChangeToMenu ("Options");
		//collision object of TextOptions pressed
		//menuController.GetComponent<
	}

	void exposeOptions()
	{

	}
}
