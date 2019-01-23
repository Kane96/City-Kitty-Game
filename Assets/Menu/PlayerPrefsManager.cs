using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour {

    public float defaultAudio;

    void Start()
    {
        if (PlayerPrefs.GetInt("IsInitialised") == 0)
        {
            PlayerPrefs.SetFloat("MasterVolume", defaultAudio);
            PlayerPrefs.SetFloat("SFXVolume", defaultAudio);

            PlayerPrefs.SetInt("IsInitialised", 1);
        }
    }

    public float getHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore");
    }

    public void setHighScore(float newScore)
    {
        PlayerPrefs.SetFloat("HighScore", newScore);
    }

    public float getMusicVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume");
    }

    public void setMusicVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("MasterVolume", slider.value);
    }

    public float getSFXVolume()
    {
        return PlayerPrefs.GetFloat("SFXVolume");
    }

    public void setSFXVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("SFXVolume", slider.value);
    }
}
