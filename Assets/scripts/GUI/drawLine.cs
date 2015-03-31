using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	public LineRenderer lineRender;				//needs a lineRender to work

	private gui guiScript;
    private GameObject sceneManager;

	public float radius = 2;					//limit to length of drawLine
	float distance;								//length of the line
	Vector3 lineDirection;						//vector of the line drawn.
	Vector3 upVector = new Vector3(0,1,0);

	Vector3 mousePos;					
	Vector3 firstPos;
	Vector3 worldPos;
	Vector3 radiusLimit;

	public GameObject targetingPanel;
	GameObject confirmTarget;
	CanvasGroup confirmTargetCanvasGroup;
	CanvasGroup targetingPanelCanvasGroup;

	public Vector3 imageScale = new Vector3(1,1,1);
	public float screenScale = 5.7f;			//how much to scale the screen (past 5)
	Vector3 reset = new Vector3(0,0,0);			//reset values.

	torpedo childTorpedo;

	public float smoothing = 0f;				//Lerp modifier.

	createTargetMemory targetingPanelCreateMemory;

	int playerCounter = 0;



	//////////////////////////////////////////////////////////////////////////

	void Start(){
		childTorpedo = gameObject.GetComponentInChildren<torpedo>();
        sceneManager = GameObject.FindWithTag("gameManager");
        guiScript = sceneManager.GetComponent<gui>();

        targetingPanel = GameObject.Find("targeting_panel");
        targetingPanelCanvasGroup = targetingPanel.GetComponent<CanvasGroup>();

        targetingPanelCreateMemory = targetingPanel.GetComponent<createTargetMemory>();

        confirmTarget = GameObject.Find("targetingInfoPanel");
        confirmTargetCanvasGroup = confirmTarget.GetComponent<CanvasGroup>();




	}
	
	void OnMouseDown() 
	{
		mousePos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.z = 1.0f;
		firstPos = Camera.main.ScreenToWorldPoint(mousePos);
		worldPos = firstPos;

		targetingPanel.transform.position = Camera.main.WorldToScreenPoint(transform.position);
		confirmTarget.transform.position = mousePos;

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

		radiusLimit = Camera.main.WorldToScreenPoint(firstPos + (lineDirection.normalized * (1.175f * radius)));
		confirmTarget.transform.position = radiusLimit;


		mousePos = Camera.main.WorldToScreenPoint(worldPos);

		lineRender.SetPosition(0, firstPos);
		lineRender.SetPosition(1, worldPos);

		float angle = Vector3.Angle(upVector, lineDirection);
		if (lineDirection.x < 0)
		{
			angle = 360 - angle;
		}
		
		guiScript.targetingAngle = (int)angle;


		distance = Vector3.Distance(firstPos, worldPos);
		float normalizeDistance = (distance/radius)*100;		//normalize the length of the line 
		guiScript.testNumber = (int)normalizeDistance;
	}

	void OnMouseUp()
	{
		float normalizeDistance = (distance/radius)*100;		//normalize the length of the line 
		guiScript.lastPower = (int)normalizeDistance;			//send the power of the torpedo to the guiScript

		guiScript.testNumber = 0;

		lineRender.SetPosition(0, reset);
		lineRender.SetPosition(1, reset);
		childTorpedo.mouseFire = true;

		float directionDegrees = Vector3.Angle(transform.right, lineDirection);
		guiScript.oldTargetingAngle = (int)directionDegrees;
		guiScript.targetingAngle = 0;

		//stop the coroutine and reset the values.
		StopCoroutine("smoothAlpha");
		targetingPanelCanvasGroup.alpha = 0; 
		confirmTargetCanvasGroup.alpha = 0;

		if (playerCounter < 6)
		{
			targetingPanelCreateMemory.activateMemoryObject();
			playerCounter ++;
		}
		targetingPanelCreateMemory.fadeAlpha(mousePos);
		
		targetingPanel.transform.localScale = reset;
	}
	
	
	IEnumerator smoothAlpha()
	{
		while(targetingPanelCanvasGroup.alpha < 1)
		{
			targetingPanelCanvasGroup.alpha = Mathf.Lerp(targetingPanelCanvasGroup.alpha, 1, smoothing * Time.deltaTime);
			targetingPanel.transform.localScale = Vector3.Lerp(targetingPanel.transform.localScale, imageScale, smoothing * Time.deltaTime);

			confirmTargetCanvasGroup.alpha = Mathf.Lerp(confirmTargetCanvasGroup.alpha, 1, smoothing * Time.deltaTime);
			confirmTarget.transform.localScale = Vector3.Lerp(confirmTarget.transform.localScale, imageScale, smoothing/2 * Time.deltaTime);

			yield return null;
		}		
	}
	
}
