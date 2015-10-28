using UnityEngine;
using System.Collections;

public class GetPlayerColor : MonoBehaviour {

	public Color playerColor;
	public GameObject gameManager;
	//public TrailRenderer trailRenderer;

	private playerState playerStateScript;

	private string activePlayer;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindWithTag("gameManager");
        playerStateScript = gameManager.GetComponent<playerState>();

        activePlayer = playerStateScript.activePlayer;

        if (activePlayer == "Player1"){
        	playerColor = playerStateScript.player1Color;
        }else{
        	playerColor = playerStateScript.player2Color;
        }
        //GetComponent<TrailRenderer>().material.SetColor("_TintColor", playerColor);
	}
}
	

