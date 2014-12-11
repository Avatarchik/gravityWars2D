using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {
	
	public float maxGravDist = 4.0f;
	public float maxGravity = 35.0f;
	
	GameObject[] planets;

	
	void Start () {
		planets = GameObject.FindGameObjectsWithTag("Planet");
	}
	
	void FixedUpdate () {
		foreach(GameObject planet in planets) {
			float dist = Vector3.Distance(planet.transform.position, transform.position);
			if (dist <= maxGravDist) {
				Vector3 v = planet.transform.position - transform.position;
				rigidbody2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
			}
		}
	}
}