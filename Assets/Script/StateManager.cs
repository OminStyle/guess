using UnityEngine;
using System.Collections;

/* StateManager.cs
 * Static class that other game objects can refer to for state informations
 */

public class StateManager: MonoBehaviour{

	public static int playerTurn;	// either 1 or 2. DO NOT ASSIGN ANY OTHER VALUE TO IT
	public static int playerJinxed;	// 0, 1 or 2. 0 means no player is Jinxed, 1 means player 1 is, 2 means player 2 is.

	void Start() {
	}

	void Update() {
	}

	
	public static int GetPlayerTurn() {
		return playerTurn;
	}

	public static int GetPlayerJinxed() {
		return playerJinxed;
	}

	public void UpdatePlayerTurn(int player) {
		if (player != 1 && player != 2) {
			return;
		}
		else {
			// do stuff here
		}
	}

	public void UpdateplayerJinxed(int player) {
		if (player != 0 && player != 1 && player != 2) {
			return;
		}
		else {
			// do stuff here
		}
	}
}
