using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public void loadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
