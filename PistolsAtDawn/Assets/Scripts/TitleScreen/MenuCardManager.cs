using UnityEngine;
using System.Collections;

public class MenuCardManager : MonoBehaviour {

	//menu card initial stuff
	public GameObject menuCanvas;

	public GameObject mainPanel;
	public GameObject optionPanel;
	public GameObject chapterPanel;

	Vector3 mainPanelStartLocation;
	Vector3 optionPanelStartLocation;
	Vector3 chapterPanelStartLocation;

	// Use this for initialization
	void Start () {
		//menuCanvas = GameObject.Find ("MenuCanvas");
		//mainPanel = GameObject.Find ("MainPanel");
		//optionPanel = GameObject.Find ("OptionPanel");

		//this may be problematic due to being a reference
		mainPanelStartLocation = mainPanel.transform.position;
		optionPanelStartLocation = optionPanel.transform.position;
		chapterPanelStartLocation = chapterPanel.transform.position;

		//get it started
		ChangeToMenu ("Main");


	
	}
	
	// Update is called once per frame
	void Update () {
	}

	//decides which menu to change to.
	//0=Cleanup, 1=Main, 2=Options, 3=Chapters
	public void ChangeToMenu(string i)
	{
		switch (i)
		{
		case "Main":
			ChangeToMenu ("clean");
			print ("Main Menu Requested");
			mainPanel.transform.position = mainPanelStartLocation;
			break;

		case "Options":
			ChangeToMenu ("clean");
			print ("Options Menu Requested");
			optionPanel.transform.position = mainPanelStartLocation;
			break;

		case "Chapters":
			ChangeToMenu ("clean");
			print ("Chapters Menu Requested");
			Vector3 tempVector3 = mainPanelStartLocation;

			RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();

			tempVector3.Set(objectRectTransform.rect.width/2,objectRectTransform.rect.height/2,0.0f);
			chapterPanel.transform.position = tempVector3;//mainPanelStartLocation;
			break;

		default:
			print ("Menu being told to cleanup");
			mainPanel.transform.position = new Vector3 (optionPanel.transform.position.x, 
			                                            -440.0f, 
			                                            optionPanel.transform.position.z);

			optionPanel.transform.position = optionPanelStartLocation;
			chapterPanel.transform.position = chapterPanelStartLocation;
			break;
		}
	}
}
