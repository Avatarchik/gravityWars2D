using UnityEngine;
using System.Collections;

public class Execute : MonoBehaviour {

	private GameObject sceneManager;
	playerState playerStateScript;
	GameObject currentPlayer;


	void Start(){
		sceneManager = GameObject.FindWithTag("gameManager");
		playerStateScript = sceneManager.GetComponent<playerState>();
	}

	public void Fire()
	{
		currentPlayer = GameObject.FindWithTag(playerStateScript.activePlayer);
		drawLine drawLineScript = currentPlayer.GetComponent<drawLine>();
		drawLineScript.FireTorpedo();
	}
}
