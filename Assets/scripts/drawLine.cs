using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	public LineRenderer lineRender;
	Vector3 reset = new Vector3(0,0,0);
	//Vector3 direction;

	Vector3 firstPos;

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
		//distance = Vector3.Distance(firstPos, worldPos);

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
