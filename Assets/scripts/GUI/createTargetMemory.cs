using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class createTargetMemory : MonoBehaviour {

	public GameObject targetingMemory;
	public GameObject playerTargetingPanel_A;
	public GameObject playerTargetingPanel_B;

	public int poolAmount = 6;
	public List<GameObject> targetingMemoryList;

	private GameObject sceneManager;
	playerState playerActive;

	// Use this for initialization
	void Start () {
		sceneManager = GameObject.FindWithTag("gameManager");
		playerActive = sceneManager.GetComponent<playerState>();

		playerTargetingPanel_A = GameObject.Find("targetingText_A_panel");
		playerTargetingPanel_B = GameObject.Find("targetingText_B_panel");


		targetingMemoryList = new List<GameObject>();
		for (int i = 0; i < poolAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(targetingMemory);
			obj.SetActive(false);
			obj.transform.parent = transform;
			targetingMemoryList.Add(obj);
		}
	
	}

	public void activateMemoryObject()
	{
		for (int i = 0; i < targetingMemoryList.Count; i++)
		{
			if(!targetingMemoryList[i].activeInHierarchy)
			{
				if (playerActive.player1 == true)
				{
					targetingMemoryList[i].transform.parent = playerTargetingPanel_A.transform;
					targetingMemoryList[i].tag = "Player";
				}
				else
				{
					targetingMemoryList[i].transform.parent = playerTargetingPanel_B.transform;
					targetingMemoryList[i].tag = "Player2";
				}
				targetingMemoryList[i].SetActive(true);
			break;
			}	
		}
	}
	
	public void fadeAlpha(Vector3 position)
	{
		for (int i = 0; i < targetingMemoryList.Count; i++)
		{
			if (targetingMemoryList[i].activeInHierarchy)
			{
				targetingMemoryList[i].GetComponent<targetMemoryLifespan>().incrementIndex(position);
			}
		}
	}
	
	
}
