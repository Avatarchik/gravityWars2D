using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ChangeMessage : MonoBehaviour {
	private Text messageText;
	private CanvasGroup _canvasGroup;
	private Animator _animator;

	public float messageDuration = 1.0f;


 	public void ChangeText(string message)
 	{
 		messageText.text = message;
 		_animator.SetTrigger("textIn");
 		StartCoroutine(wait(messageDuration));
 	
 	}
 	void Start()
 	{
 		messageText = GetComponent<Text>();
 		_animator = gameObject.GetComponentInParent<Animator>();
 	}

	
 	IEnumerator wait(float messageDuration){
		yield return new WaitForSeconds(messageDuration);
		_animator.SetTrigger("textOut");
	}
	
	
}
