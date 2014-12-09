/*using UnityEngine;
using System.Collections.Generic;

public class gravity : MonoBehaviour 
{	
	public static float range = 1000;
	
	void FixedUpdate () 
	{
		Collider[] cols  = Physics.OverlapSphere(transform.position, range); 
		List<Rigidbody> rbs = new List<Rigidbody>();
		
		foreach(Collider c in cols)
		{
			Rigidbody rb = c.attachedRigidbody;
			if(rb != null && rb != rigidbody && !rbs.Contains(rb))
			{
				rbs.Add(rb);
				Vector3 offset = transform.position - c.transform.position;
				rb.AddForce( offset / offset.sqrMagnitude * rigidbody.mass);
			}
		}
	}
}
*/

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