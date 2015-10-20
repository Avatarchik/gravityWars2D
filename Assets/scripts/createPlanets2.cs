using UnityEngine;
using System.Collections;

public class createPlanets2 : MonoBehaviour {

	Vector2 worldPos;

	public int lowRange = 1;
	public int highRange = 3;
	public int numberOfPieces;


	public GameObject planet;
	public GameObject planetGroup;
	public GameObject gameManager;

	public void planetCreate(Vector2 worldPos, float randomScale, int planetEnumerator)
	{
		//instantiate a planet
		planet = Instantiate(planet, worldPos, Quaternion.identity) as GameObject;
		planet.name = "planet_" + planetEnumerator.ToString();

		planet.GetComponent<health>().healthAmount = (int)(randomScale * 5);
		planet.GetComponent<planetMeta>().Iterator = planetEnumerator;
		planet.GetComponent<ForceField2D>().generalMultiplier = randomScale;

		//Apply scale
		
		planet.transform.localScale = Vector3.one * randomScale;
		planet.transform.parent = planetGroup.transform;
		planetGroup.transform.parent = gameManager.transform;	
	}
		
	void Awake () {

		planetGroup = new GameObject("planetGroup");
		gameManager = GameObject.FindWithTag("gameManager");
	}

}


