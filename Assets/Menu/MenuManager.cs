using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pauseUI;
    public GameObject settingsUI;

    void Start()
    {
        pauseUI.SetActive(false);
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pause();
            }
            else
            {
                unpause();
            }
        }
	}

    public void pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseUI.SetActive(true);
    }

    public void unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseUI.SetActive(false);
    }

    public void pauseToSettings()
    {
        pauseUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void settingsToPause()
    {
        settingsUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        unpause();
    }
}
