using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class

public class AnalysisSingleton : MonoBehaviour
{
    public static AnalysisSingleton instance;
	public string name;
	public int levelMax;
	public double avgTime;
	public double winRate;
    public List<int> levelRecord = new List<int>();
	public List<double> winRecord = new List<double>();
    public List<OneRecord> records = new List<OneRecord>();


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
    public void LoadAnaByJSON(string name)
    {
        levelRecord.Clear();
        winRecord.Clear();
        if(File.Exists(Application.dataPath + "/" + name + ".json"))
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/" + name + ".json");

            string JsonString = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            Save save = JsonUtility.FromJson<Save>(JsonString);//Into the Save Object
            levelRecord=new List<int>(save.levelRecord);
            winRecord=new List<double>(save.winRecord);
            winRate=save.winRate;
            avgTime=save.avgTime;
            levelMax=save.levelMax;  
            records=new List<OneRecord>(save.records);        
        }

    }

}
