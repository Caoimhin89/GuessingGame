using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour
{

	public Text guessTxt;
	public Text guessCount;
	int max;
	int min;
	int guess;
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
		numGuess = 0;
		guessCount.text = numGuess.ToString ();
		guessTxt.text = guess.ToString ();
		guessTxt.color = Color.white;
	}

	void NextGuess ()
	{
		if(numGuess < 5) {
			guessCount.color = Color.red;
		} else {
			guessCount.color = Color.green;
		}
		numGuess++;
		guessCount.text = numGuess.ToString();
		if(max == 1000) {
			guess = Random.Range (min + 1, max + 1);
		} else {
			guess = Random.Range (min, max);
		}
		guessTxt.text = guess.ToString();
		if(numGuess == 6) {
			playerWin = true;
		}
	}

	// Update is called once per frame
	
	public void GuessHigher() {
		if(guess == max) {
			playerWin = false;
			ExposeCheater ();
		}
		min = guess;
		NextGuess ();
	}
	
	public void GuessLower() {
		if(guess == min) {
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
