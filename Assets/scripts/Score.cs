using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int scoreNumber = 0;
	public int scoreIncrease = 0;
	public Text _text;
	public float duration = 0.5f;
	public int target = 0;
	public int scoreCounter = 0;

	private int numberOfTurns;
	string highScoreKey = "HighScore";
	public int highScore = 0;

	void Start()
		{
			_text = GameObject.Find("scoreNumber_text").GetComponent<Text>();
			_text.text = "0";

			numberOfTurns = gameObject.GetComponent<playerState>().player1Stats;

			highScore = PlayerPrefs.GetInt(highScoreKey);		
		}
	
	public void UpdateScore(int scoreIncrease){
		scoreNumber += scoreIncrease;
		StartCoroutine("IncrementScore", scoreNumber);

	}
	

	IEnumerator IncrementScore(int scoreNumber){
		int start = scoreCounter;
		for (float timer = 0; timer < duration; timer += Time.deltaTime){
			float progress = timer / duration;
			scoreCounter = 1+((int)Mathf.Lerp (start, scoreNumber, progress));
			_text.text = scoreCounter.ToString();
			yield return null;
		}

	}

	public void EndScore(){
		numberOfTurns = (gameObject.GetComponent<playerState>().player1Stats);
		scoreNumber += (int)(18000*(Mathf.Pow(2, -numberOfTurns))) + 150;
		StartCoroutine("IncrementScore", scoreNumber);

		if(scoreNumber > highScore){
			PlayerPrefs.SetInt(highScoreKey, scoreNumber);
			PlayerPrefs.Save();
		}

	}

}


