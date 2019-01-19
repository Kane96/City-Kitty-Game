using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public static AudioManager audioManager;
    private AudioSource musicAudio;

    private PlayerPrefsManager playerPrefs;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start ()
    {
        // Only one instance of AudioManager
        if (!audioManager)
        {
            audioManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Will be destroyed on load if this object has a parent without DontDestroyOnLoad
        gameObject.transform.parent = null;
        DontDestroyOnLoad(gameObject);

        playerPrefs = GameObject.FindObjectOfType<PlayerPrefsManager>().GetComponent<PlayerPrefsManager>();
        musicAudio = GetComponent<AudioSource>();
        musicSlider.value = playerPrefs.getMusicVolume();
        sfxSlider.value = playerPrefs.getSFXVolume();
    }

    void Update ()
    {
        musicAudio.volume = playerPrefs.getMusicVolume();
	}
}
