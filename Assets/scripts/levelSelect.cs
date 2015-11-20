using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour {
	private GameObject gameManager;
	private playerState playerStatus;

	private GameObject optionsPanel;
	private CanvasGroup optionsPanelCanvasGroup;

	private GameObject player1;
	private GameObject player2;

	private CircleCollider2D player1Collider;
	private CircleCollider2D player2Collider;


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

	public void hideOptions()
	{	
		gameManager = GameObject.FindWithTag("gameManager");
		playerStatus = gameManager.GetComponent<playerState>();


		optionsPanel = GameObject.Find("options_panel");
		optionsPanelCanvasGroup = optionsPanel.GetComponent<CanvasGroup>();

		optionsPanelCanvasGroup.alpha = 0f;
		optionsPanelCanvasGroup.blocksRaycasts = false;	

		player1 = GameObject.FindWithTag("Player1");
		player1Collider = player1.GetComponent<CircleCollider2D>();

		player2 = GameObject.FindWithTag("Player2");
		player2Collider = player2.GetComponent<CircleCollider2D>();

		player1Collider.enabled = playerStatus.player1;
		player2Collider.enabled = playerStatus.player2;

		Time.timeScale = 1;
	
	}

	public void showOptions()
	{
		gameManager = GameObject.FindWithTag("gameManager");
		playerStatus = gameManager.GetComponent<playerState>();


		optionsPanel = GameObject.Find("options_panel");
		optionsPanelCanvasGroup = optionsPanel.GetComponent<CanvasGroup>();

		optionsPanelCanvasGroup.alpha = 1f;
		optionsPanelCanvasGroup.blocksRaycasts = true;

		player1 = GameObject.FindWithTag("Player1");
		player1Collider = player1.GetComponent<CircleCollider2D>();

		player2 = GameObject.FindWithTag("Player2");
		player2Collider = player2.GetComponent<CircleCollider2D>();

		player1Collider.enabled = false;
		player2Collider.enabled = false;

		Time.timeScale = 0;
	}




}
