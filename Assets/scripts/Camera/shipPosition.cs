using UnityEngine;
using System.Collections;

public class shipPosition : MonoBehaviour {
	Vector3 myPosition;												//target to track's position
	
	//public float sizeFaction = 0;
	public float smoothOut = 1f;									//factor to smooth out by
	float newSmoothOut = .5f;
	float smoother = 1f;											//smooth the factor

	// Use this for initialization
	void LateUpdate () {
	
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
	}

}
