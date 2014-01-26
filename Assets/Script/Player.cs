using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int playerID;
	private ArrayList myAnswers;
	private ArrayList unjinxAnswers;
	public string answerStr = "Anwsers:";
	public string unjinxStr = "Unjinx:";
	bool clicked;
	public int maxUnjinxAnswerCount = 1;
	private StateManager sm;
	
	void Start() {
		sm = GameObject.Find ("StateManager").GetComponent<StateManager>();
		if (sm == null) {
			Debug.Log ("Game is broken, no state manager");
		}
		myAnswers = new ArrayList ();
		unjinxAnswers = new ArrayList();
	}
	
	void Update() {
		GUIText ansTxt = this.transform.FindChild("answer").GetComponent<GUIText>();
		ansTxt.text = answerStr;
		GUIText unjTxt = this.transform.FindChild("unjinx").GetComponent<GUIText>();
		unjTxt.text = unjinxStr;
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

		//Debug
		answerStr += "\n"+myCurrentAnswer;
	}
	
	public bool alreadySaidIt(string s){
		Debug.Log ("alreadySaidIt, s = "+s);
		bool ret = myAnswers.Contains (s);
		Debug.Log ("ret = "+ret);
		return ret;
	}
	
	public void storeUnjinxAnswer(string answer) {
		Debug.Log ("Player "+playerID+" storeUnjinxAnswer");
		unjinxAnswers.Add (answer);
		//Debug
		unjinxStr += "\n"+answer;
		Debug.Log ("unjinxAnswers.Count = "+unjinxAnswers.Count);
		if (unjinxAnswers.Count >= maxUnjinxAnswerCount) {

			sm.UpdatePlayerTurn();
			// Once player have entered enough unjinx answers, switch to the other player's turn.
		}
	}
	
	public bool checkUnjinxAnswer(string ans) {
		return unjinxAnswers.Contains (ans);
	}

	public void ClearUnjinxAnswer() {
		Debug.Log ("ClearUnjinxAnswer for player "+playerID);
		unjinxAnswers.Clear();
		unjinxStr = "Unjinx:";
	}
	
}