using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlanetSkimDetection : MonoBehaviour {
	public bool initializeCollider = false;
	public float waitTime = .25F;

	public enum colliderType{planet, ship, goal};
	public colliderType _colliderType;

	//External Connections
	private GameObject sceneManager;

	private FloatingScores _floatingScores;

	private ChangeMessage _changeMessage;
	private Score _score;

	//Messenger
	private UnityAction someListener;

	void OnTriggerExit2D(Collider2D collision){
		if(_colliderType == colliderType.planet){
			_floatingScores.UpdateLocation(gameObject,10);
			_changeMessage.ChangeText("planetSkimmer");
			_score.UpdateScore(10);
		}
		else if(_colliderType == colliderType.ship){
			if (initializeCollider == false){
				initializeCollider = true;
			}
			else{
				_floatingScores.UpdateLocation(gameObject,30);
				_changeMessage.ChangeText("Close Call!");
				_score.UpdateScore(30);
			}
		}
		else if(_colliderType == colliderType.goal){
			_floatingScores.UpdateLocation(gameObject,30);
			_changeMessage.ChangeText("So Close!");
			_score.UpdateScore(30);
		}	
	}

	void Start(){
		sceneManager = GameObject.FindWithTag("gameManager");
		_score = sceneManager.GetComponent<Score>();
		_changeMessage = GameObject.Find("message_text").GetComponent<ChangeMessage>();
		_floatingScores = GameObject.Find("floatingScore_text").GetComponent<FloatingScores>();

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

