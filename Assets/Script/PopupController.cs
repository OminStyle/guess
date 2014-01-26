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

	Vector3 showPopupV = new Vector3(0.5f, 0.47f, 20f);
	Vector3 hidePopupV = new Vector3(10f, 10f, 20f);
	float showPopupZ = -2f;
	float hidePopupZ = 20f;
	int nextPopupIndex = -1;

	// Use this for initialization
	void Start () {
		HidePopup ();
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
			gameObject.guiTexture.texture = popupTextures[texIndex];
			gameObject.transform.position = showPopupV;
			showing = true;
		}
	}

	public void HidePopup() {
		if (nextPopupIndex == -1) {
			gameObject.transform.position = hidePopupV;
			showing = false;
		}
		else {
			gameObject.guiTexture.texture = popupTextures[nextPopupIndex];
			nextPopupIndex = -1;
		}
	}

	public bool IsPopupShowing() {
		return showing;
	}
}
