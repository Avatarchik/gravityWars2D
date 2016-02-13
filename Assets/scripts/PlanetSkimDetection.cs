using UnityEngine;
using System.Collections;

public class PlanetSkimDetection : MonoBehaviour {

	private ChangeMessage _changeMessage;
	private Score _score;

	void OnTriggerExit2D(Collider2D collision){
		_changeMessage.ChangeText("planetSkimmer");
		_score.UpdateScore(10);
	}

	void Start(){
		_changeMessage = GameObject.Find("message_text").GetComponent<ChangeMessage>();
		_score = GameObject.FindWithTag("gameManager").GetComponent<Score>();
	}
}
