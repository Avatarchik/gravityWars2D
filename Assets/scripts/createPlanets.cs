using UnityEngine;
using System.Collections;

public class createPlanets : MonoBehaviour {

	GameType _gameType;

	[Range(2, 10)]
	public int numberOfPlanets = 5;

	//scale range for planets
	public float planetLowBounds = 0.25f;
	public float planetHighBounds = 3.0f;
	//private int planetHealth;

	public GameObject planetGroup;
	public GameObject playerGroup;
	public GameObject gameManager;
	public GameObject golfGoal;

	//object to instantiate
	public GameObject planet;
	public GameObject ship;
	private GameObject subShip;						//the gameObject hierarchy underneath the ship
	private GameObject startShip;

	//placeData
	float borderHeight;
	Vector2 position;
	Vector2 worldPos;
	float randomScale;
	int planetEnumerator;

	//createShip
	Quaternion shipRotate;
	string shipName;
	string playerTag;
	bool engagedState;
	public float turnSpeedSet;

	[Range(4, 48)]
	public int borderMargin = 12;

	//torpedo script for ship
	private torpedo myScript;
	rotate rotateScript;
 	CircleCollider2D circleCollider2D;

	//enableScript for ship
	private enableScript whichPlayer;

	GameObject actionCenter;					
	gameCenter gameCenterScript;

	public float seconds = 1.5f;

	public float totalMass = 0f;

	createPlanets2 planetCreateScript;


	void placeData (Vector2 range, out Vector2 worldPos, out float randomScale)
	{
		worldPos = Camera.main.ScreenToWorldPoint(range);						//convert screenSpace to worldSpace
		randomScale = Random.Range(planetLowBounds, planetHighBounds);			//random Scale of planet
	}


	void createShip (Vector2 worldPos,   
					int playerOrder)
	{
		if (playerOrder == 1)
		{
			//set Orientation
			shipRotate = Quaternion.identity;
			shipName = "Ship A";
			playerTag = "Player1";
			engagedState = true;
			turnSpeedSet = -50f;

		}
		else if (playerOrder == 2)
		{
			//set Orientation
			shipRotate = Quaternion.identity * Quaternion.Euler(0, 180, 0);
			shipName = "Ship B";
			playerTag = "Player2";
			engagedState = false;
			turnSpeedSet = 50f;

		}
		ship = Instantiate(ship, worldPos, shipRotate) as GameObject;
		ship.name = shipName;
		ship.tag = playerTag;											
		ship.transform.parent = playerGroup.transform;
		subShip = ship.transform.GetChild(0).gameObject;	
		subShip.tag = playerTag;
		playerGroup.transform.parent = gameManager.transform;				//parent to playerGroup


		//activates or deactivates child's torpedo script based on engagedState flag
		myScript = ship.GetComponentInChildren<torpedo>();
		rotateScript = ship.GetComponentInChildren<rotate>();
		circleCollider2D = ship.GetComponentInChildren<CircleCollider2D>();
		circleCollider2D.enabled = engagedState;
		rotateScript.enabled = engagedState;

		//sets the rotate orientation
		rotateScript.turnSpeed = turnSpeedSet;

		myScript.enabled = engagedState;


		//sets the playerIdentifier variable on the enableScript script
		whichPlayer = ship.GetComponentInChildren<enableScript>();
		whichPlayer.playerIdentifier = playerOrder;

		//checks the player ship into the sceneManager

		if (playerOrder == 1)
		{
			playerState.instance.playerObject = ship;		//Singleton!!
		}
		else if (playerOrder == 2)
		{
			playerState.instance.playerObject2 = ship;		//Singleton!!
		}
	}

	void createGoal (Vector2 worldPos,   
					int playerOrder)
	{
		//set Orientation
		shipRotate = Quaternion.identity * Quaternion.Euler(0, 180, 0);
		shipName = "Ship B";
		playerTag = "Player2";
		engagedState = false;
		turnSpeedSet = 50f;

		ship = Instantiate(golfGoal, worldPos, shipRotate) as GameObject;
		ship.name = shipName;
		ship.tag = playerTag;											
		ship.transform.parent = playerGroup.transform;
		subShip = ship.transform.GetChild(0).gameObject;	
		subShip.tag = playerTag;
		playerGroup.transform.parent = gameManager.transform;				//parent to playerGroup


		//activates or deactivates child's torpedo script based on engagedState flag
		rotateScript = ship.GetComponentInChildren<rotate>();
		//circleCollider2D = ship.GetComponentInChildren<CircleCollider2D>();
		//circleCollider2D.enabled = engagedState;
		rotateScript.enabled = engagedState;

		//sets the rotate orientation
		rotateScript.turnSpeed = turnSpeedSet;


		//sets the playerIdentifier variable on the enableScript script
		whichPlayer = ship.GetComponentInChildren<enableScript>();
		whichPlayer.playerIdentifier = playerOrder;

		//checks the player ship into the sceneManager

		if (playerOrder == 1)
		{
			playerState.instance.playerObject = ship;		//Singleton!!
		}
		else if (playerOrder == 2)
		{
			playerState.instance.playerObject2 = ship;		//Singleton!!
		}
	}


	//gives us the ship position accounting for our screen's borders
	//Inputs: side of screen the ship will be on.
	//Returns: the position of the ship.
	Vector2 shipPosition(string side)
	{
		borderHeight = Screen.height/borderMargin;

		if (side == "left")
		{
			position = new Vector2((Screen.width/borderMargin), 
				Random.Range(borderHeight, 
				(((borderMargin*Screen.height)/borderMargin)-borderHeight)));
		}
		if (side == "right")
		{
			position = new Vector2(((borderMargin-1)*Screen.width/borderMargin), Random.Range((Screen.height/(borderMargin)), (((borderMargin-1)*Screen.height)/borderMargin)));

		}
		return position;
	}

	void Start() {
		_gameType = GameObject.Find("persistentData").GetComponent<GameType>();

		playerGroup = new GameObject("playerGroup");
		gameManager = GameObject.FindWithTag("gameManager");

		actionCenter = GameObject.Find("actionCenter");
		gameCenterScript = actionCenter.GetComponent<gameCenter>();

		planetCreateScript = gameObject.GetComponent<createPlanets2>();

		for(int i = 0; i < numberOfPlanets; i++){
			//random placement of planet
			position = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));
			placeData(position, out worldPos, out randomScale);

			//place the other planets, use collision detection so no planets overlap.
			while (Physics2D.OverlapCircle(worldPos, randomScale)){
				position = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));
				placeData (position, out worldPos, out randomScale);
			}
			
			planetCreateScript.planetCreate(worldPos, randomScale, i+1);
			totalMass += mathTools.Remap(randomScale, .25f, 3f, 0, 10f);
		}

		//Place player ship
		shipPosition("left");
		worldPos = Camera.main.ScreenToWorldPoint(position);


		while (Physics2D.OverlapCircle(worldPos, 1)){
			shipPosition("left");
			placeData(position, out worldPos, out randomScale);
		}

		createShip(worldPos, 1);					//Player 1 ship

		StartCoroutine(Wait(seconds));

		//Place the opponent
		shipPosition("right");
		placeData(position, out worldPos, out randomScale);
		
		while (Physics2D.OverlapCircle(worldPos, 1)){
			shipPosition("right");
			placeData(position, out worldPos, out randomScale);
		}


		if (_gameType.type == GameType.GameSelection.golf)
			SoloPlay(); 
		else if(_gameType.type == GameType.GameSelection.vsAI)
			VsAI();
		else if(_gameType.type == GameType.GameSelection.vsPlayer)
			VsPlayer();
	}


	// Use this for initialization
	void VsPlayer () {
		createShip(worldPos, 2);					//Player 2 ship
	
	}

	void SoloPlay () {
		createGoal(worldPos, 2);					//Player 2 ship
	
	}

	void VsAI () {
	
	}


	IEnumerator Wait(float seconds){
		startShip = ship;
		yield return new WaitForSeconds (seconds);
		gameCenterScript.updateCenterOfInterest(startShip);
		startShip.GetComponent<Collider2D>().enabled = true;

	}
}
