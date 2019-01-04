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

    void Start()
    {
        highScore = getHighScore();
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
        saveHighScore(highScore);
    }

    public float getHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore");
    }

    public void saveHighScore(float newScore)
    {
        PlayerPrefs.SetFloat("HighScore", newScore);
    }
}
