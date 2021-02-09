using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class PositionController : MonoBehaviour {
	 private GameObject[] shapes; 
	 public List<string> duplicate= new List<string>();
	 public List<string> single= new List<string>();
	 private List<int> finish= new List<int>();



	// Use this for initialization
	void Start () {
		for (var i=0;i<LevelSingleton.instance.shapesOrder.Count;i++){
			shapes = GameObject.FindGameObjectsWithTag(LevelSingleton.instance.shapesOrder[i]);
			for (int j=0; j<duplicate.Count; j++){
				if (LevelSingleton.instance.shapesOrder[i]==duplicate[j]){
				shapes[finish[j]].transform.position= new Vector2(LevelSingleton.instance.positionX[i], LevelSingleton.instance.positionY[i]);
				shapes[finish[j]].transform.rotation= Quaternion.Euler(0,0,LevelSingleton.instance.shapesAngle[i]);
				finish[j] += 1;
				}
			}
			for (int j=0; j<single.Count; j++){
				if (LevelSingleton.instance.shapesOrder[i]==single[j]){
				shapes[0].transform.position= new Vector2(LevelSingleton.instance.positionX[i], LevelSingleton.instance.positionY[i]);
				shapes[0].transform.rotation= Quaternion.Euler(0,0,LevelSingleton.instance.shapesAngle[i]);
				}
			} 
			
		}
		
	}
	
}
