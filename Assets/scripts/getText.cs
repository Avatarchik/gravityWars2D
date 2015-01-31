using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class getText : MonoBehaviour {
	private Text canvasText;
	public GameObject sceneManager;
	public int displayInt;
	public int oldInt = 0;



	// Use this for initialization
	void Start () {
		canvasText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		displayInt = sceneManager.GetComponent<gui>().testNumber;

		if (oldInt != displayInt)
		{
			oldInt = displayInt;
			if (oldInt == 0)
				canvasText.text = "";
			else	
				canvasText.text = oldInt.ToString();

		}

	
	}
}
