using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeChildTrails : MonoBehaviour {

	public Component[] canvasGroupNodes;
	
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
}
