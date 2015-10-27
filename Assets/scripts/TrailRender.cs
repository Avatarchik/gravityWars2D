using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using Vectrosity;

public class TrailRender : MonoBehaviour {

	public Texture lineTex;
	public Color lineColor;
	int maxPoints = 500;
	bool continuousUpdate = true;

	private VectorLine pathLine;
	private int pathIndex = 0;

	// Use this for initialization
	void Start () {
		pathLine = new VectorLine("Path", 
									new List<Vector3>(), 
									lineTex, 
									6.0f, 
									LineType.Continuous);
		pathLine.color = lineColor;
		pathLine.textureScale = 1f;
		StartCoroutine(SamplePoints ());
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
		}
	}
}

