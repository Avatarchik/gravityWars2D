using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlanetSkimDetection : MonoBehaviour {
	private GameObject sceneManager;

	private ChangeMessage _changeMessage;
	private Score _score;

	public bool initializeCollider = false;
	public float waitTime = .25F;

	public enum colliderType{planet, ship, goal};
	public colliderType _colliderType;

	private UnityAction someListener;

	void OnTriggerExit2D(Collider2D collision){
		if(_colliderType == colliderType.planet){
			_changeMessage.ChangeText("planetSkimmer");
			_score.UpdateScore(10);
		}
		else if(_colliderType == colliderType.ship){
			if (initializeCollider == false){
				initializeCollider = true;
			}
			else{
				_changeMessage.ChangeText("Close Call!");
				_score.UpdateScore(30);
			}
		}
		else if(_colliderType == colliderType.goal){
			_changeMessage.ChangeText("This Close!");
			_score.UpdateScore(30);
		}	
	}

	void Start(){
		sceneManager = GameObject.FindWithTag("gameManager");
		_score = sceneManager.GetComponent<Score>();
		_changeMessage = GameObject.Find("message_text").GetComponent<ChangeMessage>();

	}



	//MESSAGING
	void Awake ()
    {
        someListener = new UnityAction (WaitState);
    }

    void OnEnable ()
    {
        EventManager.StartListening ("waitState", WaitState);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("waitState", WaitState);
    }

    void WaitState ()
    {
        initializeCollider = false;
    }
}

