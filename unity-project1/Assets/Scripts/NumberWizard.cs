using UnityEngine;
using System.Collections;
using System;

public class NumberWizard : MonoBehaviour
{

	int max;
	int min;
	int guess;
	int guessCap;
	int numGuess;
	Boolean gameOver;
	

	// Use this for initialization
	void Start ()
	{
		max = 1000;
		min = 1;
		guess = 500;
		guessCap = calculateGuessCap (max);
		numGuess = 0;
		gameOver = false;
		StartGame ();
		
	}

	void StartGame ()
	{
		print ("===================================================");
		print ("Welcome to NumberWizard!");
		print ("Pick a number in your head, but don't tell me!");
		
		print ("The highest number you can pick is " + max + ".");
		print ("The lowest number you can pick is " + min + ".");
		
		print ("Is the number higher or lower than " + guess + "?");
		print ("Up arrow for higher, down arrow for lower, return for equal.");

		max++;
	}

	void NextGuess ()
	{
		numGuess++;
		guess = (min + max) / 2;
		print ("Is the number higher or lower than " + guess + "?");
		print ("Up arrow for higher, down arrow for lower, return for equal.");
	}

	void ExposeCheater ()
	{
		print ("Hey, cheater! You have to pick a number in the specified range! And no changing your answer!");
		print ("You lose!");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameOver == false) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				print ("Up arrow pressed.");
				min = guess;
				NextGuess ();
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				print ("Down arrow pressed.");
				max = guess;
				NextGuess ();
			} else if (Input.GetKeyDown (KeyCode.Return)) {
				print ("I won!");
			} else if (numGuess == guessCap || guess > max || guess < min) {
				ExposeCheater ();
				numGuess = 0;
				gameOver = true;
			}
		}
	}

	int calculateGuessCap (int max)
	{
		int guesses = 0;
		while (max > 0) {
			max /= 2;
			guesses++;
		}
		return guesses;
	}
}
