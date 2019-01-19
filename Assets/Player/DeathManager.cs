using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public MenuManager menuManager;
    public AudioSource audio;

    public bool isDead = false;

    private Transform playerTransform;
    private float timer = 0;
    private float position;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isDead)
        {
            timer += Time.deltaTime;

            if (timer > 0.02f)
            {
                timer = 0;
                if (isStopped())
                {
                    print("Player stopped, dead");
                    die();
                }
                else
                {
                    position = playerTransform.position.x;
                }
            }

            if (playerTransform.position.y <= -6)
            {
                die();
            }
        }
    }

    private bool isStopped()
    {
        if (playerTransform.position.x <= position + 0.1f && Time.timeSinceLevelLoad > 0.5f)
        {
            return true;
        }
        
        return false;
    }

    public void die()
    {
        isDead = true;
        audio.Play();
        menuManager.setState("Lose");
    }
}
