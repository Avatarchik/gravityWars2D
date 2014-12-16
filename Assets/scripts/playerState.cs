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

public class playerState : MonoBehaviour {


	public bool player1 = true;
	public bool player2 = false;

	public int player1Stats = 0;
	public int player2Stats = 0;

	public GameObject playerObject;
	public GameObject playerObject2;

	public enableScript player1Switch;
	public enableScript player2Switch;

	GameObject shipA;
	GameObject shipB;

	public float defaultCamera;			//get the initial state of the camera


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
		shipA = GameObject.FindWithTag("Player");
		shipB = GameObject.FindWithTag("Player2");

		if (Camera.main.orthographicSize != defaultCamera)
			Camera.main.orthographicSize = defaultCamera;

		//need to activate the torpedo gravity fields again.
		shipA.GetComponentInChildren<ForceField2D>().enabled = true;
		shipB.GetComponentInChildren<ForceField2D>().enabled = true;

		player1 = !player1;
		player2 = !player2;	

		///Simply keeps track of how many turns have taken place///
		if (player1 == true)
		{
			player1Stats += 1;
			playerObject.collider2D.enabled = true;				//enable user input for opposite player
		}
		else if (player2 == true)
		{
			player1Stats += 1;
			playerObject2.collider2D.enabled = true;			//enable user input for opposite player
		}

		
		player1Switch = playerObject.GetComponentInChildren<enableScript>();
		player2Switch = playerObject2.GetComponentInChildren<enableScript>();

		player1Switch.playerSwitch(player1);
		player2Switch.playerSwitch(player2);

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
		playerObject.collider2D.enabled = false;
		playerObject2.collider2D.enabled = false;
	}

	public void Start()
	{
		defaultCamera = Camera.main.orthographicSize;
	}
}

