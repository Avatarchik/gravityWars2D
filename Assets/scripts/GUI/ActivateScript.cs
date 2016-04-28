using UnityEngine;
using System.Collections;

public class ActivateScript : MonoBehaviour {

	public GameObject sceneManager;

	private drawLine _drawLine;
	private playerState _playerState;
	private GameObject activePlayer;

	public bool repeatableButton = true;

	// Use this for initialization
	void Start () {
		_playerState = sceneManager.GetComponent<playerState>();
	}

	public void ExecuteFunction(){
		activePlayer = GameObject.FindWithTag(_playerState.activePlayer);
		_drawLine = activePlayer.GetComponent<drawLine>();
		_drawLine.DecreaseLine();
	}
}
