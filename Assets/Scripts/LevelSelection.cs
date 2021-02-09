using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter class
using System.IO;//FIle class and FileStream class

public class LevelSelection : MonoBehaviour
{

    [SerializeField] private bool unlocked;//Default value is false;
    public Image unlockImage;
    public GameObject[] stars;
    public GameObject SelectPlayingCanvas;

    public Sprite starSprite;

    private Dictionary<int, bool> dict = new Dictionary<int, bool>();


    //List<string> playingMode= new List<string>(){"Memorize","Copy"};
    //List<string> recordMode= new List<string>(){"Record","Practice"};

    private void Start()
    {
        LoadLevelByJSON(Singleton.instance.name);
        //PlayerPrefs.DeleteAll();
        UpdateLevelStatus();//TODO MOve this method later
        UpdateLevelImage();//TODO MOve this method later        
        //PopulateList();

    }

    private void Update()
    {
        
    }
        //MARKER JSON(STring) --> Object(Save Type)
    private void LoadLevelByJSON(string name)
    {
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
						dict[save.records[i].level]=save.records[i].win;
					}
				}
				else{
					dict.Add(save.records[i].level,save.records[i].win);
				}
			}
			
        }
    }


    private void UpdateLevelStatus()
    {
        //if the current lv is 5, the pre should be 4
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (dict.ContainsKey(previousLevelNum)){
            if (dict[previousLevelNum])//If the firts level star is bigger than 0, second level can play
            {
                unlocked = true;
            }
        }
        
    }

    private void UpdateLevelImage()
    {
        if(!unlocked)//MARKER if unclock is false means This level is clocked!
        {
            unlockImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else//if unlock is true means This level can play !
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            if (dict.ContainsKey(int.Parse(gameObject.name))){
                if(dict[int.Parse(gameObject.name)]){
                    for(int i = 0; i < 3; i++)
                    {
                        stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
                    }
                }

            }
        }
    }

    public void PressSelection(int level) //jump to the mode selection interface
    {
        if(unlocked)
        {
            Singleton.instance.level=level;
            //SelectPlayingCanvas.gameObject.SetActive(true);
            SceneManager.LoadScene("SelectMode");
        }
    }
	



}
