using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour
{

	public Text guessTxt;
	int max;
	int maxNumGuesses = 5;
	int min;
	int guess;
	int guessCap = 15;
	int numGuess;
	bool playerWin = false;
	

	// Use this for initialization
	void Start ()
	{
		StartGame ();	
	}

	void StartGame ()
	{
		max = 1000;
		min = 1;
		guess = Random.Range (min, max + 1);
		print (guessCap);
		numGuess = 0;
		guessTxt.text = guess.ToString ();
	}

	void NextGuess ()
	{
		numGuess++;
		maxNumGuesses--;
		guess = Random.Range (min, max + 1);
		guessTxt.text = guess.ToString();
		if(maxNumGuesses = 0) {
			playerWin = true;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (numGuess >= guessCap) {
			playerWin = false;
			ExposeCheater ();
		}
	}

	public void GuessHigher() {
		if(guess == max || guess == min) {
			playerWin = false;
			ExposeCheater ();
		}
		min = guess;
		NextGuess ();
	}
	
	public void GuessLower() {
		if(guess == max || guess == min) {
			playerWin = false;
			ExposeCheater ();
		}
		max = guess;
		NextGuess ();
	}
	
	public void CorrectGuess() {
		int number = guess;
		if(playerWin == true) {
			Application.LoadLevel ("Win");
		} else {
			Application.LoadLevel ("Lose");
			guess = number;
		}
	}

	void ExposeCheater ()
	{
		Application.LoadLevel ("Cheat");
	}
}
