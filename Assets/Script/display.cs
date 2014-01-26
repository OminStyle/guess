using UnityEngine;
using System.Collections;

public class display : MonoBehaviour {
	public static ArrayList myAnswers = new ArrayList();

	void OnGUI()
	{
		int y = 100;
		foreach(object str in myAnswers) {
			string ans = (string)str;
			GUI.Label(new Rect(600,y,Screen.width,Screen.height),ans);
			y += 20;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
