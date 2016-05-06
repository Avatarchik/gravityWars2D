using UnityEngine;
using System.Collections;

public class CheckGameType : MonoBehaviour {
	private GameType _gameType;
	CanvasGroup scoreCanvasGroup;

	// Use this for initialization
	void Start () {
		_gameType = GameObject.Find("persistentData").GetComponent<GameType>();
		scoreCanvasGroup = GetComponent<CanvasGroup>();

		if(_gameType.type != GameType.GameSelection.golf){
			scoreCanvasGroup.alpha = 0;
		}
	
	}
}
