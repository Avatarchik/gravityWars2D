using UnityEngine;
using System.Collections;

public class destroyOnCollision : MonoBehaviour
{
	private Canvas canvas;
	private changeText changeText;
	private string objectHit;

	public float fuseTimer = .1f;

	//When the torpedo collides, detect what it has collided with, then send that info to the canvas.
	private void OnCollisionEnter2D(Collision2D collision)
	{
		gameObject.SetActive(false);

		collision.gameObject.GetComponent<health>().damage();
		
		playerState.instance.playerSwitch();		//Singleton!!!
		
		changeText.messageState(collision.gameObject.tag);
	}

	void Start()
	{
		canvas = GameObject.FindObjectOfType<Canvas>();
		changeText = canvas.GetComponentInChildren<changeText>();
		StartCoroutine(bulletLifeSpan(fuseTimer));

	}

	IEnumerator bulletLifeSpan(float fuseTimer){
		yield return new WaitForSeconds(fuseTimer);
		gameObject.SetActive(false);
		playerState.instance.playerSwitch();
		changeText.messageState("fuse");
	}

}

	