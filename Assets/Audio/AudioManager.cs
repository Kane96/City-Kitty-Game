using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    private AudioSource audio;
    public PlayerPrefsManager playerPrefs;
    public Slider slider;

	void Start ()
    {
        audio = GetComponent<AudioSource>();
        slider.value = playerPrefs.getMasterVolume();
    }
	
	void Update ()
    {
        audio.volume = playerPrefs.getMasterVolume();
        print(audio.volume);
	}
}
