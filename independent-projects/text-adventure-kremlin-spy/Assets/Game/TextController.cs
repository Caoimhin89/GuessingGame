using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "Welcome, agent! Your mission, should you choose to accept it, is to infiltrate the " +
					"the Kremlin for reasons, which you don't need to know, and which I haven't invented, yet. " +
					"To successfully complete your mission, you will need to gain access to the Kremlin and bug " +
					"the offices of the president of the Russian Federation, along with those of his top aides. " +
					"Your mission is not without risks and you will need to think on your feet and avoid capture at all " +
					"costs. We don't want an international incident, because you were sloppy. If you get into trouble, " +
					"get out of there! If you get caught, you're on your own. It would be too damaging to the reputation of " +
					"this agency to acknowledge that you work for us, and so we won't. Good luck, agent! Get the job done!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
