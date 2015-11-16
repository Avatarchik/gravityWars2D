using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Vectrosity;

public class TrailManager : MonoBehaviour {
	public Texture lineTex;
	public Color lineColor;
	public float lineWidth = 12.0f;
	public float textureScale = 1f;
	public bool fetchColor = false;

	int maxPoints = 500000;
	bool continuousUpdate = true;

	private VectorLine pathLine;
	private int pathIndex = 0;
	private bool initiator = true;
	private FadeChildTrails fadeChildTrails;
	private int numberofTrails = 1;

	public GameObject currentTorpedo;

	//FetchColor
	GameObject gameManager;

	private playerState playerStateScript;
	private string activePlayer;

	//FadeChildTrails
	public Component[] canvasGroupNodes;
 
    public List<VectorLine> trailRenderList = new List<VectorLine>();


	// Use this for initialization
	public void drawTrail (GameObject torpedo) {
		currentTorpedo = torpedo;
		numberofTrails = trailRenderList.Count;
		currentTorpedo = torpedo;
		
		pathLine = new VectorLine("Path_" + numberofTrails +1, 
									new List<Vector3>(), 
									lineTex, 
									lineWidth, 
									LineType.Continuous);
		pathLine.color = lineColor;
		pathLine.textureScale = 1f;

		if (fetchColor == true){
			FetchColor();
		}
		trailRenderList.Add(pathLine);

		StartCoroutine(SamplePoints (torpedo));
	}

	public void Fade(){
		canvasGroupNodes = GetComponentsInChildren<CanvasGroup>();

		foreach (CanvasGroup node in canvasGroupNodes){
			if (node.name == "TorpedoTrailsPanel"){
				}else{
					node.alpha -= .1f;
					if (node.alpha <= 0){
					Destroy(node.gameObject);
				}
			}
		} 
	}

	void FetchColor () {
        gameManager = GameObject.FindWithTag("gameManager");
        playerStateScript = gameManager.GetComponent<playerState>();

        activePlayer = playerStateScript.activePlayer;

        if (activePlayer == "Player1"){
        	lineColor = playerStateScript.player1Color;
        }else{
        	lineColor = playerStateScript.player2Color;
        }
        pathLine.color = lineColor;
	}
	
	IEnumerator SamplePoints (GameObject torpedo){
		//Gets the position of the 3D object  at intervals(20 times a second)
		bool running = true;
		while (running){
			if (torpedo.activeInHierarchy == true){
				if(++pathIndex >= maxPoints){
					running = false;
				}else{
					pathLine.points3.Add (torpedo.transform.position);
					pathLine.rectTransform.SetParent(gameObject.transform);

					yield return new WaitForSeconds(.025f);

					if (continuousUpdate){
						pathLine.Draw3D();
					}
					if (initiator == true){
						initiator = false;
					}
				}

					//fadeChildTrails.Fade();
			}else{
				running = false;
			}
		}
		Destroy(torpedo.transform.parent.gameObject);
	}
}
