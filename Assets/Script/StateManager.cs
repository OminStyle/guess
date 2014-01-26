using UnityEngine;
using System.Collections;

/* StateManager.cs
 * Static class that other game objects can refer to for state informations
 */

public class StateManager: MonoBehaviour{
	
	public static int playerTurn;	// either 1 or 2. DO NOT ASSIGN ANY OTHER VALUE TO IT
	public static int playerJinxed;	// 0, 1 or 2. 0 means no player is Jinxed, 1 means player 1 is, 2 means player 2 is.

	public static Timer tm;
	static private bool clicked;

	void Start() {
		tm = GameObject.Find ("CountdownTimer").GetComponent<Timer>();
		if (tm == null) {
			Debug.Log ("timer is unassigned in StateManager");
		}
		clicked = false;
		StartGame ();
	}
	
	void Update() {
	}

	public void StartGame() {
		playerTurn = 1;
		playerJinxed = 0;
		tm.StartTimer();
	}
	
	public static int GetPlayerTurn() {
		return playerTurn;
	}
	
	public static int GetPlayerJinxed() {
		return playerJinxed;
	}
	
	public static void UpdatePlayerTurn() {
		if (playerTurn != 1 && playerTurn != 2) {
			return;
		}
		else if(playerTurn == 1){
			playerTurn = 2;
			tm.ResetTimer();
			tm.StartTimer();
		} else {
			playerTurn = 1;
			tm.ResetTimer();
			tm.StartTimer();
		}
		clicked = false;
	}
	
	public void UpdateplayerJinxed(int player) {
		if (player != 0 && player != 1 && player != 2) {
			Debug.Log ("StateManager::Updateo=playerJinxed, invalid player value");
			return;
		}
		else if (player == playerJinxed ||					// for some reason, we are updating the jinxedPlayer to the same value?
		         (player == 1 && playerJinxed == 2) ||		// we can't go from p2 jinxed to p1 jinxed directly
		         (player == 2 && playerJinxed == 1) || 		// or from p1 jinxed to p2 jinxed
		         (player == 1 && playerTurn != 1) ||		// or we are jinxing player who didn't just make a guess now
		         (player == 2 && playerTurn != 2) ) {
			Debug.Log ("StateManager::Updateo=playerJinxed, invalid state transition.");
			Debug.Log("playerTurn = "+playerTurn);
			Debug.Log ("playerJinxed = "+playerJinxed);
			Debug.Log ("passed in argument player: "+player);
			return;
		}
		else {
			if (player == 0) {
				UnjinxPlayer();
			}
			else if (player == 1) {
				// It should be player 1's turn
				if (playerTurn == 1) {
					JinxPlayer(1);
				}
				else if (playerTurn == 2) {
					JinxPlayer(2);
				}
			}
		}
	}
	
	public void UnjinxPlayer() {
		// currently jinxed player is stored in playerJinxed
		
		// Clear unjinx list
		// Update jinxed state
		playerJinxed = 0;
		// Swap player turn
		playerTurn = (playerTurn == 1) ? 0 : 1;
	}

	public void JinxPlayer(int playerId) {
		// stub function for now
	}

	public static bool click() {
		bool temp = clicked;
		if (clicked == false) {
			clicked = true;
		}
		return temp;
	}
}
