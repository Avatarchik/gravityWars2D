using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	public LineRenderer lineRender;				//needs a lineRender to work

	private gui guiScript;
    private GameObject sceneManager;

	public float radius = 2;					//limit to length of drawLine
	float distance;								//length of the line
	Vector3 lineDirection;						//vector of the line drawn.
	Vector3 lineDirectionNew;					//vector the line is to go towards
	Vector3 upVector = new Vector3(0,1,0);

	Vector3 newDirection;

	Vector3 mousePos;					
	Vector3 firstPos;
	public Vector3 worldPos;
	Vector3 radiusLimit;

	public GameObject targetingPanel;
	GameObject confirmTarget;

	GameObject decreasePowerPanel;

	CanvasGroup confirmTargetCanvasGroup;
	CanvasGroup targetingPanelCanvasGroup;

	public Vector3 imageScale = new Vector3(1,1,1);
	public float screenScale = 5.7f;			//how much to scale the screen (past 5)
	Vector3 reset = new Vector3(0,0,0);			//reset values.

	torpedo childTorpedo;

	public float smoothing = 0f;				//Lerp modifier.

	createTargetMemory targetingPanelCreateMemory;

	int playerCounter = 0;

	Vector3 incrementByOne;
	float normalizeDistance;


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

        decreasePowerPanel = GameObject.Find("decreasePower_panel");

	}
	
	void OnMouseDrag()
	{
		//place targetingPanel
		if (targetingPanelCanvasGroup.alpha == 0){
			mousePos = Camera.main.WorldToScreenPoint(transform.position);
			mousePos.z = 1.0f;
			firstPos = Camera.main.ScreenToWorldPoint(mousePos);

			targetingPanel.transform.position = Camera.main.WorldToScreenPoint(transform.position);
			confirmTarget.transform.position = mousePos;
			decreasePowerPanel.transform.position = mousePos;

			StartCoroutine("smoothAlpha");
		}
		

		mousePos = Input.mousePosition;
		mousePos.z = 1.0f;
		worldPos = Camera.main.ScreenToWorldPoint(mousePos);

		lineDirection = worldPos - firstPos;		//get the vector

		//limit the line length
		worldPos = firstPos + Vector3.ClampMagnitude(lineDirection, radius);
		mousePos = Camera.main.WorldToScreenPoint(worldPos);

		redrawLine();

	}

	public void redrawLine(){

		confirmTarget.transform.position = Camera.main.WorldToScreenPoint(firstPos +(lineDirection.normalized * (1.25f *radius)));

		decreasePowerPanel.transform.position = Camera.main.WorldToScreenPoint(firstPos + -(lineDirection.normalized * (1.25f *radius)));

		distance = Vector3.Distance(firstPos, worldPos);
		normalizeDistance = (distance/radius)*100;
		guiScript.testNumber = (int)normalizeDistance;
		lineDirection = worldPos - firstPos;

		float angle = Vector3.Angle(upVector, lineDirection);
		if (lineDirection.x < 0)
		{
			angle = 360 - angle;
		}
		
		guiScript.targetingAngle = (int)angle;

		lineRender.SetPosition(0, firstPos);
		lineRender.SetPosition(1, worldPos);
	}

	public void DecreaseLine()
	{
		if (normalizeDistance >=1){
			incrementByOne = Vector3.ClampMagnitude(lineDirection, .01f);
			worldPos -= incrementByOne;

			redrawLine();
		}	
	}

	public void IncreaseLine()
	{
		if (normalizeDistance <= 100){
			incrementByOne = Vector3.ClampMagnitude(lineDirection, .01f);
			worldPos += incrementByOne;

			redrawLine();
		}
	}

	public void ChangeAngle(Quaternion lineDirectionNew)
	{
		newDirection = lineDirectionNew * lineDirection;
		worldPos = firstPos + Vector3.ClampMagnitude(newDirection, radius);

		redrawLine();
	}

	public void FireTorpedo()
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
		mousePos = Camera.main.WorldToScreenPoint(worldPos);
		targetingPanelCreateMemory.fadeAlpha(mousePos);			//Send the position of the end of the line to the memory chit.
		
		targetingPanel.transform.localScale = reset;
		confirmTarget.transform.localScale = reset;
	}
	
	
	
	IEnumerator smoothAlpha()
	{
		while(targetingPanelCanvasGroup.alpha < .75f)
		{
			targetingPanelCanvasGroup.alpha = Mathf.Lerp(targetingPanelCanvasGroup.alpha, .75f, smoothing * Time.deltaTime);
			targetingPanel.transform.localScale = Vector3.Lerp(targetingPanel.transform.localScale, imageScale, smoothing * Time.deltaTime);

			confirmTargetCanvasGroup.alpha = Mathf.Lerp(confirmTargetCanvasGroup.alpha, .75f, smoothing * Time.deltaTime);
			confirmTarget.transform.localScale = Vector3.Lerp(confirmTarget.transform.localScale, imageScale, smoothing/2 * Time.deltaTime);

			yield return null;
		}		
	}
	
}
