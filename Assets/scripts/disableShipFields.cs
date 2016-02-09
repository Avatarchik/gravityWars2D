using UnityEngine;
using System.Collections;

public class disableShipFields : MonoBehaviour {
	

	public GameObject shipA;
	public GameObject shipB;

	private ForceField2D shipAForceField;
	private ForceField2D shipBForceField;


	// Use this for initialization
	void Start () {
		shipA = GameObject.FindWithTag("Player1");
		shipB = GameObject.FindWithTag("Player2");

		shipAForceField = shipA.GetComponentInChildren<ForceField2D>();
		shipBForceField = shipB.GetComponentInChildren<ForceField2D>();

		Invoke ("DisableFields", .2f);
	}

	void DisableFields()
	{
		if (shipAForceField != null)
			shipAForceField.enabled = false;

		if (shipBForceField != null);
			shipBForceField.enabled = false;
	}




}
