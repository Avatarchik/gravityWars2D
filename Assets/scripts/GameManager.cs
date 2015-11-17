using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.VersionEditor;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Text versionText;

	// Use this for initialization
	void Start () {
		versionText.text = VersionInformation.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
