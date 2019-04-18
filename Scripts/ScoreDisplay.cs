using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	private int Points;
	public Text highScore;
	public static int showHighscore;

	// Use this for initialization
	void Start () 
	{
		Points = ScoreScript.playerPoints;
		Text myText = GetComponent<Text>();
		myText.text = ScoreScript.playerPoints.ToString ();
		highScore.text = PlayerPrefs.GetInt ("HighScore",0).ToString();

		if(Points > PlayerPrefs.GetInt("HighScore",0))
		{
			PlayerPrefs.SetInt ("HighScore",Points);
			highScore.text = Points.ToString();
			showHighscore = Points;
		}
	}

	public void Reset()
	{
		PlayerPrefs.DeleteKey ("HighScore");
		highScore.text = "0";
	}


}
