﻿using UnityEngine;
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

	private CanvasGroup scoreCanvasGroup;
	private CanvasGroup menuCanvasGroup;

	public void Start(){
		_gameType = GameObject.Find("persistentData").GetComponent<GameType>();
		
	}

	public void newLevel()
	{
		if (_gameType.type == GameType.GameSelection.golf)
			golf();
		else if (_gameType.type == GameType.GameSelection.vsPlayer)
			vsPlayer();
		else if (_gameType.type == GameType.GameSelection.vsAI)
			golf();
	}

	public void vsPlayer(){
		_gameType.type = GameType.GameSelection.vsPlayer;
		SceneManager.LoadScene("playScreen");

		Time.timeScale = 1;
	}

	public void golf()
	{
		_gameType.type = GameType.GameSelection.golf;
		SceneManager.LoadScene("playScreen");
		Time.timeScale = 1;
	}

	public void statScreen(){
		scoreCanvasGroup = GameObject.Find("Score_panel").GetComponent<CanvasGroup>();
		menuCanvasGroup = GameObject.Find("Menu_panel").GetComponent<CanvasGroup>();

		menuCanvasGroup.alpha = 0;
		menuCanvasGroup.blocksRaycasts = false;

		scoreCanvasGroup.alpha = 1;
		scoreCanvasGroup.blocksRaycasts = true;
	}

	public void menuScreen(){
		scoreCanvasGroup = GameObject.Find("Score_panel").GetComponent<CanvasGroup>();
		menuCanvasGroup = GameObject.Find("Menu_panel").GetComponent<CanvasGroup>();
		
		menuCanvasGroup.alpha = 1;
		menuCanvasGroup.blocksRaycasts = true;

		scoreCanvasGroup.alpha = 0;
		scoreCanvasGroup.blocksRaycasts = false;
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
