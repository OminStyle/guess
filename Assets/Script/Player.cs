using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int playerID;
	private ArrayList myAnswers;
	bool clicked;

	public Player(int id){
		playerID = id;
		myAnswers = new ArrayList ();
	}
	

	void storeAnswer(string myCurrentAnswer){
		myAnswers.Add (myCurrentAnswer);
	}

	bool alreadySaidIt(string s){
		return myAnswers.Contains (s);
	}
}
