using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlanetSkimDetection : MonoBehaviour {
	private GameObject sceneManager;

	private ChangeMessage _changeMessage;
	private Score _score;

	public bool initializeCollider = false;
	public float waitTime = .25F;

	public enum colliderType{planet, ship};
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
	}

	void Start(){
		sceneManager = GameObject.FindWithTag("gameManager");
		_score = sceneManager.GetComponent<Score>();
		_changeMessage = GameObject.Find("message_text").GetComponent<ChangeMessage>();
	}




	void Awake ()
    {
        someListener = new UnityAction (playState);
    }

    void OnEnable ()
    {
        EventManager.StartListening ("playState", someListener);
        EventManager.StartListening ("waitState", WaitState);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("playState", someListener);
        EventManager.StopListening ("waitState", WaitState);
    }

    void playState()
    {
    	Debug.Log("playing");
    }
    
    void WaitState ()
    {
        initializeCollider = false;
    }
}

