using UnityEngine;
using System.Collections;

public class PlanetSkimDetection : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log("skimming the planet!");
	}
}
