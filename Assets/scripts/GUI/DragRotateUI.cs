using UnityEngine;
using System.Collections;

public class DragRotateUI : MonoBehaviour {

	Vector3 startVector;						
	Vector3 endVector;

	Vector3 firstPosition;

	Quaternion rotation;

	public GameObject sceneManager;

	private drawLine _drawLine;
	private rotate _rotate;
	private playerState _playerState;
	private GameObject activePlayer;

	void Start () 
	{
		_playerState = sceneManager.GetComponent<playerState>();
	}

	public void BeginDrag()
	{
		firstPosition = Input.mousePosition;							//Log the start of the drag
		
		activePlayer = GameObject.FindWithTag(_playerState.activePlayer);
		_drawLine = activePlayer.GetComponent<drawLine>();
		_rotate = activePlayer.GetComponent<rotate>();
	}

	public void Drag()
	{
		startVector = firstPosition - transform.position;				//Find the first vector
		endVector = Input.mousePosition - transform.position;			//Find the end vector
		
		rotation = Quaternion.FromToRotation(startVector, endVector);	//rotate angle from first vector to end vector
		rotation = Quaternion.Euler(new Vector3(0f, 0f, rotation.eulerAngles.z));	//restrict angle to z axis

		transform.rotation *= rotation;									//offset rotation transform with our new angle

		firstPosition = Input.mousePosition;							//log the last position as the new start vector

		_drawLine.ChangeAngle(rotation);
		_rotate.RotateGameObject(rotation);
	}
}