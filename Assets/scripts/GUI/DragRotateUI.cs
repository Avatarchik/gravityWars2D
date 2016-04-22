using UnityEngine;
using System.Collections;

public class DragRotateUI : MonoBehaviour {

	Vector3 startVector;						
	Vector3 endVector;

	Vector3 firstPosition;

	Quaternion rotation;

	public void BeginDrag()
	{
		firstPosition = Input.mousePosition;							//Log the start of the drag
	}

	public void Drag()
	{
		startVector = firstPosition - transform.position;				//Find the first vector
		endVector = Input.mousePosition - transform.position;			//Find the end vector
		
		rotation = Quaternion.FromToRotation(startVector, endVector);	//rotate angle from first vector to end vector

		transform.rotation *= rotation;									//offset rotation transform with our new angle

		firstPosition = Input.mousePosition;							//log the last position as the new start vector
	}

}
