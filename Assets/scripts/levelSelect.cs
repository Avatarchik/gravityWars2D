using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour {
	private GameObject gameManager;
	private playerState playerStatus;

	private CircleCollider2D player1Collider;
	private CircleCollider2D player2Collider;

	private Animator _animator;


	public void newLevel()
	{
		Application.LoadLevel("playScreen");
		Time.timeScale = 1;
	}

	public void introScreen()
	{
		Application.LoadLevel("startScreen");
		Time.timeScale = 1;
	}

	public void showOptions()
	{
		gameManager = GameObject.FindWithTag("gameManager");

		_animator = GameObject.Find("options_panel").GetComponent<Animator>();

		_animator.SetTrigger("slideIn");

		player1Collider = GameObject.FindWithTag("Player1").GetComponent<CircleCollider2D>();
		player2Collider = GameObject.FindWithTag("Player2").GetComponent<CircleCollider2D>();

		player1Collider.enabled = false;
		player2Collider.enabled = false;

	}

	public void hideOptions()
	{	
		Time.timeScale = 1;

		gameManager = GameObject.FindWithTag("gameManager");
		playerStatus = gameManager.GetComponent<playerState>();

		_animator = GameObject.Find("options_panel").GetComponent<Animator>();

		_animator.SetTrigger("slideOut");

		player1Collider = GameObject.FindWithTag("Player1").GetComponent<CircleCollider2D>();
		player2Collider = GameObject.FindWithTag("Player2").GetComponent<CircleCollider2D>();

		player1Collider.enabled = playerStatus.player1;
		player2Collider.enabled = playerStatus.player2;
	
	}

}
