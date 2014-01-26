using UnityEngine;
using System.Collections;

public class PlayerDisplay : MonoBehaviour {
	
	
	void OnGUI () {

		GUI.Label (new Rect (600, 300, 100, 100), "Player " + 2/*StateManager.playerturn*/ + " 's turn");
	}

	

}
