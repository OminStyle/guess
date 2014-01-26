using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {

	public Texture btnTexture;
	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}

		// button using a texture
		//if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
		//	Debug.Log("Clicked the button with an image");
		
		if (GUI.Button(new Rect(540, 650, 50, 30), "Submit")) {
			Debug.Log("Clicked the button with text");

		}
	}
}
