using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {

	public void newLevel()
	{
		Application.LoadLevel("playScreen");
	}

	public void introScreen()
	{
		Application.LoadLevel("startScreen");
	}
}
