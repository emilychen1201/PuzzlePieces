using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class

public class RankingList : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    private Transform addButton;
    
    private List<string> names= new List<string>();
    private List<Save> allList= new List<Save>();

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        addButton = entryContainer.Find("AddButton");

        entryTemplate.gameObject.SetActive(false);
        addButton.gameObject.SetActive(false);

        names = loadName("NameList");

        foreach (string name in names){
            LoadAnaByJSON(name);
        }
        SortByBubble(allList,GetLevel);
   
        int listNum=0;
        foreach (Save save in allList){
            CreateHighscoreEntryTransform(save, listNum);
            listNum += 1;
        }

        Transform buttonTransform = Instantiate(addButton, entryContainer);
        RectTransform buttonRectTransform = buttonTransform.GetComponent<RectTransform>();
        buttonRectTransform.anchoredPosition = new Vector2(0, -100 * listNum);
        buttonTransform.gameObject.SetActive(true);

        
    }

    private void CreateHighscoreEntryTransform(Save save, int ListNum) {
        float templateHeight = 100f;
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * ListNum);
        entryTransform.gameObject.SetActive(true);
        Button rankButton = entryTransform.Find("rankButton").GetComponent<Button>();
        rankButton.onClick.AddListener(delegate {clickRank(allList[ListNum].name); });

        entryTransform.Find("rankButton").Find("rankText").GetComponent<Text>().text = (ListNum+1).ToString();
  

        int level = save.levelMax;

        entryTransform.Find("record").GetComponent<Text>().text = level.ToString();

        string name = save.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;


    }
    private void LoadAnaByJSON(string name)
    {
        if(File.Exists(Application.dataPath + "/" + name + ".json"))
        {
            //LOAD THE GAME
            StreamReader sr = new StreamReader(Application.dataPath + "/" + name + ".json");

            string JsonString = sr.ReadToEnd();

            sr.Close();

            //Convert JSON to the Object(save)
            Save save = JsonUtility.FromJson<Save>(JsonString);//Into the Save Object

            allList.Add(save);	
			
        }
    }
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
    private int GetLevel(Save save)
    {
        return save.levelMax;
    }

    private double GetWin(Save save)
    {
        return save.winRate;
    }
    private delegate int MyDelegate(Save save);

    private void SortByBubble(List<Save> allList, MyDelegate _myDelegate)
    {
        bool isBubble = true;

        do
        {
            isBubble = false;
            for (int i = 0; i < allList.Count - 1; i++)
            {
                //if (_list[i].playerHighestScore > _list[i + 1].playerHighestScore)
                if(_myDelegate(allList[i]) < _myDelegate(allList[i + 1]))
                {
                    Save temp = allList[i];
                    allList[i] = allList[i + 1];
                    allList[i + 1] = temp;

                    isBubble = true;
                }
            }
        }
        while (isBubble);
    }
    public void clickRank(string name){
        AnalysisSingleton.instance.LoadAnaByJSON(name);

    }



}
