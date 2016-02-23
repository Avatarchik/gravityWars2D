using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PermanentScores : MonoBehaviour {

	private Text HighScoreText;
	string highScoreKey = "HighScore";
	private int highScore = 0;

	private Text averageScore_text;

	string numberOfTurnsKey = "NumberOfTurns";

	private int averageScore;
	public int numberOfGames;

	private Text numberOfGamesPlayed_text;
	private int numberOfGamesPlayed= 0;
	string numberOfGamesKey = "NumberOfGames";

	string totalScoreKey = "TotalScore";

	private Text shotsToGoalAverage_text;
	private int shotsToGoalAverage;

	// Use this for initialization
	void Start () {

		numberOfGamesPlayed_text = GameObject.Find("NumberOfGames_Data_text").GetComponent<Text>();
		numberOfGamesPlayed = PlayerPrefs.GetInt(numberOfGamesKey);
		numberOfGamesPlayed_text.text = numberOfGamesPlayed.ToString();

		HighScoreText = GameObject.Find("HighScoreData_text").GetComponent<Text>();
		highScore = PlayerPrefs.GetInt(highScoreKey);
		HighScoreText.text = highScore.ToString();

		averageScore_text = GameObject.Find("AverageScore_Data_text").GetComponent<Text>();
		if (numberOfGamesPlayed == 0){
			numberOfGamesPlayed = 1;
		}
		averageScore =(int) (PlayerPrefs.GetInt(totalScoreKey) / numberOfGamesPlayed);
		averageScore_text.text = averageScore.ToString();

		shotsToGoalAverage_text = GameObject.Find("ShotsToGoalAverage_Data_text").GetComponent<Text>();
		shotsToGoalAverage = (int)(PlayerPrefs.GetInt(numberOfTurnsKey) / numberOfGamesPlayed);
		shotsToGoalAverage_text.text = shotsToGoalAverage.ToString();

	}

}
