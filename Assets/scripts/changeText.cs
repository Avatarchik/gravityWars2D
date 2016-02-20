using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class changeText : MonoBehaviour {
	private Text canvasText;
	private CanvasGroup canvasGroup;
	private Score _score;
	private ChangeMessage _changeMessage;


 	public void messageState(string tag)
 	{
 		if (tag == "Player1")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 2 wins";
 			canvasGroup.alpha = 1;
 			canvasGroup.blocksRaycasts = true;
 			_score.EndScore();

 		}
 		else if (tag == "Player2")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 1 wins";
 			canvasGroup.alpha = 1;
 			canvasGroup.blocksRaycasts = true;
 			_score.EndScore();


 		}
 		else if (tag == "border")
 		{
 			_changeMessage.ChangeText("Projectile lost");
 			Debug.Log("torpedo has left the system");
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
 		canvasText = GetComponent<Text>();
 		canvasGroup = gameObject.GetComponentInParent<CanvasGroup>();
 		_score = GameObject.FindWithTag("gameManager").GetComponent<Score>();
 		_changeMessage = GameObject.Find("message_text").GetComponent<ChangeMessage>();
 	}

}
