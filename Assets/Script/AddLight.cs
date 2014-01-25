using UnityEngine;
using System.Collections;

public class AddLight : MonoBehaviour {
	public GameObject spotlight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 clickPosition = Input.mousePosition;
			clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
			clickPosition.z = -10;
			Instantiate( spotlight, clickPosition,Quaternion.identity);
		}
	}
}
