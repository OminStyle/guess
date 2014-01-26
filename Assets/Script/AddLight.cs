using UnityEngine;
using System.Collections;

public class AddLight : MonoBehaviour {
	public GameObject spotlight;
	public GameObject plane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 clickPosition = Input.mousePosition;
			Debug.Log(clickPosition.x + " " + clickPosition.y + " " + clickPosition.z);
			if(clickPosition.x > 90 && clickPosition.x < 592 &&
			   clickPosition.y > 108 && clickPosition.y < 616) {
				clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
				clickPosition.z = -10;
				Instantiate( spotlight, clickPosition,Quaternion.identity);
			}
		}
	}
}
