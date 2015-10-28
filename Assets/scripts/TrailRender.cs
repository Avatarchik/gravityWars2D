﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using Vectrosity;

public class TrailRender : MonoBehaviour {

	public Texture lineTex;
	public Color lineColor;
	public float lineWidth = 12.0f;
	public float textureScale = 1f;
	public bool fetchColor = false;

	int maxPoints = 500000;
	bool continuousUpdate = true;

	private VectorLine pathLine;
	private int pathIndex = 0;
	

	//FetchColor
	GameObject gameManager;

	private playerState playerStateScript;
	private string activePlayer;

	// Use this for initialization
	void Start () {
		pathLine = new VectorLine("Path", 
									new List<Vector3>(), 
									lineTex, 
									lineWidth, 
									LineType.Continuous);
		pathLine.color = lineColor;
		pathLine.textureScale = 1f;
		if (fetchColor == true){
			FetchColor();
		}
		StartCoroutine(SamplePoints ());
	}

	void FetchColor () {
        gameManager = GameObject.FindWithTag("gameManager");
        playerStateScript = gameManager.GetComponent<playerState>();

        activePlayer = playerStateScript.activePlayer;

        if (activePlayer == "Player1"){
        	pathLine.color = playerStateScript.player1Color;
        }else{
        	pathLine.color = playerStateScript.player2Color;
        }
	}
	
	IEnumerator SamplePoints (){
		//Gets the position of the 3D object  at intervals(20 times a second)
		bool running = true;
		while (running){
			pathLine.points3.Add (transform.position);
			if (++pathIndex == maxPoints) {
				running = false;
			}
			yield return new WaitForSeconds(.025f);

			if (continuousUpdate){
				pathLine.Draw3D();
				pathLine.rectTransform.SetParent(GameObject.Find("TorpedoTrailsPanel").transform);

			}
		}
	}
}

