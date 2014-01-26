using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerID;
	private ArrayList myAnswers;

	void Start() {
		myAnswers = new ArrayList ();
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
}
