using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioManager : MonoBehaviour {

	// Use this for initialization
	public static MainAudioManager instance;
	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
