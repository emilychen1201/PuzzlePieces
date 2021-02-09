using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelRecord{

	public int level;
	public int template;
	public List<float> positionX= new List<float>();
	public List<float> positionY= new List<float>();
	public List<string> shapesOrder= new List<string>();
	public List<int> shapesAngle= new List<int>();


}
