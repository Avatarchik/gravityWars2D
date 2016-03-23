 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;

public class Execute : MonoBehaviour {

	public float pressAndHoldDelay = .5f;
	public float timer;

	private GameObject sceneManager;
	playerState playerStateScript;
	GameObject currentPlayer;

	public GameObject childButton;
	CanvasGroup _canvasGroup;


	void Start(){
		sceneManager = GameObject.FindWithTag("gameManager");
		playerStateScript = sceneManager.GetComponent<playerState>();

		_canvasGroup = childButton.GetComponent<CanvasGroup>();


	}

	public void Fire()
	{
		currentPlayer = GameObject.FindWithTag(playerStateScript.activePlayer);
		drawLine drawLineScript = currentPlayer.GetComponent<drawLine>();
		drawLineScript.FireTorpedo();
		_canvasGroup.alpha = 0;
	}

	public void onPointerDown()
	{
		StartCoroutine("PressAndHold");
	}

	public void onPointerUp(){
		StopCoroutine ("PressAndHold");
		timer = 0;
	}

	public void DisplayButton(){
		_canvasGroup.alpha = 1;
	}

	IEnumerator PressAndHold(){
		while(timer <= pressAndHoldDelay){
			timer += Time.deltaTime;
			yield return null;
		}
		DisplayButton();
		yield break;
	}
	

}
