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

        if (timer > 0.02f)
        {
            timer = 0;
            if (isStopped())
            {
                print("Player stopped, dead");
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
        if (playerTransform.position.x <= position + 0.1f && Time.timeSinceLevelLoad > 0.5f)
        {
            return true;
        }
        
        return false;
    }

    public void Die()
    {
        // Restart level
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("Segment")) 
        {
            //Debug.Log(game.name);
            //Debug.Log(game.transform.position);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
