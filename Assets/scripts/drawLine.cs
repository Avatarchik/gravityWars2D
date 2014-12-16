using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	public LineRenderer lineRender;				//needs a lineRender to work

	private gui guiScript;
    private GameObject sceneManager;

	public float radius = 2;					//limit to length of drawLine
	float distance;								//length of the line
	Vector3 lineDirection;						//vector of the line drawn.


	//position of mouse, beginning and end.
	Vector3 mousePos;					
	Vector3 firstPos;
	Vector3 worldPos;					

	public GameObject targetingImage;			//grab the UI
	CanvasGroup canvasGroup;


	Vector3 reset = new Vector3(0,0,0);			//reset values.

	torpedo childTorpedo;

	public float smoothing = 0f;				//Lerp modifier.

	//////////////////////////////////////////////////////////////////////////

	void Start(){
		childTorpedo = gameObject.GetComponentInChildren<torpedo>();
        sceneManager = GameObject.FindWithTag("gameManager");
        guiScript = sceneManager.GetComponent<gui>();
        targetingImage = GameObject.Find("targetingImage");
        canvasGroup = targetingImage.GetComponent<CanvasGroup>();
	}
	
	void OnMouseDown() 
	{
		mousePos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.z = 1.0f;
		firstPos = Camera.main.ScreenToWorldPoint(mousePos);
		worldPos = firstPos;

		targetingImage.transform.position = mousePos;
		StartCoroutine("smoothAlpha");
	}
	
	void OnMouseDrag()
	{
		mousePos = Input.mousePosition;
		mousePos.z = 1.0f;
		worldPos = Camera.main.ScreenToWorldPoint(mousePos);

		lineDirection = worldPos - firstPos;		//get the vector

		//limit the line length
		worldPos = firstPos + Vector3.ClampMagnitude(lineDirection, radius);

		lineRender.SetPosition(0, firstPos);
		lineRender.SetPosition(1, worldPos);
	}

	void OnMouseUp()
	{
		distance = Vector3.Distance(firstPos, worldPos);
		float normalizeDistance = (distance/radius)*100;		//normalize the length of the line 

		guiScript.lastPower = (int)normalizeDistance;			//send the power of the torpedo to the guiScript

		lineRender.SetPosition(0, reset);
		lineRender.SetPosition(1, reset);
		childTorpedo.mouseFire = true;

		//stop the coroutine and reset the values.
		StopCoroutine("smoothAlpha");
		canvasGroup.alpha = 0; 
		targetingImage.transform.localScale = new Vector3(0,0,0);
	}
	
	IEnumerator smoothAlpha()
	{
		while(canvasGroup.alpha < 1)
		{
			canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, smoothing * Time.deltaTime);
			targetingImage.transform.localScale = Vector3.Lerp(targetingImage.transform.localScale, new Vector3(6,6,6), smoothing * Time.deltaTime);

			yield return null;
		}		
	}
}
