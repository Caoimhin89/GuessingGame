using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{
	public Text text;
	private enum States {cell, cell_2, mirror, cell_mirror, sheets_0, locks_0, sheets_1, locks_1, corridor_0, corridor_1,
		corridor_2, corridor_3, stairs_0, stairs_1, stairs_2, floor, closet_door, in_closet, courtyard, freedom};
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
		switch(myState) {
			case States.cell:
				cell ();
				break;
			case States.sheets_0:
				sheets_0 ();
				break;
			case States.locks_0:
				locks_0 ();
				break;
			case States.mirror:
				mirror ();
				break;
			case States.cell_mirror:
				cell_mirror ();
				break;
			case States.sheets_1:
				sheets_1 ();
				break;
			case States.locks_1:
				locks_1();
				break;
			case States.corridor_0:
				corridor_0 ();
				break;
			case States.stairs_0:
				stairs_0 ();
				break;
			case States.closet_door:
				closet_door();
				break;
			case States.floor:
				floor ();
				break;
			case States.in_closet:
				in_closet ();
				break;
			case States.corridor_1:
				corridor_1 ();
				break;
			case States.stairs_1:
				stairs_1 ();
				break;
			case States.corridor_2:
				corridor_2 ();
				break;
			case States.corridor_3:
				corridor_3 ();
				break;
			case States.stairs_2:
				stairs_2 ();
				break;
			case States.courtyard:
				courtyard ();
				break;
			case States.cell_2:
				cell_2 ();
				break;
			case States.freedom:
				freedom ();
				break;
		}
	
	}

	void cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " + 
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view the Sheets, M to view the Mirror, and L to view the Lock.";

		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		} else if(Input.GetKeyDown (KeyCode.L)) {
			myState = States.locks_0;
		} else if(Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
	}

	void sheets_0() {
		text.text = "You can't believe that you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to your cell.";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void locks_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell.";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} else if(Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}

	void cell_mirror() {
		text.text = "You are still in your cell and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view the Sheets, or L to view the Lock";
		
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_1;
		} else if(Input.GetKeyDown (KeyCode.L)) {
			myState = States.locks_1;
		}
	}

	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell.";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void locks_1() {
		text.text = "You carefully put the mirror through the bars and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell.";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		} else if(Input.GetKeyDown (KeyCode.O)) {
			myState = States.corridor_0;
		}
	}

	void corridor_0() {
		text.text = "The door swings open! It was awfully squeeky, but nobody seems to have heard anything. " +
					"You're now standing in a long corridor. There is a flight of stairs going down, a " +
					"closet door just a few feet away from you, and something small and shiny laying on the floor.\n\n" +
					"Press S to take the Stairs, F to pick the item off the Floor, or C to try to get into the Closet.";
		
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_0;
		} else if(Input.GetKeyDown (KeyCode.C)) {
			myState = States.closet_door;
		} else if(Input.GetKeyDown (KeyCode.F)) {
			myState = States.floor;
		}
	}

	void stairs_0() {
		text.text = "You start going down the stairs slowly. Everything seems to be going well, " +
					"but then you suddenly hear something... Footsteps! Somebody is making his " +
					"way up the staircase! If you don't act fast, you're bound to get caught!\n\n" +
					"Press R to Return to the corridor.";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void closet_door() {

		text.text = "You approach the closet door. It seems like it would be a good place to hide " +
					"temporarily, while you think about what to do next. You grab the handle and try to " +
					"turn it, but it's firmly locked. You'll need to find some way to open it before anyone " +
					"sees you.\n\n" +
					"Press R to Return to the corridor.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void floor() {
		text.text = "You kneel down to inspect the shiny object on the floor more closely and discover that it's " +
					"just a hair pin. You aren't sure how it could possibly help you, but then again it couldn't hurt " +
					"to take it with you just in case.\n\n" +
					"Press T to Take the pin, Press D to Drop the pin";
			
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.corridor_1;
		} else if(Input.GetKeyDown (KeyCode.D)) {
			myState = States.corridor_0;
		}
	}

	void corridor_1() {
		text.text = "You get back to your feet and take a look around the room. There is still only one way out. " +
					"You'll have to take the stairs. Although, you could try to hide in the closet and plan the rest " +
					"of your escape without worrying about being seen.\n\n" +
					"Press S to try your luck on the Stairs or C to try and get into the closet.";

		if(Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_1;
		} else if(Input.GetKeyDown (KeyCode.C)) {
			myState = States.in_closet;
		}
	}

	void stairs_1() {
		text.text = "You start heading down the stairs, but as you go you can hear footsteps and voices ahead. It's just " +
					"too risky to continue on. You'll almost certainly get caught by someone. You need to take some time and " +
					"plan what to do next.\n\n" +
					"Press R to Return to the corridor";

		if(Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_1;
		}
	}

	void in_closet() {
		text.text = "You try the door handle, but it's firmly locked. There are voices on the stairs and they're growing louder." +
					"You know you're about to get caught... But then you remember the hair clip, retrieve it from your pocket and manage " +
					"to pick the lock and get into the closet. Just in the knick of time. While you wait for the guard to leave, you notice some " +
					"fresh clothes folded and placed on a shelf. These aren't just any clothes, though. It's a guard's uniform! This could really be helpful!\n\n" +
					"Press R to Return to the corridor or D to Dress in the guard's uniform.";
			
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_2;
		} else if(Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_3;
		}
	}

	void corridor_2() {
		text.text = "You sneak back into the corridor and take a look around. It seems like the guard has gone. You can duck back " +
					"into the closet and hide or you can try and make a break for it.\n\n" +
					"Press C to get back in the Closet or S to make a mad dash up the Stairs";
			
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.in_closet;
		} else if(Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_2;
		}
	}

	void stairs_2() {
		text.text = "As it turns out, that was a terrible decision. Just as you take your first steps up the stairs the sound of voices " +
					"and footfalls returns. The guard is coming back! You're going to have to hide! And FAST!!\n\n" +
					"Press H to run to the corridor and Hide in the closet";
		
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.in_closet;
		}
	}

	void corridor_3() {
		text.text = "You put on the guard's uniform and step out of the closet and into the corridor. A passing guard looks at you " +
					"strangely and asks 'sleeping on the job, are we?'. You smile and nod as sweat drips from your brow. You're nervous, " +
					"but you'll have to make a decision.\n\n" +
					"Press U to scream, tear off your Uniform and dive back into the closet or S to take the Stairs again";

		if(Input.GetKeyDown (KeyCode.U)) {
			myState = States.in_closet;
		} else if(Input.GetKeyDown (KeyCode.S)) {
			myState = States.courtyard;
		}
	}

	void courtyard() {
		text.text = "Almost home free! You feel the fresh air on your face as you exit the building and step into the courtyard. " +
					"You can see the gate and it's open! However, it's surrounded by a guard on either side of it and sentries in " +
					"the guard towers with scoped rifles. You feel a lump form in your throat and your stomach is tied up in knots.\n\n" +
					"Press G to go through the Gate or R to Return to your cell and give up.";

		if(Input.GetKeyDown (KeyCode.G)) {
			myState = States.freedom;
		} else if(Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_2;
		}
	}

	void cell_2() {
		text.text = "Well, you're back in your cell. It's not paradise, but as you lay down on your dirty cot and calm your nerves down " +
					"you decide you've made the right choice. You probably wouldn't have gotten away with it anyway and at least now you " +
					"are free to pay your debts to society... for the next 50 years! 'Should have paid those parking tickets' you sigh as you " +
					"look up at the ceiling of your little cell.\n\n" +
					"GAME OVER!!!";
	}

	void freedom() {
		text.text = "You smile nervously as you pass the guards. They wave to you in acknowledgement as you pass through the gates. " +
					"You can hardly believe it as you walk right into the parking lot and hop on a bus. You know exactly where you're going to " +
					"go. Straight to Mexico!! You are finally FREE!\n\n" +
					"Great job!! You won!! Press P to Play again.";
		
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
		}
	}
}
