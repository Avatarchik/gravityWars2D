using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeText : MonoBehaviour {
	private Text canvasText;
	private CanvasGroup canvasGroup;


 	public void messageState(string tag)
 	{
 		if (tag == "Player")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 2 wins";
 			canvasGroup.alpha = 1;
 		}
 		else if (tag == "Player2")
 		{
 			playerState.instance.DisablePlayers();		//Singleton!!!
			canvasText.text = "Player 1 wins";
 			canvasGroup.alpha = 1;


 		}
 		else if (tag == "border")
 		{
 			Debug.Log("Torpedo has left the system");
 		}
 		else if (tag == "Planet")
 		{
 			
 		}
 	}
 	void Start()
 	{
 		canvasText = GetComponent<Text>();
 		canvasGroup = gameObject.GetComponentInParent<CanvasGroup>();
 	}

}
