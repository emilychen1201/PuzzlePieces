using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    //public Transform[] squares;
    private float timeUse = 0f;
    private List<bool> played = new List<bool> ();

    void TimeCount()
    {
        timeUse += Time.deltaTime;
    }
    public void Update()
    {
        TimeCount();
        for (var i=0;i<LevelSingleton.instance.shapesOrder.Count;i++){
            played.Add(false);
            if (!played[i]){
                RaycastHit2D kada = Physics2D.Raycast(new Vector2(LevelSingleton.instance.positionX[i], LevelSingleton.instance.positionY[i]), Vector2.zero);
                if (kada.collider != null){
                   if (kada.collider.tag==LevelSingleton.instance.shapesOrder[i]){              
                        AudioManager.instance.Play("kada");
                        played[i] = true;
                    } 
                }
                
            }
        }


    }
    public void Exit(){
        SceneManager.LoadScene("LevelMap");
    }
    
    public void OnClick()
    {
        Singleton.instance.time=Convert.ToInt32(timeUse);
        Singleton.instance.date=DateTime.Now.ToString("MM/dd/yyyy");
        var complete=true;
        for (var i=0;i<LevelSingleton.instance.shapesOrder.Count;i++){
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(LevelSingleton.instance.positionX[i], LevelSingleton.instance.positionY[i]), Vector2.zero);
            if (hit.collider != null){
                if (! (hit.collider.tag==LevelSingleton.instance.shapesOrder[i] && (hit.collider.transform.eulerAngles.z == LevelSingleton.instance.shapesAngle[i] || LevelSingleton.instance.shapesAngle[i] == -1))){
                    complete=false;
                }
            }
            else{
                complete=false;
            }
            
        }

        if (complete)
        {
            Singleton.instance.win=true;
            AudioManager.instance.Play("win");
            SceneManager.LoadScene("Win");         
            //Time.timeScale = 0f;
        }
        else{
            Singleton.instance.win=false;
            SceneManager.LoadScene("Lose");

        }
    }
}

