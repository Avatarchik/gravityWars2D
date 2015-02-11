using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class getText : MonoBehaviour {
	private Text canvasText;
	public GameObject sceneManager;
	int displayInt;
	int oldInt = 0;

	// Use this for initialization
	void Start () {
		canvasText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		if (sceneManager.GetComponent<gui>().updateFlag == true){

			updateValues(sceneManager.GetComponent<gui>().testNumber);
		}
	}
	void updateValues(int number){
		displayInt = number;

			if (oldInt != displayInt){
				oldInt = displayInt;
				canvasText.text = oldInt.ToString();
			}
			
	}
}
