using UnityEngine;
using System.Collections;

public class DetachTorpedoTrail : MonoBehaviour {

	public TrailRenderer trailRender;
	public GameObject torpedoTrailGroup;

	void Start(){
		torpedoTrailGroup = GameObject.Find("torpedoTrailsGroup");
	}

	// Use this for initialization
	void OnDestroy(){
		trailRender.transform.parent = torpedoTrailGroup.transform;
		trailRender.autodestruct = true;
	}
}


