using UnityEngine;
using System.Collections;

public class targetMemoryLifespan : MonoBehaviour {
	private float alpha = 1f;
	public playerState activePlayerScript;
	
	public string currentPlayer;

	GameObject sceneManager;

	public void incrementIndex(Vector3 position)
	{
		sceneManager = GameObject.FindWithTag("gameManager");
		activePlayerScript = sceneManager.GetComponent<playerState>();

		if (activePlayerScript.activePlayer == gameObject.tag)
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