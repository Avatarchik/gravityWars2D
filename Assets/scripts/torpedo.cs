using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class torpedo : MonoBehaviour
{

	[FFToolTip("Bullet prefab.")]
	public Transform bullet;
	
	[FFToolTip("Fire once per turn")]
	public bool oneFire;

	[FFToolTip("Cool down time of the gun.")]
	public float cd = 0.5f;
	
	[FFToolTip("The life time of bullets.")]
	public float bulletLife = 20;
	
	[FFToolTip("The force field.")]
	public ForceField2D field;
	
	[FFToolTip("The force applied on the bullets.")]
	public float force = 1000;
	
	[FFToolTip("Should bullets use gravity?")]
	public bool bulletGarvity = true;

	[HideInInspector]
	public bool cdFlag = true;
	
	Vector3 pos = new Vector3(2, 0, 0);
	rotate rotateScript;

	private GameObject sceneManager;
	public bool mouseFire = false;
	private gui guiScript;

	drawLine drawControl;

	private destroyOnCollision destroyScript;


	
	// Use this for initialization
	void Start()
	{
		Physics.IgnoreLayerCollision(8, 8);
		rotateScript = GetComponentInParent<rotate>();

		sceneManager = GameObject.FindWithTag("gameManager");
		guiScript = sceneManager.GetComponent<gui>();
		drawControl = gameObject.GetComponentInParent<drawLine>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (mouseFire == true || Input.GetKeyUp("space"))
		{
			if (cdFlag)
			{
				field.generalMultiplier = guiScript.lastPower;
				rotateScript.enabled = false;
				mouseFire = false;
				drawControl.enabled = false;
				shot();
			}
		}
	}
	
	void shot()
	{
		cdFlag = !cdFlag;
		if (oneFire)
		{

		}
		else
		{
			StartCoroutine("cooldown");
		}
			
		Transform t = GameObject.Instantiate(bullet) as Transform;
		t.position = transform.TransformPoint(pos);
		t.rotation = transform.rotation;
	}
	
	IEnumerator cooldown()
	{
		yield return new WaitForSeconds(cd);
		cdFlag = true;
	}

}
