using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour {

	public Texture[] popupTextures;
	/*
	 * 0: Player 1's turn!
	 * 1: Player 2's turn!
	 * 2: You are JINXED! Try to guess what the other player would guess to unjinx yourself!
	 * 3: The other player is JINXED! Enter as many guesses as you want until the other player is unjinxed!
	 * 4: You unjinxed the other player!
	 * */

	private bool showing = false;

	float showPopupZ = -2f;
	float hidePopupZ = 20f;
	int nextPopupIndex = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowPopup(int texIndex, bool autoHide) {

		if (showing) {
			Debug.Log ("Showing another popup, new popup queued");
			if (nextPopupIndex == -1) {	// We can only handle one popup queue
				nextPopupIndex = texIndex;
			}
		}
		else {
			gameObject.renderer.material.mainTexture = popupTextures[texIndex];
			gameObject.transform.position = new Vector3(0f, 0f, showPopupZ);
			showing = true;
		}
	}

	public void HidePopup() {
		if (nextPopupIndex == -1) {
			gameObject.transform.position = new Vector3(0f, 0f, hidePopupZ);
			showing = false;
		}
		else {
			gameObject.renderer.material.mainTexture = popupTextures[nextPopupIndex];
			nextPopupIndex = -1;
		}
	}

	public bool IsPopupShowing() {
		return showing;
	}
}
