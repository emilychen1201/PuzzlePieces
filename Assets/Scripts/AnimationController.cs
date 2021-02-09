using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {
	Animator arrow;
	public GameObject navigationCanvas;
	public GameObject subimitButton;

	// Use this for initialization
	void Start () {
		arrow=gameObject.GetComponent<Animator>();
		arrow.speed = 0;

	}
	
	// Update is called once per frame
	public void OnClick(){
		navigationCanvas.gameObject.SetActive(false);
		subimitButton.gameObject.SetActive(true);
		arrow.speed = 1;
	}
}
