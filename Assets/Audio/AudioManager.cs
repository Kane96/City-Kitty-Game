using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public static AudioManager audioManager;
    private AudioSource audio;

    private PlayerPrefsManager playerPrefs;
    public Slider slider;

    void Start ()
    {
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

        audio = GetComponent<AudioSource>();
        slider.value = playerPrefs.getMasterVolume();
    }
	
	void Update ()
    {
        audio.volume = playerPrefs.getMasterVolume();
	}
}
