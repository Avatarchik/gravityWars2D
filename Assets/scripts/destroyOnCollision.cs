/*Author: Ian Mankowski
 * Title: destroyOnCollision
 * 
 * Usage:
 *place on gameObject to destroy it when it collides with another gameObject
 *
 *About: This script destroys the gameObject on collision and sends a signal to the sceneManager to switch players.
 */

using UnityEngine;
using System.Collections;

public class destroyOnCollision : MonoBehaviour
{
	private Canvas canvas;
	private changeText changeText;
	private string objectHit;

	void torpedoDestroy ()
	{
		Destroy(gameObject);
		playerState.instance.playerSwitch();		//Singleton!!!
	}
	
	//When the torpedo collides, detect what it has collided with, then send that info to the canvas.
	private void OnCollisionEnter2D(Collision2D collision)
	{
		objectHit = collision.gameObject.tag;
		torpedoDestroy();
		changeText.messageState(objectHit);

	}

	void Start()
	{
		canvas = GameObject.FindObjectOfType<Canvas>();
		changeText = canvas.GetComponentInChildren<changeText>();
	}

}