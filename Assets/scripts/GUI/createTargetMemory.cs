using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class createTargetMemory : MonoBehaviour {

	public GameObject targetingMemory;

	public int poolAmount = 6;
	public List<GameObject> targetingMemoryList;

	int currentIndex = 0;

	// Use this for initialization
	void Start () {

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
				targetingMemoryList[i].SetActive(true);
			break;
			}	
		}
	}

	public void fadeAlpha()
	{
		for (int i = 0; i < targetingMemoryList.Count; i++)
		{
			if (targetingMemoryList[i].activeInHierarchy)
			{
				targetingMemoryList[i].GetComponent<targetMemoryLifespan>().incrementIndex();
			}
		}
	}

	public void setPosition(Vector3 position)
	{
		if (currentIndex >= 3)
		{
			currentIndex = 0;
		}
		targetingMemoryList[currentIndex].transform.position = position;
		currentIndex += 1;
		
	}
	
}
