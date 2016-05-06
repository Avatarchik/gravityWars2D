using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class changeText : MonoBehaviour {
	private Text canvasText;
	private CanvasGroup canvasGroup;
	private Score _score;
	private ChangeMessage _changeMessage;

	private GameType _gameType;
	public bool scores =false;


 	public void messageState(string tag)
 	{
 		if (tag == "Player1")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 2 wins";
 			canvasGroup.alpha = 1;
 			canvasGroup.blocksRaycasts = true;
 			if(scores == true){
 				_score.EndScore();
 			}
 			

 		}
 		else if (tag == "Player2")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 1 wins";
 			canvasGroup.alpha = 1;
 			canvasGroup.blocksRaycasts = true;
 			if(scores == true){
 				_score.EndScore();
 			}

 		}
 		else if (tag == "border")
 		{
 			_changeMessage.ChangeText("Projectile lost");
 		}
 		else if (tag == "Planet")
 		{
 			
 		}
 		else {
 			_changeMessage.ChangeText("Fuse Expired");
 		}
 	}
 	void Start()
 	{
		_gameType = GameObject.Find("persistentData").GetComponent<GameType>();

		if(_gameType.type == GameType.GameSelection.golf){
			scores = true;
		}

 		canvasText = GetComponent<Text>();
 		canvasGroup = gameObject.GetComponentInParent<CanvasGroup>();
 		_score = GameObject.FindWithTag("gameManager").GetComponent<Score>();
 		_changeMessage = GameObject.Find("message_text").GetComponent<ChangeMessage>();
 	}

}
