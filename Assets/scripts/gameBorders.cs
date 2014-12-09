using UnityEngine;
using System.Collections;


//////////////////////////////////////////////////
//Creates the four borders of our gameplay space//
//////////////////////////////////////////////////
public class gameBorders : MonoBehaviour {

	public GameObject border;
	GameObject gameBorderParent;


	//placeData
	Vector2 position;
	Vector2 worldPos;
	Vector3 scaleFactor;
	string borderName;
	string[] borderNames= {"borderBottom", "borderLeft", "borderRight", "borderTop"};

	float y;
	float x;

	///Converts screenspace coordinates to worldspace coordinates and then instantiates border geometry
	void createBorder(Vector2 position, Vector3 scaleFactor, string borderName)
	{
		worldPos = Camera.main.ScreenToWorldPoint(position);					
		border = Instantiate(border, worldPos, Quaternion.identity) as GameObject;
		border.transform.localScale = scaleFactor;
		border.name = borderName;
		border.transform.parent = gameBorderParent.transform;
		border.tag = "border";
	}

	void createBorders()
	{
		y = Camera.main.orthographicSize * 6.0f;
		x = (y * Screen.width/Screen.height);

		gameBorderParent = new GameObject ("borderParentGroup");										//empty gameObject to contain our border
		gameBorderParent.transform.parent = (GameObject.FindWithTag("gameManager").transform);			//parent empty gameObject to Scene manager

		for(int i = 0; i < 4; i++)
		{
			if (i == 0)
			{
				position = new Vector2((((0.0f-Screen.width)+(Screen.width*2))/2), 0.0f-Screen.height);
				createBorder(position, new Vector3(x,.1f,1), borderNames[i]);
			}
			else if (i == 1)
			{
				position = new Vector2((0.0f-Screen.width), ((Screen.height*2)+(0.0f-Screen.height))/2);
				createBorder(position, new Vector3(.1f,y,1), borderNames[i]);
			}
			else if (i == 2)
			{
				position = new Vector2(Screen.width*2, ((Screen.height*2)+(0.0f-Screen.height))/2);
				createBorder(position, new Vector3(.1f,y,1), borderNames[i]);
			}
			else if (i == 3)
			{
				position = new Vector2((((0.0f-Screen.width)+(Screen.width*2))/2), Screen.height*2);
				createBorder(position, new Vector3(x,.1f,1), borderNames[i]);
			}
		}
	}
	// Use this for initialization
	void Start () {

	createBorders();	
	}
}
