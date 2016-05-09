﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("LoadLevel request for: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}

	public void QuitRequest() {
		Debug.Log ("Quit request");
		Application.Quit ();
	}

	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if(Brick.breakableCount <= 0) {
		   LoadNextLevel ();
		}
	}
}