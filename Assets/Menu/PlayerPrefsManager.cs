using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    public float getHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore");
    }

    public void setHighScore(float newScore)
    {
        PlayerPrefs.SetFloat("HighScore", newScore);
    }

    public float getMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume");
    }

    public void setMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
