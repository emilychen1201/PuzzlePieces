using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CirclePosition : MonoBehaviour {

    private Transform template;
	private Transform circleTransform;
	private RectTransform circleRectTransform;
	private void Awake() {
		template = transform.Find("whiteCircle");
		template.gameObject.SetActive(false);
		float width = 1.2f;
		for (int i=0; i<5; i++){
			for (int j=0; j<5; j++){
				circleTransform = Instantiate(template, transform);
        		circleRectTransform = circleTransform.GetComponent<RectTransform>();
        		circleRectTransform.anchoredPosition = new Vector2(-2.4f+width*i,-2.4f+width*j);
        		circleTransform.gameObject.SetActive(true);;
			}
		}
       
	}
}
