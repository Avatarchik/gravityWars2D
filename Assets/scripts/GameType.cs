using UnityEngine;
using System.Collections;

public class GameType : MonoBehaviour {

	public enum GameSelection{golf, vsAI, vsPlayer};
	public GameSelection type;
	public static GameType Instance;

	void Awake(){
		if (Instance)									//check for duplicates
			DestroyImmediate(transform.gameObject);
		else
		{
			DontDestroyOnLoad(transform.gameObject);
			Instance = this;
		}
	}

}

