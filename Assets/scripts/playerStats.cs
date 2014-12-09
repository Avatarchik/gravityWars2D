using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

	public int player1Stats = 0;
	public int player2Stats = 0;

	private static playerStats _instance;

	public static playerStats instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<playerStats>();
			return _instance;
		}
	}

}
