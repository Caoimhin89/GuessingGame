﻿using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy (collider.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
