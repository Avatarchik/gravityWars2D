using UnityEngine;
using UnityEngine.Events;
using System.Collections;

	public enum gameState{playState, waitState};


public class GameState : MonoBehaviour {

	public gameState _gameState;

    private UnityAction someListener;

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

    public void SetStatePlay ()
    {
        _gameState = gameState.playState;
        EventManager.TriggerEvent("playState");
    }

    public void SetStateWait (){
    	_gameState = gameState.waitState;
    	EventManager.TriggerEvent("waitState");
    }

    void playState()
    {
    	Debug.Log("setting play state");
    }
    
    void WaitState ()
    {
        Debug.Log ("Setting wait state");
    }
    
    void SomeThirdFunction ()
    {
        Debug.Log ("Some Third Function was called!");
    }
    void Test()
    {
    	Debug.Log("testMessage");
    }

    void Start(){
    	_gameState = gameState.waitState;
    }
}
