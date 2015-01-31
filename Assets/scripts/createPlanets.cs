using UnityEngine;
using System.Collections;

public class createPlanets : MonoBehaviour {

	[Range(2, 10)]
	public int numberOfPlanets = 5;

	//scale range for planets
	public float planetLowBounds = 0.25f;
	public float planetHighBounds = 3.0f;

	public GameObject planetGroup;
	public GameObject playerGroup;
	public GameObject gameManager;

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


	//enableScript for ship
	private enableScript whichPlayer;

	GameObject actionCenter;					
	gameCenter gameCenterScript;

	public float seconds = 1.5f;

	private float totalMass = 0f;


	/// <summary>
	/// creates planets
	/// </summary>
	/// <param name="worldPos">World position.</param>
	/// <param name="randomScale">Random scale.</param>
	void planetCreate(Vector2 worldPos, float randomScale)
	{
		//instantiate a planet
		planet = Instantiate(planet, worldPos, Quaternion.identity) as GameObject;
		planet.name = "planet";
		
		//Apply scale
		planet.transform.localScale = Vector3.one * randomScale;
		planet.transform.parent = planetGroup.transform;
		planetGroup.transform.parent = gameManager.transform;

	}

	/// <summary>
	/// outputs a position in screenspace, and a scale factor
	/// </summary>
	/// <param name="worldPos">World position.</param>
	/// <param name="randomScale">Random scale.</param>
	void placeData (Vector2 range, out Vector2 worldPos, out float randomScale)
	{
		worldPos = Camera.main.ScreenToWorldPoint(range);						//convert screenSpace to worldSpace
		randomScale = Random.Range(planetLowBounds, planetHighBounds);			//random Scale of planet
	}


	/// <summary>
	/// Creates the ship.
	/// </summary>
	/// <param name="worldPos">World position.</param>
	/// <param name="playerOrder">sets the player number.</param>
	void createShip (Vector2 worldPos,   
					int playerOrder)
	{
		if (playerOrder == 1)
		{
			//set Orientation
			shipRotate = Quaternion.identity;
			shipName = "Ship A";
			playerTag = "Player";
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
		//ship.collider2D.enabled = engagedState;								//set the input status on the ship
		ship.name = shipName;
		ship.tag = playerTag;											
		ship.transform.parent = playerGroup.transform;
		subShip = ship.transform.GetChild(0).gameObject;	
		subShip.tag = playerTag;
		playerGroup.transform.parent = gameManager.transform;				//parent to playerGroup


		//activates or deactivates child's torpedo script based on engagedState flag
		myScript = ship.GetComponentInChildren<torpedo>();
		rotateScript = ship.GetComponentInChildren<rotate>();
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


	// Use this for initialization
	void Start () {

		planetGroup = new GameObject("planetGroup");
		playerGroup = new GameObject("playerGroup");
		gameManager = GameObject.FindWithTag("gameManager");

		actionCenter = GameObject.Find("actionCenter");
		gameCenterScript = actionCenter.GetComponent<gameCenter>();


		for(int i = 0; i < numberOfPlanets; i++)
		{
			//random placement of planet
			position = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));
			placeData(position, out worldPos, out randomScale);

			//place the other planets, use collision detection so no planets overlap.
			while (Physics2D.OverlapCircle(worldPos, randomScale)){
				position = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));
				placeData (position, out worldPos, out randomScale);
			}
			planetCreate(worldPos, randomScale);
			totalMass += mathTools.Remap(randomScale, .25f, 3f, 0, 10f);


		}
		//Debug.Log(totalMass);

		shipPosition("left");
		worldPos = Camera.main.ScreenToWorldPoint(position);


		while (Physics2D.OverlapCircle(worldPos, 1)){
			shipPosition("left");
			placeData(position, out worldPos, out randomScale);
		}

		createShip(worldPos, 1);					//Player 1 ship

		StartCoroutine(Wait(seconds));

		shipPosition("right");
		placeData(position, out worldPos, out randomScale);
		
		while (Physics2D.OverlapCircle(worldPos, 1)){
			shipPosition("right");
			placeData(position, out worldPos, out randomScale);
		}

		createShip(worldPos, 2);					//Player 2 ship

		

	}

	IEnumerator Wait(float seconds){
		startShip = ship;
		yield return new WaitForSeconds (seconds);
		gameCenterScript.updateCenterOfInterest(startShip);
		startShip.collider2D.enabled = true;

	}
}
