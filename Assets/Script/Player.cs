using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int playerID;
	private ArrayList unJinxedAnswers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool alreadySaidIt(string s){
		return unJinxedAnswers.Contains (s);
	}
}
