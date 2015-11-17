using UnityEngine;
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
	private GameObject torpedoTrailsPanel;
	private bool initiator = true;
	private FadeChildTrails fadeChildTrails;
	private int numberofTrails = 1;

	//FetchColor
	GameObject gameManager;

	private playerState playerStateScript;
	private string activePlayer;

	// Use this for initialization
	void Start () {

		torpedoTrailsPanel = GameObject.Find("TorpedoTrailsPanel");
		fadeChildTrails = torpedoTrailsPanel.GetComponent<FadeChildTrails>();

		numberofTrails = torpedoTrailsPanel.transform.childCount;

		pathLine = new VectorLine("Path_" + numberofTrails, 
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

	    //This is our custom class with our variables
    [System.Serializable]
    public class TrailRenderList{
        //public GameObject AnGO;
        //public int AnInt;
        //public float AnFloat;
        //public Vector3 AnVector3;
        //public int[] AnIntArray = new int[0];
    }
 
    //This is our list we want to use to represent our class as an array.
    public List<TrailRenderList> trailRenderList = new List<TrailRenderList>(1);

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
			}
			if (initiator == true){
				initiator = false;

				pathLine.rectTransform.SetParent(torpedoTrailsPanel.transform);
				pathLine.rectTransform.gameObject.AddComponent<CanvasGroup>();
				fadeChildTrails.Fade();
			}	
		}
	}
}

