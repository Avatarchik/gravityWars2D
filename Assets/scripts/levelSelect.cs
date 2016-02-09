using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {
	private GameObject gameManager;
	private GameObject persitentData;

	private GameType _gameType;
	private playerState playerStatus;

	private CircleCollider2D player1Collider;
	private CircleCollider2D player2Collider;

	private Animator _animator;

	public void Start(){
		_gameType = GameObject.Find("persistentData").GetComponent<GameType>();
	}

	public void newLevel()
	{
		_gameType.type = GameType.GameSelection.golf;
		SceneManager.LoadScene("playScreen");
		Time.timeScale = 1;
	}

	public void vsPlayer(){
		_gameType.type = GameType.GameSelection.vsPlayer;
		SceneManager.LoadScene("playScreen");

		Time.timeScale = 1;
	}

	public void vsAI(){
		_gameType.type = GameType.GameSelection.vsAI;
	}

	public void introScreen()
	{
		SceneManager.LoadScene("startScreen");

		Time.timeScale = 1;
	}

	public void showOptions()
	{
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

		playerStatus = GameObject.FindWithTag("gameManager").GetComponent<playerState>();

		_animator = GameObject.Find("options_panel").GetComponent<Animator>();

		_animator.SetTrigger("slideOut");

		player1Collider = GameObject.FindWithTag("Player1").GetComponent<CircleCollider2D>();
		player2Collider = GameObject.FindWithTag("Player2").GetComponent<CircleCollider2D>();

		player1Collider.enabled = playerStatus.player1;
		player2Collider.enabled = playerStatus.player2;
	
	}



}
