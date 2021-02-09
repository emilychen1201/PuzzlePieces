

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedTable : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        
        int listNum=0;
        foreach (OneRecord record in AnalysisSingleton.instance.records){
            CreateHighscoreEntryTransform(record, listNum);
            listNum += 1;
        }



        
    }

    private void CreateHighscoreEntryTransform(OneRecord record, int ListNum) {
        float templateHeight = 21f;
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * ListNum);
        entryTransform.gameObject.SetActive(true);

        string date = record.date;

        entryTransform.Find("dateText").GetComponent<Text>().text = date;

        int level = record.level;

        entryTransform.Find("levelText").GetComponent<Text>().text = level.ToString();

        int time = record.time;

        entryTransform.Find("timeText").GetComponent<Text>().text = time.ToString();

        string mode = record.mode;

        entryTransform.Find("modeText").GetComponent<Text>().text = mode;

        string win; 
        if (record.win){
            win = "ganar";
        }
        else{
            win = "fallar";
        }

        entryTransform.Find("failureText").GetComponent<Text>().text = win;

        // Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(ListNum % 2 == 1);

    }

  


}
