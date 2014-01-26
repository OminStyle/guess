using UnityEngine;
using System.Collections;

public class AddLight : MonoBehaviour {
	public GameObject spotlight;
	public GameObject directionalLight;
	private StateManager sm;
	// Use this for initialization
	void Start () {

		sm = GameObject.Find ("StateManager").GetComponent<StateManager>();
		if (sm == null) {
			Debug.Log ("Game is broken, no state manager");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !sm.click()) {
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

	public void revealPic() {
		Instantiate(directionalLight, new Vector3(),Quaternion.identity);
	}
}
