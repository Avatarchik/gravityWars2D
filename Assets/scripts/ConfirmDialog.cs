using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfirmDialog : MonoBehaviour {
	private CanvasGroup confirmPanel;
	string highScoreKey = "HighScore";

	private Text HighScoreData;

	// Use this for initialization
	void Start () {
		confirmPanel = GetComponent<CanvasGroup>();
		HighScoreData = GameObject.Find("HighScoreData_text").GetComponent<Text>();
		
	}

	public void Cancel(){
		confirmPanel.alpha = 0;
		confirmPanel.blocksRaycasts = false;
	}

	public void Confirm(){
		confirmPanel.alpha = 0;
		confirmPanel.blocksRaycasts = false;

		PlayerPrefs.SetInt(highScoreKey, 0);
		PlayerPrefs.Save();
		HighScoreData.text = "00000000";
	}

	public void showDialogue(){
		confirmPanel.alpha = 1;
		confirmPanel.blocksRaycasts = true;
	}
	
}
