﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars_CenterOfGravity : MonoBehaviour {

	float rotationSpeed = 3.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
	}
}