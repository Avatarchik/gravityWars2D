using UnityEngine;
using System.Collections;

public class torpedoPosition : MonoBehaviour {
	Vector3 myPosition;										//target to track's position
	
	//private int size = 2;											
	public float sizeFaction = 0;
	public float smoothOut = 1f;									//factor to smooth out by
	float newSmoothOut = .5f;
	public float smoothIn = 1f;										//factor to smooth in by
	float smoother = 1f;											//smooth the factor
	//private bool rampFlag = false;


	// Use this for initialization
	void FixedUpdate () {
	
		myPosition = Camera.main.WorldToViewportPoint(transform.position);

		/*
		if (myPosition.x < .1f || myPosition.x > .9f || myPosition.y < .1f || myPosition.y > .9f)
		{
			if (myPosition.x < .2f || myPosition.x > .8f || myPosition.y < .2f || myPosition.y > .8f)
			{
				if (Camera.main.orthographicSize <= 15)
				{
					//smoothOut = Mathf.Lerp(newSmoothOut, smoothOut, smoother * Time.deltaTime);
					Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 15, smoothOut * Time.smoothDeltaTime);
					//Camera.main.orthographicSize += .05f;
				}
			}
		}
		*/

		if (myPosition.x < .2f || myPosition.x > .8f || myPosition.y < .2f || myPosition.y > .8f)
		{
			if (Camera.main.orthographicSize <= 15)
			{
				smoothOut = Mathf.Lerp(newSmoothOut, smoothOut, smoother * Time.deltaTime);
				newSmoothOut = smoothOut;

				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 15, smoothOut * Time.smoothDeltaTime);
				//Camera.main.orthographicSize += .05f;
			}
		}
	

		else
		{
			if (Camera.main.orthographicSize > 5)					//if the camera size is greater then our default
			{
				//Camera.main.orthographicSize -= .05f;
				//Camera.main.orthographicSize = Mathf.Lerp(5, Camera.main.orthographicSize, smoothScreen * Time.deltaTime);	
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5, smoothIn * Time.smoothDeltaTime);	

			}
		}
	}

}
