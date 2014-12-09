using UnityEngine;
using System.Collections;

public class enableChild : MonoBehaviour {
	public GameObject childObject;
	private bool activate = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("d"))
		{
			activate = !activate;
			childObject.SetActive(activate);
		}
	
	}

	
}
