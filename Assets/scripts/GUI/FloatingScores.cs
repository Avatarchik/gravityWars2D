using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingScores : MonoBehaviour {

	public GameObject goal;

	private Text _text;

	private Vector3 disabledPosition;
	private Vector3 startPosition;
	private Color initialColor;
	private float alpha;
	private Color setAlpha;
	private int value;

	public float speed = 1.0f;

	bool scores = false;
	GameType _gameType; 


	public void UpdateLocation (GameObject emitter, int value) {
		if(scores == true){
			_text.text = ("+" + value.ToString());
			startPosition = Camera.main.WorldToScreenPoint(emitter.transform.position);
			StartCoroutine(MoveToGoal());
		}

	}

	void Start(){
		_gameType = GameObject.Find("persistentData").GetComponent<GameType>();

		if(_gameType.type == GameType.GameSelection.golf){
			scores = true;
		}

		disabledPosition = transform.position;
		_text = GetComponent<Text>();
		initialColor = GetComponent<Text>().color;
		alpha = _text.color.a;
		setAlpha = initialColor;
	}

	IEnumerator MoveToGoal(){
		float startTime = Time.time;

		while(Time.time - startTime <= 1){
			transform.position = Vector3.Lerp(startPosition, goal.transform.position, Time.time-startTime);
			initialColor.a = Mathf.Lerp(alpha, 0, Time.time-startTime);
			_text.color = initialColor;
			yield return 1;
		}
		transform.position = disabledPosition;
		_text.color = setAlpha;
		alpha = _text.color.a;
	}
}
