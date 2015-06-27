using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {

	
	public int healthAmount = 3;
	createPlanets2 createChildren;
	GameObject gameManager;
	int planetEnumerator;
	float randomScale;
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
		numberOfPlanets = Random.Range(0,4);

		for(int i = 0; i < numberOfPlanets; i++)
		{
			randomScale = Random.Range(.5f, transform.localScale.x/3);			

			createChildren.planetCreate(transform.position, randomScale, 
				gameObject.GetComponent<planetMeta>().Iterator+10+i);
		}
	}
	
}
