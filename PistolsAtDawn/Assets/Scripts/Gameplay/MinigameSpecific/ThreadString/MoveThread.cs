using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveThread : MonoBehaviour 
{
	private LineRenderer line;
	private bool isMousePressed;    
	private List<Vector3> pointsList;    
	private Vector3 mousePos;   
	private Vector3 startPos;
	private Rigidbody2D physics;

	struct myLine
	{
		public Vector3 StartPoint;         
		public Vector3 EndPoint;    
	};    
	public GameObject minigame;		// Pass in LightMAtch minigame
	
	
	void Awake()    
	{        
		// Create line renderer component and set its property    
		startPos = this.gameObject.transform.position;

		// Set line renderer. Willneed to change to look like string
		line = gameObject.AddComponent<LineRenderer>();         
		line.material =  new Material(Shader.Find("Particles/Additive"));         
		line.SetVertexCount(0);        
		line.SetWidth(0.8f, 0.8f);         
		line.SetColors(Color.white, Color.white);         
		line.useWorldSpace = true;            
		isMousePressed = false;        
		pointsList = new List<Vector3>();    
	}    


	void Start () 
	{
		physics = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		if(!physics.isKinematic)        
		{            
			/* Have mouse control movement directly
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
			mousePos.z = 0;
			this.physics.MovePosition(mousePos);
			mousePos = physics.transform.position;
			*/
			// Or let DragItems script control its movement
			mousePos = this.transform.position;
			if (!pointsList.Contains (mousePos))              
			{                
				pointsList.Add (mousePos);                 
				line.SetVertexCount (pointsList.Count);                 
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);                        
			}        
		}    
	}
	void resetLine()
	{
		line.SetVertexCount(0);             
		pointsList.RemoveRange(0,pointsList.Count);             
		line.SetColors(Color.green, Color.green);  
	}
}
