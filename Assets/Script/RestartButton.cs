using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

    void OnGUI(){
		if ((GUI.Button(new Rect(80, 550, 60, 30), "Restart"))){
			Application.LoadLevel(0);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
