using UnityEngine;
using System.Collections;

public class upVector : MonoBehaviour {
	public GameObject north;
	public Vector3 northVector;

	// Use this for initialization
	void Start () {
	

		northVector = north.transform.position - transform.position;

	}
	
	
}
