using UnityEngine;
using System.Collections;

public class display : MonoBehaviour {
	//public static ArrayList myAnswers = new ArrayList();
	private StateManager sm;

	void Start() {
		sm = GameObject.Find ("StateManager").GetComponent<StateManager>();
		if (sm == null) {
			Debug.Log ("Game is broken, no state manager");
		}
	}
	void OnGUI()
	{
		int y = 100;
		string currentPlayerObj;
		if (sm.GetPlayerTurn() == 1) {
			currentPlayerObj = "P1Obj";
		} else {
			currentPlayerObj = "P2Obj";
		}
		foreach(object str in GameObject.Find (currentPlayerObj).GetComponent<Player>().getMyAnswers()) {
			string ans = (string)str;
			GUI.Label(new Rect(600,y,Screen.width,Screen.height),ans);
			y += 20;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
