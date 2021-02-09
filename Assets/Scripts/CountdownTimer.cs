using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startTime = 59f;
    [SerializeField] Text CountDownText;
    [SerializeField] Text Timer;
    Color CuteRed = new Color(0.9882f, 0.2352f, 0.3372f, 1f);
    void Start()
    {
        
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime>0)
        {
        currentTime -= 1 * Time.deltaTime;
        CountDownText.text = "00:"+currentTime.ToString ("0");
            if(currentTime<6)
            {
                CountDownText.color = CuteRed;
                Timer.color = CuteRed;
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }


        
        
    }
}