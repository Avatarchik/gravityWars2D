using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	public LineRenderer lineRender;
	Vector3 reset = new Vector3(0,0,0);
	float distance;

	Vector3 firstPos;

	Vector3 lineDirection;

	public float radius = 2;

	public Vector3 mousePos;
	public Vector3 worldPos;

	torpedo childTorpedo;

	void Start(){
		childTorpedo = gameObject.GetComponentInChildren<torpedo>();
	}
	
	void OnMouseDown() 
	{
		mousePos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.z = 1.0f;
		firstPos = Camera.main.ScreenToWorldPoint(mousePos);
	}
	
	void OnMouseDrag()
	{
		mousePos = Input.mousePosition;
		mousePos.z = 1.0f;
		worldPos = Camera.main.ScreenToWorldPoint(mousePos);

		lineDirection = worldPos - firstPos;

		//limit the line length
		worldPos = firstPos + Vector3.ClampMagnitude(lineDirection, radius);

		lineRender.SetPosition(0, firstPos);
		lineRender.SetPosition(1, worldPos);
	}

	void OnMouseUp()
	{
		lineRender.SetPosition(0, reset);
		lineRender.SetPosition(1, reset);
		childTorpedo.mouseFire = true;
	}
}
