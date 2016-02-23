using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfirmDialog : MonoBehaviour {
	private CanvasGroup confirmPanel;
	string highScoreKey = "HighScore";
	string numberOfTurnsKey = "NumberOfTurns";
	string numberOfGamesKey = "NumberOfGames";
	string totalScoreKey = "TotalScore";

	private Text HighScoreData;
	private Text AverageScoreData;
	private Text ShotsToGoalAverage;
	private Text NumberOfGames;

	private string zeros = "00000000";

	// Use this for initialization
	void Start () {
		confirmPanel = GetComponent<CanvasGroup>();

		HighScoreData = GameObject.Find("HighScoreData_text").GetComponent<Text>();
		AverageScoreData = GameObject.Find("AverageScore_Data_text").GetComponent<Text>();
		ShotsToGoalAverage = GameObject.Find("ShotsToGoalAverage_Data_text").GetComponent<Text>();
		NumberOfGames = GameObject.Find("NumberOfGames_Data_text").GetComponent<Text>();

		
	}

	public void Cancel(){
		confirmPanel.alpha = 0;
		confirmPanel.blocksRaycasts = false;
	}

	public void Confirm(){
		confirmPanel.alpha = 0;
		confirmPanel.blocksRaycasts = false;

		PlayerPrefs.SetInt(highScoreKey, 0);
		PlayerPrefs.SetInt(numberOfTurnsKey, 0);
		PlayerPrefs.SetInt(numberOfGamesKey, 0);
		PlayerPrefs.SetInt(totalScoreKey, 0);

		PlayerPrefs.Save();

		HighScoreData.text = zeros;
		AverageScoreData.text = zeros;
		ShotsToGoalAverage.text = zeros;
		NumberOfGames.text = zeros;
	}

	public void showDialogue(){
		confirmPanel.alpha = 1;
		confirmPanel.blocksRaycasts = true;
	}
	
}
