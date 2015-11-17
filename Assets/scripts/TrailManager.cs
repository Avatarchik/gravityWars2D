using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Vectrosity;

public class TrailManager : MonoBehaviour {

	public Texture lineTex;
	public Material lineMaterial;
	public Color lineColor;
	public float lineWidth = 12.0f;
	public float textureScale = 1f;
	public bool fetchColor = false;

	int maxPoints = 500000;
	bool continuousUpdate = true;

	private VectorLine pathLine;
	private int pathIndex = 0;
	private FadeChildTrails fadeChildTrails;
	private int numberofTrails = 1;

	public GameObject currentTorpedo;

	//FetchColor
	GameObject gameManager;

	private playerState playerStateScript;
	private string activePlayer;

	//FadeChildTrails
	private VectorLine tempLine;
	private Color fadeAlpha;
	public float fadeAlphaFactor = .1f;
 
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
		pathLine.material = lineMaterial;
		pathLine.textureScale = 1f;

		if (fetchColor == true){
			FetchColor();
		}
		trailRenderList.Add(pathLine);

		StartCoroutine(SamplePoints (torpedo));
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


	public void Fade(){
		for(int i = 0; i < trailRenderList.Count; i++){
			fadeAlpha = trailRenderList[i].color;
			fadeAlpha.a -= fadeAlphaFactor;
			trailRenderList[i].color = fadeAlpha;
			if(fadeAlpha.a <= 0f){
				trailRenderList.RemoveAt(i);
				tempLine = trailRenderList[i];
				VectorLine.Destroy(ref tempLine);
			}
		}

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
				}
			}else{
				running = false;
			}
		}
		Destroy(torpedo.transform.parent.gameObject);
		Fade();
	}
}
