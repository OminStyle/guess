using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int playerID;
	private ArrayList myAnswers;

	public Player(int id){
		playerID = id;
		myAnswers = new ArrayList ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void storeAnswer(string myCurrentAnswer){
		myAnswers.Add (myCurrentAnswer);
	}

	bool alreadySaidIt(string s){
		return myAnswers.Contains (s);
	}
}
