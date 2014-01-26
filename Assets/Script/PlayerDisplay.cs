using UnityEngine;
using System.Collections;

public class PlayerDisplay : MonoBehaviour {
	
	
	void OnGUI () {

		string text = "Player " + StateManager.playerTurn + "'s turn. ";
		if (StateManager.playerJinxed != 0) {
			text += "Player "+StateManager.playerJinxed+" is jinxed.";
		}
		GUI.Label (new Rect (600, 300, 100, 100), text);
	}

	

}
