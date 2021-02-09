using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {

	public AudioMixer mixer;
	Slider volumeSlider;
	public void Start(){
		volumeSlider=gameObject.GetComponent<Slider>();
		if (PlayerPrefs.HasKey("MainVolume")){
			volumeSlider.value=PlayerPrefs.GetFloat("MainVolume");
		}
		
	}
	public void setVolume(float sliderValue){
		PlayerPrefs.SetFloat("MainVolume", sliderValue);
		mixer.SetFloat("MainVolume", Mathf.Log10 (sliderValue) * 20);

	}
	
}
