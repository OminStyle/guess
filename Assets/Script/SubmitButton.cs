using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {
	
	public Texture btnTexture;
	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		
		// button using a texture
		//if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
		//	Debug.Log("Clicked the button with an image");
		
		if (GUI.Button(new Rect(540, 400, 50, 30), "Submit") && TextGUI.getText() != "") {
			string myAnswer = TextGUI.getText().ToLower();
			Debug.Log("My answer is: " + myAnswer + ". Real answer is: " + RandomizeTexture.answer);
			
			if (StateManager.GetPlayerJinxed() == 0) {
				if (myAnswer == RandomizeTexture.answer) {
					Application.Quit();
				}
				else {
					StateManager.UpdatePlayerTurn();
					if (StateManager.GetPlayerTurn() == 1) {
						// compare answer with P2 previous answers
						
						if (true) {
							// if answer is matched, P1 is jinxed
						}
						else {
							// store player's answer in p1 answer array
						}
					}
					else if (StateManager.GetPlayerTurn() == 2) {
						if (true) {
							// if answer is matched, P2 is jinxed
						}
						else {
							// store player's answer in p2 answer array
						}
					}
					else {
						// OMG game is horribly broken
					}
					display.myAnswers.Add(myAnswer);
				}
			}
			else if (StateManager.GetPlayerJinxed() == 1) {
				// P1 is jinxed
				if (StateManager.GetPlayerTurn() == 1) {
					// P1's turn, P1 just submitted something, must be trying to submit unjinx answers
					// store answer in unjinx string array for p1
				}
				else if (StateManager.GetPlayerTurn() == 2) {
					// P2's turn, and P1 is jinxed. P2 is submitting answers to guess the image
					if (myAnswer == RandomizeTexture.answer) {
						// award score to P2
					}
					else {
						// nothing changes, I think
					}
				}
				else {
					// game is broken again
				}
			}
			else if (StateManager.GetPlayerJinxed() == 2) {
				// P2 is jinxed
				if (StateManager.GetPlayerTurn() == 2) {
					// P2's turn, P2 just submitted something, must be trying to submit unjinx answers
					// store answer in unjinx string array for p2
				}
				else if (StateManager.GetPlayerTurn() == 1) {
					// P1's turn, and P2 is jinxed. P1 is submitting answers to guess the image
					if (myAnswer == RandomizeTexture.answer) {
						// award score to P1
					}
					else {
						// nothing changes, I think
					}
				}
				else {
					// game is broken again
				}
			}
		}


	}
}
