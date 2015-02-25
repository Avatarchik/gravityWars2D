using UnityEngine;
using System.Collections;

public class targetMemoryLifespan : MonoBehaviour {
	public int index = 0;
	private float alpha = .5f;


	public void incrementIndex()
	{
		index += 1;
		alpha *= .75f;
		gameObject.GetComponent<CanvasGroup>().alpha = alpha;

		if (index > 2)
		{
			index = 0;
			alpha = .75f;
		}
	}
}
