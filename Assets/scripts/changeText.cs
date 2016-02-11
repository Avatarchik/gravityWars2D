using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class changeText : MonoBehaviour {
	private Text canvasText;
	private CanvasGroup canvasGroup;
	private Score _score;


 	public void messageState(string tag)
 	{
 		if (tag == "Player1")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 2 wins";
 			canvasGroup.alpha = 1;
 			canvasGroup.blocksRaycasts = true;
 			_score.scoreNumber += 100;
 			_score.UpdateScore();

 		}
 		else if (tag == "Player2")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 1 wins";
 			canvasGroup.alpha = 1;
 			canvasGroup.blocksRaycasts = true;
 			_score.scoreNumber += 100;
 			_score.UpdateScore();


 		}
 		else if (tag == "border")
 		{
 			Debug.Log("Torpedo has left the system");
 		}
 		else if (tag == "Planet")
 		{
 			_score.scoreNumber += 1;
 			_score.UpdateScore();
 		}
 	}
 	void Start()
 	{
 		canvasText = GetComponent<Text>();
 		canvasGroup = gameObject.GetComponentInParent<CanvasGroup>();
 		_score = GameObject.FindWithTag("gameManager").GetComponent<Score>();
 	}

}
