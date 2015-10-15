using UnityEngine;
using System.Collections;

public class initializePlanet : MonoBehaviour {

	public float dynamicsOffDelay;
	Rigidbody2D physicsSwitch;
	public ForceField2D field;	
	public float fieldStrength;

	// Use this for initialization
	void Start () {
		physicsSwitch = GetComponent<Rigidbody2D>();
		field = GetComponent<ForceField2D>();

		physicsSwitch.isKinematic = false;
		field.generalMultiplier = fieldStrength;

		StartCoroutine(delayPhysics(dynamicsOffDelay));
	
	}
	

	IEnumerator delayPhysics(float seconds) {
		yield return new WaitForSeconds (seconds);		
		physicsSwitch.isKinematic = true;
		field.generalMultiplier = 1;
	}
}
