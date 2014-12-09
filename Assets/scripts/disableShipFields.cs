using UnityEngine;
using System.Collections;

public class disableShipFields : MonoBehaviour {

	public GameObject shipA;
	public GameObject shipB;


	// Use this for initialization
	void Start () {
		shipA = GameObject.FindWithTag("Player");
		shipB = GameObject.FindWithTag("Player2");

		Invoke ("DisableFields", .2f);
	}

	void DisableFields()
	{
		shipA.GetComponentInChildren<ForceField2D>().enabled = false;
		shipB.GetComponentInChildren<ForceField2D>().enabled = false;
	}



}
