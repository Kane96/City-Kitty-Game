using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private Transform playerTransform;
    private float timer = 0;
    private float position;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.1f)
        {
            timer = 0;
            if (isStopped())
            {
                Die();
            }
            else
            {
                position = playerTransform.position.x;
            }
        }

        if (playerTransform.position.y <= -6)
        {
            Die();
        }
    }

    private bool isStopped()
    {
        if (playerTransform.position.x <= position)
        {
            return true;
        }
        
        return false;
    }

    public void Die()
    {
        // Restart level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
