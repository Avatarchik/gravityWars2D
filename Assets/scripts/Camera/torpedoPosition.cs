using UnityEngine;
using System.Collections;

public class torpedoPosition : MonoBehaviour {
	Vector3 myPosition;												//target to track's position
	
	public float cameraDefaultScale = 6.25f;

	public float smoothOut = 1f;									//factor to smooth out by
	float newSmoothOut = .5f;
	public float smoothIn = 1f;										//factor to smooth in by
	float smoother = 1f;											//smooth the factor

	// Use this for initialization
	void Update () {
	
		myPosition = Camera.main.WorldToViewportPoint(transform.position);

		
		if (myPosition.x < .1f || myPosition.x > .9f || myPosition.y < .1f || myPosition.y > .9f)
		{
			if (Camera.main.orthographicSize <= 15)
			{
				smoothOut = Mathf.Lerp(newSmoothOut, smoothOut, smoother * Time.deltaTime);
				newSmoothOut = smoothOut;

				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 15, smoothOut * Time.deltaTime);
			}
		}
	

		else
		{
			if (Camera.main.orthographicSize > cameraDefaultScale)					//if the camera size is greater then our default
			{
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraDefaultScale, smoothIn * Time.deltaTime);	

			}
		}
	}

}
