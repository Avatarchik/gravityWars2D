using UnityEngine;
using System.Collections;

public class torpedoPosition : MonoBehaviour {
	public Vector3 myPosition;										//target to track's position
	
	//private int size = 2;											
	public float sizeFaction = 0;
	//private bool rampFlag = false;


	// Use this for initialization
	void Update () {
	
		myPosition = Camera.main.WorldToViewportPoint(transform.position);

		if (myPosition.x < .1f || myPosition.x > .9f || myPosition.y < .1f || myPosition.y > .9f)
		{
			if (myPosition.x < .2f || myPosition.x > .8f || myPosition.y < .2f || myPosition.y > .8f)
			{
				if (Camera.main.orthographicSize <= 15)
				{
					Camera.main.orthographicSize += .05f;
				}
			}
		}

		else
		{
			if (Camera.main.orthographicSize > 5)					//if the camera size is greater then our default
			{
				Camera.main.orthographicSize -= .05f;
	
			}
		}
	}

}
