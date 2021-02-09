using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Save{

	public List<OneRecord> records = new List<OneRecord>();
	public string name;
	public int levelMax;
	public double avgTime;
	public double winRate;
	public List<int> levelRecord = new List<int>();
	public List<double> winRecord = new List<double>();


}
