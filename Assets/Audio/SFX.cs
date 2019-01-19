using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

    private PlayerPrefsManager playerPrefs;
    private AudioSource audio;

    void Start ()
    {
        playerPrefs = GameObject.FindObjectOfType<PlayerPrefsManager>().GetComponent<PlayerPrefsManager>();
        audio = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        audio.volume = playerPrefs.getSFXVolume();
	}
}
