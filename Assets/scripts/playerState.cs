/*Author: Ian Mankowski
 * Title: playerState
 * 
 * Usage:
 *place on sceneManager to change players
 *
 *About: This script manages which player is current
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerState : MonoBehaviour {

	public enum gameState{playState, waitState};
	public gameState _gameState;

	public bool player1 = true;
	public bool player2 = false;

	public string activePlayer = "Player1";

	public int player1Stats = 1;
	public int player2Stats = 1;

	public GameObject playerObject;
	public GameObject playerObject2;

	public enableScript player1Switch;
	public enableScript player2Switch;

	GameObject shipA;
	GameObject shipB;

	GameObject actionCenter;					
	gameCenter gameCenterScript;
	resetCamera resetCameraScript;

	GameObject targetingPanel_A;
	CanvasGroup targetingPanel_A_CanvasGroup;

	GameObject targetingPanel_B;
	CanvasGroup targetingPanel_B_CanvasGroup;

	public Color player1Color;
	public Color player2Color;

	private Text turnsText;


	//This bit here turns this into a singleton
	private static playerState _instance;

	public static playerState instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<playerState>();
			return _instance;
		}
	}

	//End singleton

	public void playerSwitch()
	{
		shipA = GameObject.FindWithTag("Player1");
		shipB = GameObject.FindWithTag("Player2");
		
		//need to activate the torpedo gravity fields again.
		shipA.GetComponentInChildren<ForceField2D>().enabled = true;

		if(shipB.GetComponentInChildren<ForceField2D>() != null){
			shipB.GetComponentInChildren<ForceField2D>().enabled = true;
			
			player1 = !player1;
			player2 = !player2;	
		}
		

		

		resetCameraScript.smoothResetCamera();

		targetingPanel_A_CanvasGroup.alpha = 0;
		targetingPanel_B_CanvasGroup.alpha = 0;
		
		///Simply keeps track of how many turns have taken place///
		if (player1 == true)
		{
			player1Stats += 1;
			playerObject.GetComponent<Collider2D>().enabled = true;				//enable user input for opposite player
			gameCenterScript.updateCenterOfInterest(shipA);
			targetingPanel_A_CanvasGroup.alpha = 1;
			activePlayer = "Player1";
		}
		else if (player2 == true)
		{
			player2Stats += 1;
			playerObject2.GetComponent<Collider2D>().enabled = true;			//enable user input for opposite player
			gameCenterScript.updateCenterOfInterest(shipB);
			targetingPanel_B_CanvasGroup.alpha = 1;
			activePlayer = "Player2";

		}

		
		player1Switch = playerObject.GetComponentInChildren<enableScript>();
		player2Switch = playerObject2.GetComponentInChildren<enableScript>();

		player1Switch.playerSwitch(player1);
		player2Switch.playerSwitch(player2);

		turnsText.text = player1Stats.ToString();

		//playerState.instance.playerSwitch();		//Singleton!!!
	}
	
	public void DisablePlayers()
	{
		player1 = false;
		player2 = false;

		player1Switch.playerSwitch(player1);
		player2Switch.playerSwitch(player2);
	}

	public void DisableInput()
	{
		gameCenterScript.resetCenterOfInterest();

		playerObject.GetComponent<Collider2D>().enabled = false;
		playerObject2.GetComponent<Collider2D>().enabled = false;
	}

	public void Start()
	{
		targetingPanel_A = GameObject.Find("targetingText_A_panel");
		targetingPanel_A_CanvasGroup = targetingPanel_A.GetComponent<CanvasGroup>();


		targetingPanel_B = GameObject.Find("targetingText_B_panel");
		targetingPanel_B_CanvasGroup = targetingPanel_B.GetComponent<CanvasGroup>();

		actionCenter = GameObject.Find("actionCenter");
		gameCenterScript = actionCenter.GetComponent<gameCenter>();
		resetCameraScript = Camera.main.GetComponent<resetCamera>();

		_gameState = gameState.waitState;

		turnsText = GameObject.Find("turnNumber_text").GetComponent<Text>();
	}

	public void PlayState(){
		_gameState = gameState.playState;
		//gameObject.BroadcastMessage()
	}
}

