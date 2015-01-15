using UnityEngine;
using System.Collections;

public class gameCenter : MonoBehaviour {
	Vector3 defaultCenterOfInterest;

	public float shipCenterWeighting = .25f;

	void Start () {
		defaultCenterOfInterest = Camera.main.transform.position;
		defaultCenterOfInterest.z = 0;
		transform.position = defaultCenterOfInterest;	
	}

	public void updateCenterOfInterest(GameObject ship){
		transform.position = Vector3.Lerp(defaultCenterOfInterest, ship.transform.position, shipCenterWeighting);
	}

	public void resetCenterOfInterest(){
		transform.position = defaultCenterOfInterest;
	}
}