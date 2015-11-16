using UnityEngine;
using System.Collections;

public class CreateTrail : MonoBehaviour {

	private GameObject torpedoTrailsPanel;
	private TrailManager trailManager;
	private GameObject torpedo;


	// Use this for initialization
	void Start () {
		torpedoTrailsPanel = GameObject.Find("TorpedoTrailsPanel");
		trailManager = torpedoTrailsPanel.GetComponent<TrailManager>();
		trailManager.drawTrail(gameObject);
	}
}
