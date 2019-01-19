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
    }

    void Update()
    {
        score += 10f * Time.deltaTime;
        scoreText.text = ((int)score).ToString();

        highScore = playerPrefsManager.getHighScore();
        highScoreText.text = ((int)highScore).ToString();
        if (score > highScore)
        {
            playerPrefsManager.setHighScore(score);
        }
    }

    public void addScore(float value)
    {
        score += value;
    }
}
