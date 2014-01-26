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

	public GameObject p1Obj;
	public GameObject p2Obj;
	public GameObject popupObj;
	private PopupController pc;

	void Start() {
		tm = GameObject.Find ("CountdownTimer").GetComponent<Timer>();
		if (tm == null) {
			Debug.Log ("timer is unassigned in StateManager");
		}
		pc = popupObj.GetComponent<PopupController>();
		clicked = false;
		StartGame ();
	}
	
	void Update() {
		GUIText stateTxt = this.transform.FindChild("state").GetComponent<GUIText>();
		stateTxt.text = "playerTurn: "+playerTurn+" playerJinxed: "+playerJinxed;

		if (pc.IsPopupShowing()) {
			if (Input.anyKeyDown) {
				pc.HidePopup();
				tm.StartTimer ();
			}
		}
	}
	
	public void StartGame() {
		playerTurn = 1;
		playerJinxed = 0;
		tm.ResetTimer ();
		tm.StartTimer();
	}
	
	public int GetPlayerTurn() {
		return playerTurn;
	}
	
	public int GetPlayerJinxed() {
		return playerJinxed;
	}
	
	public void UpdatePlayerTurn() {
		Debug.Log ("UpdatePlayerTurn");
		if (playerTurn != 1 && playerTurn != 2) {
			return;
		}
		else if(playerTurn == 1){
			if (playerJinxed == 0) {	// no one is jinxed, everything is normal
				playerTurn = 2;
				tm.ResetTimer();
				pc.ShowPopup(1, false);
				//tm.StartTimer();
			}
			else if (playerJinxed == 1){
				playerTurn = 2;
				tm.ResetJinxedTimer();
				tm.StartTimer();
			}
			clicked = false;
		} else {
			if (playerJinxed == 0) {	// no one is jinxed, everything is normal
				playerTurn = 1;
				tm.ResetTimer();
				pc.ShowPopup(1, false);
				//tm.StartTimer();
			}
			else if (playerJinxed == 2){
				playerTurn = 1;
				tm.ResetJinxedTimer();
				tm.StartTimer();
			}
			clicked = false;
		}
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
				pc.ShowPopup (4, false);
				UnjinxPlayer();
			}
			else if (player == 1) {
				// It should be player 1's turn
				if (playerTurn == 1) {
					pc.ShowPopup (2, false);
					JinxPlayer(1);
				}
				/* Never gonna be here
				else if (playerTurn == 2) {
					JinxPlayer(2);
				}*/
			}
			else if (player == 2) {
				// It should be player 1's turn
				if (playerTurn == 2) {
					pc.ShowPopup (2, false);
					JinxPlayer(2);
				}
				/* Never gonna be here
				else if (playerTurn == 1) {
					JinxPlayer(1);
				}*/
			}
			
		}
	}
	
	public void UnjinxPlayer() {
		// currently jinxed player is stored in playerJinxed
		
		// Clear unjinx list
		// Update jinxed state
		Debug.Log ("Unjinx Player");
		playerJinxed = 0;
		// Swap player turn
		if (playerTurn == 1) {
			// clear player 2's unjinx list
			p2Obj.GetComponent<Player>().ClearUnjinxAnswer ();
		}
		else if (playerTurn == 2) {
			// clear player 1's unjinx list
			p1Obj.GetComponent<Player>().ClearUnjinxAnswer ();
		}
		else {
			// game is brokem
			Debug.Log ("Invalid playerTurn in StateManager::UnjinxPlayer");
		}
		UpdatePlayerTurn();
	}
	
	public void JinxPlayer(int playerId) {
		Debug.Log ("Jinx Player");
		playerJinxed = playerId;
	}

	public bool click() {
		bool temp = clicked;
		if (clicked == false) {
			clicked = true;
		}
		return temp;
	}

}