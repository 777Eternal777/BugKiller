﻿using UnityEngine;
using System.Collections;

public class DeathMainMenuBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnMouseDown()
	{
		Application.LoadLevel("MainScreen");
	}
}
