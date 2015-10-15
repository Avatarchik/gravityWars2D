using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {

	
	public int healthAmount = 3;
	createPlanets2 createChildren;
	GameObject gameManager;
	int planetEnumerator;
	float randomScale;
	float randFloatX;
	float randFloatY;

	Vector3 randomPositionVector;
	int numberOfPlanets;


	public void damage()
	{
		healthAmount -= 1;
		if (healthAmount == 0)
		{
			Destroy(gameObject);
			createChildPlanets();			
		}
		else if (healthAmount <= -1)
		{
			healthAmount = -1;
		}
	}

	void Start()
	{
		gameManager = GameObject.FindWithTag("gameManager");


		if (healthAmount <= 5)
		{
			healthAmount = -1;
		}
		
		createChildren = gameManager.GetComponent<createPlanets2>();
	}

	void createChildPlanets()
	{
		numberOfPlanets = Random.Range(1,4);

		for(int i = 0; i < numberOfPlanets; i++)
		{
			randomScale = Random.Range(.5f, transform.localScale.x/3);	

			randFloatX = Random.Range(.5f, transform.localScale.x/2);
			randFloatY = Random.Range(.5f, transform.localScale.x/2);	
			randomPositionVector = new Vector3(randFloatX, randFloatY, 0);	

			createChildren.planetCreate(transform.position + randomPositionVector, randomScale, 
			gameObject.GetComponent<planetMeta>().Iterator+10+i);
		}
	}
	
}
