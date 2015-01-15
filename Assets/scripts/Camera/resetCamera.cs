using UnityEngine;
using System.Collections;

public class resetCamera : MonoBehaviour {
	
	public float defaultCamera;
	public float cameraSmoothing;

	// Use this for initialization
	void Start () {
		defaultCamera = Camera.main.orthographicSize + 1.25f;
	}

	public void smoothResetCamera() {
		StartCoroutine(smoothResetCamera_co(defaultCamera));

	}
	
	
	// Update is called once per frame
	IEnumerator smoothResetCamera_co (float defaultCamera) {
		while(Camera.main.orthographicSize - defaultCamera > .05f){
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, defaultCamera, cameraSmoothing*Time.deltaTime);

			yield return null;
		}
	}
	
	
}
