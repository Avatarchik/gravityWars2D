using UnityEngine;
using System.Collections;

public class GameType : MonoBehaviour {

	public enum GameSelection{golf, vsAI, vsPlayer};

	public GameSelection type;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

}

