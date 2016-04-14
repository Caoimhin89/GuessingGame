using UnityEngine;
using System.Collections;
using System;

public class NumberWizard : MonoBehaviour
{

	int max = 1000;
	int min = 1;
	int guess = 500;
	int guessCap;
	int numGuess = 0;
	Boolean gameOver = false;

	NumberWizard ()
	{

		this.guessCap = calculateGuessCap (max);
	}

	// Use this for initialization
	void Start ()
	{
		max++;
		print ("Welcome to NumberWizard!");
		print ("Pick a number in your head, but don't tell me!");
		
		print ("The highest number you can pick is " + max + ".");
		print ("The lowest number you can pick is " + min + ".");
		
		print ("Is the number higher or lower than " + guess + "?");
		print ("Up arrow for higher, down arrow for lower, return for equal.");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameOver == false) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				print ("Up arrow pressed.");
				min = guess;
				numGuess++;
				guess = (max + min) / 2;
				print ("Higher or lower than " + guess + "?");
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				print ("Down arrow pressed.");
				max = guess;
				numGuess++;
				guess = (min + max) / 2;
				print ("Higher or lower than " + guess + "?");
			} else if (Input.GetKeyDown (KeyCode.Return)) {
				print ("I won!");
			} else if (numGuess == guessCap) {
				print ("Hey, cheater! You have to pick a number in the specified range! I should have guessed your number by now if you were playing fair!");
				print ("You lose!");
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
