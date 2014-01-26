using UnityEngine;
using System.Collections;

public class KeystrokePlayer : MonoBehaviour {
	
	public AudioClip[] ksArray;
	public bool doPlayKeyStroke = true;
	
	// Use this for initialization
	void Start () {
		if (ksArray == null) {
			Debug.LogError ("ksArray is null");
		}
		else {
			doPlayKeyStroke = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (doPlayKeyStroke && Input.anyKeyDown && 
		    !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) ) ){
			PlayKeyStroke();
		}
	}
	
	public void PlayKeyStroke() {
		AudioSource.PlayClipAtPoint(ksArray[Random.Range (0, 3)], new Vector3(0f, 0f, 0f));
	}
}
