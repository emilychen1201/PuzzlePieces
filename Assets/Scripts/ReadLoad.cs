using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class

public class ReadLoad : MonoBehaviour {

	// Use this for initialization
	private OneRecord createOneRecord()
    {
    	OneRecord oneRecord = new OneRecord();

        oneRecord.date = Singleton.instance.date;
        oneRecord.level = Singleton.instance.level;
		oneRecord.time = Singleton.instance.time;
        oneRecord.mode = Singleton.instance.mode;
		oneRecord.win = Singleton.instance.win;

        return oneRecord;
    }

    //MARKER Object(Save Type) --> JSON(String)
    private void SaveByJSON(string name)
    {
		Save save = new Save();
		if(File.Exists(Application.dataPath + "/" + name + ".json"))//Application.dataPath + "/" + name + ".json"
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/" + name + ".json");

            string JsonString = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            save = JsonUtility.FromJson<Save>(JsonString);//Into the Save Object
		}

    	OneRecord oneRecord = createOneRecord();
		save.records.Add(oneRecord);

        string UpdateJsonString = JsonUtility.ToJson(save);//Convert SAVE Object into JSON(String)

        StreamWriter sw = new StreamWriter(Application.dataPath + "/" + name + ".json");//Application.dataPath + "/JSONData.text"
        sw.Write(UpdateJsonString);
        sw.Close();
    }

    //MARKER JSON(STring) --> Object(Save Type)
    private Dictionary<int, bool> LoadLevelByJSON(string name)
    {
		Dictionary<int, bool> dict = new Dictionary<int, bool>();
        if(File.Exists(Application.dataPath + "/" + name + ".json"))
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/" + name + ".json");

            string JsonString = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            Save save = JsonUtility.FromJson<Save>(JsonString);//Into the Save Object		
            for (int i = 0; i < save.records.Count; i++){
				if (dict.ContainsKey(save.records[i].level)){
					if (!dict[save.records[i].level]){
						dict.Add(save.records[i].level,save.records[i].win);
					}
				}
				else{
					dict.Add(save.records[i].level,save.records[i].win);
				}
			}
			
        }
		return dict;
    }
}