using UnityEngine;
using System.Collections;

public class targetMemoryLifespan : MonoBehaviour {
	private float alpha = 1f;
	playerState activePlayerScript;
	
	public string activePlayer;

	GameObject sceneManager;

	void Start()
	{
		sceneManager = GameObject.FindWithTag("gameManager");
		activePlayer = sceneManager.GetComponent<playerState>().activePlayer;
	}


	public void incrementIndex(Vector3 position)
	{
		activePlayerScript = sceneManager.GetComponent<playerState>();
		activePlayer = activePlayerScript.activePlayer;

		if (activePlayer == gameObject.tag)
			{
				alpha *= .5f;
				gameObject.GetComponent<CanvasGroup>().alpha = alpha;

				if (alpha < .1f)
					alpha = 1f;

				if (alpha >= .5f)
					transform.position = position;
			}	
	}
}