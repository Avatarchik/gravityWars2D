using UnityEngine;
using System.Collections;

public class debris : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void regenerate()
	{
		Destroy(gameObject);
	}
}
