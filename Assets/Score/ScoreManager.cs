using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private float score;
    private float highScore;

    public Text scoreText;
    public Text highScoreText;

    private PlayerPrefsManager playerPrefsManager;

    void Start()
    {
        playerPrefsManager = GameObject.FindObjectOfType<PlayerPrefsManager>().GetComponent<PlayerPrefsManager>();
        highScore = playerPrefsManager.getHighScore();
        highScoreText.text = ((int)highScore).ToString();
    }

    void Update()
    {
        score += 10f * Time.deltaTime;
        scoreText.text = ((int)score).ToString();

        if (score > highScore)
        {
            updateHighScore();
        }
    }

    public void updateHighScore()
    {
        highScore = score;
        highScoreText.text = ((int)highScore).ToString();
        playerPrefsManager.setHighScore(highScore);
    }

    public void addScore(float value)
    {
        score += value;
    }
}
