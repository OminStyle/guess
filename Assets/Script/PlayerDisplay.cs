using UnityEngine;
using System.Collections;

public class PlayerDisplay : MonoBehaviour {

	private static string result;

	void OnGUI () {

		if (SubmitButton.getResult()) {
			result = "Player "+StateManager.playerTurn + "wins!!!!!!";
			GUI.Label(new Rect(600,50,Screen.width,Screen.height),result);

		}



		string text = "Player " + StateManager.playerTurn + "'s turn. ";
		if (StateManager.playerJinxed != 0) {
			text += "Player "+StateManager.playerJinxed+" is jinxed.";
		}
		GUI.Label (new Rect (600, 300, 100, 100), text);
	}



}
