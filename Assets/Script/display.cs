using UnityEngine;
using System.Collections;

public class display : MonoBehaviour {
	public string[] myGuesses;
	//private  string guess = "guess";
	private  string guess2 = "car";
	private  string guess3 = "flight";
	private  string guess4 = "train";
	private  string guess5 = "lol";
	
	
	void OnGUI()
	{
		myGuesses = new string[5];
		//myGuesses[0]=guess;
		myGuesses[0] = RandomizeTexture.answer;
		myGuesses[1]=guess2;
		myGuesses[2]=guess3;
		myGuesses[3]=guess4;
		myGuesses[4]=guess5;
		
		
		
		for(int i = 0; i < myGuesses.Length; i++) {
			string guesses = (string) myGuesses[i];
			GUI.Label(new Rect(600,100+20*i,Screen.width,Screen.height),guesses);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
