using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

    void OnGUI(){
				if ((SubmitButton.getResult ())) {
						if ((GUI.Button (new Rect (80, 550, 60, 30), "Restart"))) {
								Application.LoadLevel (0);
								TextGUI.clearText ();
						}
				}
		}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
