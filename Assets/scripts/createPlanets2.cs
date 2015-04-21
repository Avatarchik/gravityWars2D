using UnityEngine;
using System.Collections;

public class createPlanets2 : MonoBehaviour {

	Vector2 worldPos;
	public float planetScale;

	public int lowRange = 1;
	public int highRange = 3;
	public int numberOfPieces;

	public GameObject planet;
	public GameObject planetGroup;
	public GameObject gameManager;


	//void planetCreate(Vector2 worldPos, float planetScale)
	public void planetCreate()
	{
		for (int i = 0; i < numberOfPieces; i++)
		{

			/*
			//place the other planets, use collision detection so no planets overlap.
			while (Physics2D.OverlapCircle(worldPos, planetScale)){
				position = new Vector2((worldPos + Random.Range(0.0f, planetScale), (worldPos + Random.Range(0.0f, planetScale)));
				//placeData (position, out worldPos, out planetScale);
			}
			*/
			//instantiate a planet
			planet = Instantiate(planet, worldPos, Quaternion.identity) as GameObject;
			planet.name = "planet_";
			//planet.name = "planet_" + planetEnumerator.ToString();

			planet.GetComponent<health>().healthAmount = (int)(planetScale * 5);

			//Apply scale
			
			planet.transform.localScale = Vector3.one * planetScale;
			planet.transform.parent = planetGroup.transform;
			planetGroup.transform.parent = gameManager.transform;
		}
		


	}

	// Use this for initialization
	void Start () {
		numberOfPieces = Random.Range(lowRange, highRange);	
		worldPos = transform.position;
		planetScale = transform.localScale.x/(numberOfPieces+1);

		gameManager = GameObject.FindWithTag("gameManager");
		planetGroup = GameObject.Find("planetGroup");
	}
}
