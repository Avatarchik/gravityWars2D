using UnityEngine;
using System.Collections;

public class targetMemoryLifespan : MonoBehaviour {
	playerState activePlayerScript;
	int order = 0;

	GameObject sceneManager;

	public void incrementIndex(Vector3 position)
	{
		sceneManager = GameObject.FindWithTag("gameManager");
		activePlayerScript = sceneManager.GetComponent<playerState>();

		if (activePlayerScript.activePlayer == gameObject.tag)
		{
			switch (order)
			{	
				case 0:
					gameObject.GetComponent<CanvasGroup>().alpha = .5f;
					transform.position = position;
					break;
				case 1:
					gameObject.GetComponent<CanvasGroup>().alpha = .25f;
					break;
				case 2:
					gameObject.GetComponent<CanvasGroup>().alpha = .125f;
					order = -1;
					break;
			}	
			order++;
		}
	}
}