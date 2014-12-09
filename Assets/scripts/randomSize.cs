using UnityEngine;
using System.Collections;

public class randomSize : MonoBehaviour {

	public float planetLowBounds = 0.25f;
	public float planetHighBounds = 3.0f;
	
	// Use this for initialization
	void Start () {

		float randomScale = Random.Range(planetLowBounds, planetHighBounds);
		transform.localScale = Vector3.one * randomScale;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
