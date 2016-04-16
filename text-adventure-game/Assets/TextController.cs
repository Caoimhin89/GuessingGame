using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text;
	private enum States {cell, mirror, sheets_0, locks_0, sheets_1, locks_1, freedom};
	private States myState;

 	// Use this for initialization
	void Start ()
	{
		myState = States.cell;
		print(myState);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(myState == States.cell) {
			state_cell();
		} else if(myState == States.sheets_0) {
			state_sheets_0();
		}
	
	}

	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " + 
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
				"Press S to view the Sheets, M to view the Mirror, and L to view the Lock.";

		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		}
	}

	void state_sheets_0() {
		text.text = "You can't believe that you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to your cell.";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
}
