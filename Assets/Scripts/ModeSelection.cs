using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class

public class ModeSelection : MonoBehaviour {

	// Use this for initialization
	private int playing_index;
	private int record_index;
	public void Dropdown_Playing_IndexChanged(int index){
		playing_index=index;
	}
	public void Dropdown_Record_IndexChanged(int index){
		record_index=index;
		
	}
	public void ClickStart(){
		PlayerPrefs.SetInt("record", record_index);
		LoadLevelRecord("Level"); 
		if (playing_index==1){			
			SceneManager.LoadScene("Level"+Singleton.instance.level+"_CopyMode");	
			Singleton.instance.mode="Copiar";
		}
		else{
			SceneManager.LoadScene("Level"+Singleton.instance.level+"_CountDown_na");
			Singleton.instance.mode="Memorizar";
		}
					
	}
	private void LoadLevelRecord(string name)
    {
        if(File.Exists(Application.dataPath + "/" + name + ".json"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/" + name + ".json");

            string JsonString = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            SaveLevelRecord saveLevelRecord = JsonUtility.FromJson<SaveLevelRecord>(JsonString);//Into the Save Object		
			LevelSingleton.instance.template =  saveLevelRecord.levelAll[Singleton.instance.level-1].template;
			LevelSingleton.instance.positionX = new List<float> (saveLevelRecord.levelAll[Singleton.instance.level-1].positionX);
			LevelSingleton.instance.positionY = new List<float> (saveLevelRecord.levelAll[Singleton.instance.level-1].positionY);
			LevelSingleton.instance.shapesOrder= new List<string> (saveLevelRecord.levelAll[Singleton.instance.level-1].shapesOrder);
			LevelSingleton.instance.shapesAngle= new List<int> (saveLevelRecord.levelAll[Singleton.instance.level-1].shapesAngle);
			
        }
    }
}
