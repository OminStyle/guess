﻿using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {
	
	public Texture btnTexture;
	public GameObject p1Obj;
	public GameObject p2Obj;
	public AudioClip submitSFX;
	public AudioClip jinxSFX;
	public AudioClip correctSFX;
	public static bool result = false;
	public GameObject smObj;
	private StateManager sm;
<<<<<<< HEAD
	private PopupController pc;
	public bool keyreleased;
=======
	public GameObject popupObj;
	private PopupController pc;
>>>>>>> bae9e5165766e7ef4f464634cb2221f81744d340

	void Start() {
		sm = GameObject.Find ("StateManager").GetComponent<StateManager>();
		if (sm == null) {
			Debug.Log ("Game is broken, no state manager");
		}
		pc = popupObj.GetComponent<PopupController>();
	}

	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		// button using a texture
		//if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
		//	Debug.Log("Clicked the button with an image");


		if ((GUI.Button(new Rect(750, 550, 60, 30), "Submit") || 
		     (Event.current.type == EventType.keyDown && Event.current.character == '\n'))&& 
		    TextGUI.getText() != "") {

			keyreleased = false;
			string myAnswer = TextGUI.getText().ToLower();
			Debug.Log("My answer is: " + myAnswer + ". Real answer is: " + RandomizeTexture.answer1 + ", "+RandomizeTexture.answer2+", "+RandomizeTexture.answer3);
			Player p1 = p1Obj.GetComponent<Player>();
			Player p2 = p2Obj.GetComponent<Player>();
			GameObject.Find("Main Camera").GetComponent<AddLight>().autoUpdate();
			if (sm.GetPlayerJinxed() == 0) {
				if (myAnswer == RandomizeTexture.answer1 || myAnswer == RandomizeTexture.answer2 || myAnswer == RandomizeTexture.answer3) {
					AudioSource.PlayClipAtPoint(correctSFX, new Vector3(0f, 0f, 0f));
					result = true;
					//PlayerDisplay.showWinner();
					Debug.Log("winning test");
					GameObject.Find("CountdownTimer").GetComponent<Timer>().PauseTimer();
					GameObject.Find("Main Camera").GetComponent<AddLight>().revealPic();
					pc.ShowPopup(5, false);
					//Application.Quit();
				
				}
				else {
					TextGUI.clearText ();
					if (sm.GetPlayerTurn() == 1) {
						// compare answer with P2 previous answers
						
						if (p2.alreadySaidIt(myAnswer)) {
							// if answer is matched, P1 is jinxed
							Debug.Log ("p1 Jinxed");
							sm.UpdateplayerJinxed(1);
							AudioSource.PlayClipAtPoint(jinxSFX, new Vector3(0f, 0f, 0f));
							
						}
						else {
							// store player's answer in p1 answer array
							p1.storeAnswer(myAnswer);
							sm.UpdatePlayerTurn();
							AudioSource.PlayClipAtPoint(submitSFX, new Vector3(0f, 0f, 0f));
						}
					}
					else if (sm.GetPlayerTurn() == 2) {
						if (p1.alreadySaidIt(myAnswer)) {
							// if answer is matched, P2 is jinxed
							Debug.Log ("p2 Jinxed");
							sm.UpdateplayerJinxed(2);
							AudioSource.PlayClipAtPoint(jinxSFX, new Vector3(0f, 0f, 0f));
						}
						else {
							// store player's answer in p2 answer array
							p2.storeAnswer(myAnswer);
							sm.UpdatePlayerTurn();
							AudioSource.PlayClipAtPoint(submitSFX, new Vector3(0f, 0f, 0f));
						}
					}
					else {
						// OMG game is horribly broken
					}

				}
			}
			else if (sm.GetPlayerJinxed() == 1) {
				// P1 is jinxed
				if (sm.GetPlayerTurn() == 1) {
					// P1's turn, P1 just submitted something, must be trying to submit unjinx answers
					// store answer in unjinx string array for p1
					p1.storeUnjinxAnswer(myAnswer);
				}
				else if (sm.GetPlayerTurn() == 2) {
					// P2's turn, and P1 is jinxed. P2 is submitting answers to guess the image
					if (myAnswer == RandomizeTexture.answer1 || myAnswer == RandomizeTexture.answer2 || myAnswer == RandomizeTexture.answer3) {
						// award score to P2
						AudioSource.PlayClipAtPoint(correctSFX, new Vector3(0f, 0f, 0f));
						pc.ShowPopup (5, false);
						StartCoroutine ("HidePopup");
						Debug.Log ("P2 Guessed right!");
					}
					else if (p1.checkUnjinxAnswer(myAnswer)) {
						// AHA, P1 is now unjinxed
						sm.UpdateplayerJinxed(0);
					}
					else {
						// nothing changes, I think
						// answer guessed while the other player is jinxed is not counted toward the jinx list
					}
				}
				else {
					// game is broken again
				}
				TextGUI.clearText ();
			}
			else if (sm.GetPlayerJinxed() == 2) {
				// P2 is jinxed
				if (sm.GetPlayerTurn() == 2) {
					// P2's turn, P2 just submitted something, must be trying to submit unjinx answers
					// store answer in unjinx string array for p2
					p2.storeUnjinxAnswer(myAnswer);
				}
				else if (sm.GetPlayerTurn() == 1) {
					// P1's turn, and P2 is jinxed. P1 is submitting answers to guess the image
					if (myAnswer == RandomizeTexture.answer1 || myAnswer == RandomizeTexture.answer2 || myAnswer == RandomizeTexture.answer3) {
						// award score to P1
						AudioSource.PlayClipAtPoint(correctSFX, new Vector3(0f, 0f, 0f));
						pc.ShowPopup (5, false);
						StartCoroutine ("HidePopup");
						Debug.Log ("P1 Guessed right!");
					}
					else if (p2.checkUnjinxAnswer(myAnswer)) {
						// AHA, P2 is now unjinxed
						sm.UpdateplayerJinxed(0);
					}
					else {
						// nothing changes, I think
						// answer guessed while the other player is jinxed is not counted toward the jinx list
					}
				}
				else {
					// game is broken again
				}
				TextGUI.clearText ();
			}
		}
		if (Event.current.type == EventType.keyUp) {
			keyreleased = true;
		}
		
	}

	public static bool getResult(){
		return result;
	}
}
