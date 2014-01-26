using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int playerID;
	private ArrayList myAnswers;
	private ArrayList unjinxAnswers;
	bool clicked;
	public int maxUnjinxAnswerCount = 1;
	
	
	void Start() {
		myAnswers = new ArrayList ();
		unjinxAnswers = new ArrayList();
	}
	
	void Update() {
		
	}
	
	public Player(int id){
		playerID = id;
		myAnswers = new ArrayList ();
	}

	public ArrayList getMyAnswers() {
		return myAnswers;
	}

	
	public void storeAnswer(string myCurrentAnswer){
		myAnswers.Add (myCurrentAnswer);
	}
	
	public bool alreadySaidIt(string s){
		Debug.Log ("alreadySaidIt, s = "+s);
		bool ret = myAnswers.Contains (s);
		Debug.Log ("ret = "+ret);
		return ret;
	}
	
	public void storeUnjinxAnswer(string answer) {
		unjinxAnswers.Add (answer);
		if (unjinxAnswers.Count >= maxUnjinxAnswerCount) {
			StateManager.UpdatePlayerTurn();
			// Once player have entered enough unjinx answers, switch to the other player's turn.
		}
	}
	
	public bool checkUnjinxAnswer(string ans) {
		return unjinxAnswers.Contains (ans);
	}
	
	
}