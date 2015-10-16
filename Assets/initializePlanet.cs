using UnityEngine;
using System.Collections;

public class initializePlanet : MonoBehaviour {

	public float dynamicsOffDelay;
	public float fieldStrength;

	Rigidbody2D physicsSwitch;
	public ForceField2D field;	

	planetMeta planetInfo;
	public float generalMultiplierMemory;

	// Use this for initialization
	void Start () {
		physicsSwitch = GetComponent<Rigidbody2D>();
		planetInfo = GetComponent<planetMeta>();
		field = GetComponent<ForceField2D>();

		//only turn on repulsion field if the planet is not a parent
		
		if (planetInfo.Iterator >= 9){	
			generalMultiplierMemory = field.generalMultiplier;	//grab the value that's there

			physicsSwitch.isKinematic = false;
			field.generalMultiplier = fieldStrength;

			StartCoroutine(delayPhysics(dynamicsOffDelay));
		}
	}
	

	IEnumerator delayPhysics(float seconds) {
		yield return new WaitForSeconds (seconds);		
		physicsSwitch.isKinematic = true;
		field.generalMultiplier = generalMultiplierMemory;
	}
}
