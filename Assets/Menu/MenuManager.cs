using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public enum State {Start, Idle, Pause, Settings, Lose};
    private State currentState = State.Idle;

    public GameObject pauseUI;
    public GameObject settingsUI;
    public GameObject loseUI;
    public GameObject startUI;

    private static bool firstLoad = true;

    void Start()
    {
        if (firstLoad)
        {
            currentState = State.Start;
            firstLoad = false;
        }
    }

	void Update ()
    {
        switch (currentState)
        {
            case State.Start:
                startUI.SetActive(true);
                Time.timeScale = 0;
                break;

            case State.Idle:
                pauseUI.SetActive(false);
                settingsUI.SetActive(false);
                loseUI.SetActive(false);
                startUI.SetActive(false);
                Time.timeScale = 1;
                break;

            case State.Pause:
                Time.timeScale = 0;
                settingsUI.SetActive(false);
                pauseUI.SetActive(true);
                break;

            case State.Settings:
                pauseUI.SetActive(false);
                settingsUI.SetActive(true);
                break;

            case State.Lose:
                loseUI.SetActive(true);
                Time.timeScale = 0;
                break;
        }

		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == State.Idle)
            {
                currentState = State.Pause;
            }
            else if (currentState == State.Pause)
            {
                currentState = State.Idle;
            }
            else if (currentState == State.Settings)
            {
                currentState = State.Idle;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == State.Pause || currentState == State.Start)
            {
                currentState = State.Idle;
            }
            else if (currentState == State.Lose)
            {
                reset();
            }
        }
	}

    public void setState(string newState)
    {
        currentState = (State)System.Enum.Parse(typeof(State), newState);
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentState = State.Idle;
    }
}
