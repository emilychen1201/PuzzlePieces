using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControllerNoArrow : MonoBehaviour {
	public GameObject navigationCanvas;
	public GameObject subimitButton;
	
	// Update is called once per frame
	public void OnClick(){
		navigationCanvas.gameObject.SetActive(false);
		subimitButton.gameObject.SetActive(true);
	}
}
