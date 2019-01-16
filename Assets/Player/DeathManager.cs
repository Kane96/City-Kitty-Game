using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public MenuManager menuManager;

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
                menuManager.setState("Lose");
            }
            else
            {
                position = playerTransform.position.x;
            }
        }

        if (playerTransform.position.y <= -6)
        {
            menuManager.setState("Lose");
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
}
