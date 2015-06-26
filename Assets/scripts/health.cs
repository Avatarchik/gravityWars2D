using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {

	
	public int healthAmount = 3;
	createPlanets2 createChildren;

	public void damage()
	{
		healthAmount -= 1;
		if (healthAmount == 0)
		{
			createChildren.planetCreate(transform.position, transform.localScale.x, 3);
			Destroy(gameObject);

		}
		else if (healthAmount <= -1)
		{
			healthAmount = -1;
		}
	}

	void Start()
	{
		if (healthAmount <= 5)
		{
			healthAmount = -1;
		}
		createChildren = gameObject.GetComponent<createPlanets2>();
	}
	
}


