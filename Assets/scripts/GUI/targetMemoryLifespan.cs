using UnityEngine;
using System.Collections;

public class targetMemoryLifespan : MonoBehaviour {
	private float alpha = 1f;


	public void incrementIndex()
	{
		alpha *= .5f;
		gameObject.GetComponent<CanvasGroup>().alpha = alpha;

		if (alpha < .15f)
			alpha = 1f;
	}
}
