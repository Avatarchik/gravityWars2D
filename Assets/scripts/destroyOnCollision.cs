using UnityEngine;
using System.Collections;

public class destroyOnCollision : MonoBehaviour
{
	private Canvas canvas;
	private changeText changeText;
	private string objectHit;

	//When the torpedo collides, detect what it has collided with, then send that info to the canvas.
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);

		collision.gameObject.GetComponent<health>().damage();
		
		playerState.instance.playerSwitch();		//Singleton!!!
		
		changeText.messageState(collision.gameObject.tag);

	}

	void Start()
	{
		canvas = GameObject.FindObjectOfType<Canvas>();
		changeText = canvas.GetComponentInChildren<changeText>();

	}

}