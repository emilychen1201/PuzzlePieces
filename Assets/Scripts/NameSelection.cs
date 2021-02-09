using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class


public class NameSelection : MonoBehaviour {
	public Dropdown dropdown;
	private List<string> names = new List<string>();

	
	// Use this for initialization
	private void Start () {
		names = loadName("NameList");
		PopulateList();	
	}
	
	// Update is called once per frame
	private List<string> loadName(string name){
		NameList nameList= new NameList();
		if(File.Exists(Application.dataPath + "/" + name + ".json"))
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/" + name + ".json");

            string JsonString = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            nameList = JsonUtility.FromJson<NameList>(JsonString);//Into the Save Object			
        
			
        }

		return nameList.names;
	}

	public void Dropdown_IndexChanged(int index){
		Singleton.instance.name=names[index];
	}
	private void PopulateList(){
		dropdown.AddOptions(names);
	}
}
