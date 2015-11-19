using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour {
	private GameObject gameManager;
	private playerState playerStatus;

	private GameObject optionsPanel;
	private CanvasGroup optionsPanelCanvasGroup;

	public GameObject player1;
	public GameObject player2;

	public CircleCollider2D player1Collider;
	public CircleCollider2D player2Collider;

	void Start(){
		gameManager = GameObject.FindWithTag("gameManager");
		playerStatus = gameManager.GetComponent<playerState>();


		optionsPanel = GameObject.Find("options_panel");
		optionsPanelCanvasGroup = optionsPanel.GetComponent<CanvasGroup>();
	}

	public void newLevel()
	{
		Application.LoadLevel("playScreen");
	}

	public void introScreen()
	{
		Application.LoadLevel("startScreen");
	}

	public void hideOptions()
	{
		optionsPanelCanvasGroup.alpha = 0f;
		optionsPanelCanvasGroup.blocksRaycasts = false;	

		player1 = GameObject.FindWithTag("Player1");
		player1Collider = player1.GetComponent<CircleCollider2D>();

		player2 = GameObject.FindWithTag("Player2");
		player2Collider = player2.GetComponent<CircleCollider2D>();

		player1Collider.enabled = playerStatus.player1;
		player2Collider.enabled = playerStatus.player2;
	
	}

	public void showOptions()
	{
		optionsPanelCanvasGroup.alpha = 1f;
		optionsPanelCanvasGroup.blocksRaycasts = true;

		player1 = GameObject.FindWithTag("Player1");
		player1Collider = player1.GetComponent<CircleCollider2D>();

		player2 = GameObject.FindWithTag("Player2");
		player2Collider = player2.GetComponent<CircleCollider2D>();

		player1Collider.enabled = false;
		player2Collider.enabled = false;
	}

	


}
