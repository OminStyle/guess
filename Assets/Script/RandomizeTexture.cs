using UnityEngine;
using System.Collections;

public class RandomizeTexture : MonoBehaviour {
	public Texture[] textures;
	public static string answer1, answer2, answer3;

	// Enter these into inspector
	public string[] answers1;
	public string[] answers2;
	public string[] answers3;


	// Use this for initialization
	void Start () {
		int randInt = Random.Range(1, textures.Length);
		renderer.material.mainTexture = textures[randInt];
		answer1 = answers1[randInt];
		answer2 = answers2[randInt];;
		answer3 = answers3[randInt];;
	}
}
