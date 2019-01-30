using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public enum State {Start, CamStartAnim, Idle, Pause, Settings, Lose, ResetScoreConfirm};
    public State currentState = State.Idle;

    public PlayerController player;
    public ScoreManager score;
    public Text[] scoreText;
    public CameraController camera;

    public GameObject pauseUI;
    public GameObject settingsUI;
    public GameObject loseUI;
    public GameObject startUI;
    public GameObject resetScoreUI;

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
                toggleStart(false);
                break;

            case State.CamStartAnim:
                startUI.SetActive(false);
                camera.startAnimation();
                break;

            case State.Idle:
                toggleStart(true);
                pauseUI.SetActive(false);
                settingsUI.SetActive(false);
                loseUI.SetActive(false);
                Time.timeScale = 1;
                break;

            case State.Pause:
                Time.timeScale = 0;
                settingsUI.SetActive(false);
                pauseUI.SetActive(true);
                break;

            case State.Settings:
                pauseUI.SetActive(false);
                resetScoreUI.SetActive(false);
                settingsUI.SetActive(true);
                break;

            case State.ResetScoreConfirm:
                settingsUI.SetActive(false);
                resetScoreUI.SetActive(true);
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
            if (currentState == State.Start)
            {
                currentState = State.CamStartAnim;
            }
            else if (currentState == State.Pause)
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

    public void toggleStart(bool canStart)
    {
        player.canMove = canStart;
        score.enabled = canStart;
        foreach (GameObject background in GameObject.FindGameObjectsWithTag("Background Buildings"))
        {
            background.GetComponent<Background>().canMove = canStart;
        }
        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].enabled = canStart;
        }
    }
}
