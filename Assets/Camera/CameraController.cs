using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool canMove;
    private bool animationFinished = false;

    public MenuManager menuManager;
    private GameObject player;
    private Vector3 currentPos;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        if (menuManager.currentState == MenuManager.State.Idle)
        {
            animator.enabled = false;
            currentPos = new Vector3(player.transform.position.x + 6, 0, -10);
            gameObject.transform.position = currentPos;
        }
	}

    public void startAnimation()
    {
        animator.SetBool("HasStarted", true);
    }

    public void setAnimationFinish()
    {
        menuManager.setState("Idle");
    }
}
