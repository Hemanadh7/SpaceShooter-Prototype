using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text Score;
	public static int playerPoints;

	void Start()
	{
		playerPoints = 0;
		Reset ();
	}
	public void PlayerScore(int points)
	{
		//keeps track of player score.
		playerPoints += points;
		Score.text = playerPoints.ToString ();
	}

	public void Reset()
	{
		//Resets score to 0 when player destroyed.
		playerPoints = 0;
		Score.text = playerPoints.ToString ();
	}
}
