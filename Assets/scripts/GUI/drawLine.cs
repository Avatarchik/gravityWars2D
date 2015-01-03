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
	Vector3 worldPos;
	Vector3 firstPos;
					

	public GameObject targetingImage;			//grab the UI
	playerState playerState;
	CanvasGroup canvasGroup;

	public Vector3 imageScale = new Vector3(1,1,1);
	public float screenScale = 5.7f;			//how much to scale the screen (past 5)
	Vector3 reset = new Vector3(0,0,0);			//reset values.

	torpedo childTorpedo;

	public float smoothing = 0f;				//Lerp modifier.

	//////////////////////////////////////////////////////////////////////////

	void Start(){
		childTorpedo = gameObject.GetComponentInChildren<torpedo>();
        sceneManager = GameObject.FindWithTag("gameManager");
        guiScript = sceneManager.GetComponent<gui>();
        targetingImage = GameObject.Find("targetReticle");
        canvasGroup = targetingImage.GetComponent<CanvasGroup>();
        playerState = sceneManager.GetComponent<playerState>();
	}
	
	void OnMouseDown() 
	{
		mousePos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.z = 1.0f;
		firstPos = Camera.main.ScreenToWorldPoint(mousePos);
		worldPos = firstPos;

		targetingImage.transform.position = worldPos;

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

		distance = Vector3.Distance(firstPos, worldPos);
		float normalizeDistance = (distance/radius)*100;		//normalize the length of the line 
		guiScript.testNumber = (int)normalizeDistance;
	}

	void OnMouseUp()
	{
		float normalizeDistance = (distance/radius)*100;		//normalize the length of the line 
		guiScript.lastPower = (int)normalizeDistance;			//send the power of the torpedo to the guiScript
		guiScript.testNumber = 0;								//reset testNumber to 0

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
			//Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, screenScale, smoothing * Time.deltaTime);
			canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, smoothing * Time.deltaTime);
			targetingImage.transform.localScale = Vector3.Lerp(targetingImage.transform.localScale, imageScale, smoothing * Time.deltaTime);

			yield return null;
		}		
	}
}
