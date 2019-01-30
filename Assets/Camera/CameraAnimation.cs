using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {

    public MenuManager menuManager;

    public void startAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("HasStarted", true);
    }

    public void setAnimationFinish()
    {
        menuManager.setState("Idle");
    }
}
