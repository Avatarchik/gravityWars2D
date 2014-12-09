using UnityEngine;
using System.Collections;

public class drawDebug : MonoBehaviour {

	private int displayInt;

	 void OnGUI ()
    {
        // Make a background box
        GUI.Box(new Rect(10,10,100,90), displayInt.ToString()); 
    
    } 
	// Use this for initialization
	void Start () {
		displayInt = gameObject.GetComponentInParent<gui>().testNumber;
	}
	
	// Update is called once per frame
	void Update () {
		displayInt = gameObject.GetComponentInParent<gui>().testNumber;
	}
}
