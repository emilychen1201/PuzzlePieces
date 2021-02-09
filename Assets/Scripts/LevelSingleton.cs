using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSingleton : MonoBehaviour
{
    public static LevelSingleton instance;
	public int template;
	public List<float> positionX= new List<float>();
	public List<float> positionY= new List<float>();
	public List<string> shapesOrder= new List<string>();
	public List<int> shapesAngle= new List<int>();

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

}

