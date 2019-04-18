using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("HighScore read");
		text.text = ScoreDisplay.showHighscore.ToString ();
	}

	void Update()
	{

	}
}
