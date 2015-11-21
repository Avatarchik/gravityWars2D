using UnityEngine;
using System.Collections;

public class PauseTime : MonoBehaviour {

	void StartTime () {
		Time.timeScale = 1;
	}
	

	void StopTime () {
		Time.timeScale = 0;
	}
}
