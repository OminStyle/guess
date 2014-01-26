using UnityEngine;
using System.Collections;

public class RandomizeTexture : MonoBehaviour {
	public Texture[] textures;
	public static string answer;
		
	// Use this for initialization
	void Start () {
		int randInt = Random.Range(1, textures.Length);
		renderer.material.mainTexture = textures[randInt];
		answer = textures[randInt].name;
	}
}
