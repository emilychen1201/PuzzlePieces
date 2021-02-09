using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class

public class TimerShow : MonoBehaviour {
	//public GameObject timer;
	//public GameObject timer;
	[SerializeField] Text show;

	// Use this for initialization
	void Start () {
		//record=timer.GetComponent<GameManager>().timeUse;
		show.text = Singleton.instance.time + " s";
		if (PlayerPrefs.GetInt("record")==0){
			SaveByJSON(Singleton.instance.name);
		}
	}
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
		save.name=name;

        int totalTime = 0;
        int count = save.records.Count;	
        int win = 0;
        save.levelRecord.Add(Singleton.instance.level);
        if (Singleton.instance.level > save.levelMax){
            save.levelMax = Singleton.instance.level;
        }


		for (int i = 0; i < count; i++){
            totalTime+=save.records[i].time;
            if (save.records[i].win){
                win += 1;
            }

		}
        save.winRecord.Add(Math.Round((double) win/count * 100 , 2));
        save.avgTime= Math.Round((double) totalTime/count , 2);
        save.winRate= Math.Round((double) win/count * 100 , 2);

        string UpdateJsonString = JsonUtility.ToJson(save);//Convert SAVE Object into JSON(String)

        StreamWriter sw = new StreamWriter(Application.dataPath + "/" + name + ".json");//Application.dataPath + "/JSONData.text"
        sw.Write(UpdateJsonString);
        sw.Close();

    }


	
	public void OnClickSuccess(){
		SceneManager.LoadScene("LevelMap");
	}
	
	// Update is called once per frame
	
}
