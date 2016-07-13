using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class jekylHyde : MonoBehaviour
{

	public Text myTextObject;
	string currentRoom = "kitchen";
	int readMore = 0;
	bool boopedHuman = false;
	bool infoScreen = false;
	bool boxOpen = false;
	bool tappedDoor = false;
	bool tappedBox = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		string textBuffer = "";


		textBuffer = "you are currently in: " + currentRoom;

		if (currentRoom == "kitchen") {
			if (boopedHuman) {
				textBuffer += "The Door is now open! You may go outside.";
			}
			if (tappedDoor) {
				textBuffer += "\nThe Door is locked. If only you had thumbs. Time to bother the servent.";
			}

			textBuffer += "\nYou look out the window above your food dish. As the sun sets, the fireflies begin their mating ritual. Their yellow lights contrast the blue green plants, leaving a trailing negative whenever you blink. " +
			"\nYou are filled with the hunt. You see the door to the outside and one to the living room." +
			"\nPress [D] to go outside. \nPress [F] to go to the living room";
			if (readMore == 0) {
				textBuffer += "\nPress[R] to read more about the room.";
			} else {
				textBuffer += "\nYou look around the room. It is plain, but this room has the most sunlight. \nAnd your servant seems happy whenever you are here when they come from the outside. \nEasy pets.";
			}


			if (Input.GetKeyDown (KeyCode.D)) {
				if (boopedHuman == true) {
				currentRoom = "outside";
				readMore = 0;
			} else {
				tappedDoor = true;
			}
		} else if (Input.GetKeyDown (KeyCode.F)) {
			currentRoom = "living room";
			textBuffer += "\nYou go into the living room.";
			readMore = 0;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			readMore = 1;	 
		}
	
		} else if (currentRoom == "living room") {
			if (boopedHuman) {
				textBuffer += "\nThe Box has bloomed and is now go-in-able.";
			}
			if (tappedBox) {
				textBuffer += "\nFoiled again by your lack of thumbs. Time to bother the Servant.";
			}

			textBuffer += "\nThe thin black box is on, making a show of lights and sound. There is also a new box for you to sleep in."+
			"\nPress [D] to go to the Kitchen. \nPress [F] to go to the Hallway. \nPress [S] to go into the Box.";
			if (readMore == 0) {
				textBuffer += "\nPress[R] to read more about the room.";
			} else {
				textBuffer += "\nThere are many scatching posts and plants to play with.\nEven if the servant doesn't like it when you do.";
			}

			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "kitchen"; 
				readMore = 0;
			} else if (Input.GetKeyDown (KeyCode.F)) {
				currentRoom = "hallway";
				readMore = 0;
			} else if (Input.GetKeyDown (KeyCode.R)) {
				readMore = 1;

			} else if (Input.GetKeyDown (KeyCode.S)) {
				if (boopedHuman == true) {
					currentRoom = "box";
					readMore = 0;
				} else {
					tappedBox= true;
				}
			}
		} else if (currentRoom == "hallway") {
			textBuffer += "\nThe hallway is long. "+
			"\nPress [D] to go to the Living Room. \nPress [F] to go to the Servant's Quarter.";
			if (readMore == 0)
				textBuffer += "\nPress[R] to read more about the room.";
			else textBuffer+= "\nIt is good for midnight scurrying.";
			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "living room"; 
				textBuffer += "\nYou go into the Living Room.";
				readMore = 0;
			} else if (Input.GetKeyDown (KeyCode.F)) {
				currentRoom = "bedroom";
				readMore = 0;
			} else if (Input.GetKeyDown (KeyCode.R)) {
				readMore = 1;

			}
		} else if (currentRoom == "box") {
			textBuffer += "\nYou immediatley feel comfort from the world and begin to purr." +
			"\nPress [D] to go to the Living Room.";
				
			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "living room"; 
				textBuffer += "\nYou go into the Living Room.";
				readMore = 0;
			}
			
		} else if (currentRoom == "bedroom") {
			textBuffer += "\nThe Servant's quarter is dark. You can here their snoring. \nSounds like a stupid dog." +
			"\nPress [D] to go to the Hallway.";
			if (boopedHuman)
				textBuffer += "\nYou have woken the human booping his face. With your claws.";
			else
				textBuffer += " \nPress [S] to wake the servant.";
			if (readMore == 0)
				textBuffer += "\nPress[R] to read more about the room.";
			else textBuffer+= "\nThis was once the only place you knew. The servant kept you here for a period time before allowing you to rein over the full domain.";


			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "hallway";
				readMore = 0;
			} else if (Input.GetKeyDown (KeyCode.R)) {
				readMore = 1;

			} else if (Input.GetKeyDown (KeyCode.S)) {
				boopedHuman = true;
				tappedDoor = false;
				tappedBox = false;
			}
		} else if (currentRoom == "outside") {
			textBuffer += "\nAhh yes. The smells are delicious. You immediatley begin to run after the fireflies." +
			"\nPress [F] to go to the Kitchen.";
			if (Input.GetKeyDown (KeyCode.F)) {
				currentRoom = "kitchen"; 
				textBuffer += "\nYou go into the kitchen.";
				readMore = 0;
			}
		}

		GetComponent<Text> ().text = textBuffer;
			
	}
}