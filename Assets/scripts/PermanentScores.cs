using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PermanentScores : MonoBehaviour {

	private Text HighScoreText;
	string highScoreKey = "HighScore";
	private int highScore = 0;

	// Use this for initialization
	void Start () {
		HighScoreText = GameObject.Find("HighScoreData_text").GetComponent<Text>();
		highScore = PlayerPrefs.GetInt(highScoreKey);
		HighScoreText.text = highScore.ToString();
	}
}
