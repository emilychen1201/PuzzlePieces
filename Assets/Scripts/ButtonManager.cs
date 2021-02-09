using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	public void OnClickStudent(){
		SceneManager.LoadScene("SelectName");
	}
	public void OnClickName(){
		SceneManager.LoadScene("LevelMap");
	}
	public void OnClickTeacher(){
        SceneManager.LoadScene("RankingList");
    }
	public void OnClickExit(){
        Application.Quit();
    }
	public void OnClickBack(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
	public void OnClickNext(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
	public void OnClickRankBack(){
        SceneManager.LoadScene("FirstPage");
    }
	
}
