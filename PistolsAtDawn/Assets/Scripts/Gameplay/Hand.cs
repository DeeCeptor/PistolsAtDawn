﻿using UnityEngine;
using System.Collections;


public class Hand : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Rigidbody2D rigidbody;
	
	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//rigidbody.velocity = Vector2.zero;
		//rigidbody.angularVelocity = 0;

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		
		rigidbody.MovePosition(curPosition);
	}

}