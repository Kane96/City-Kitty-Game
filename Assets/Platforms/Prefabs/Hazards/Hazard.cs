using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private MenuManager menuManager;

    void Start()
    {
        menuManager = GameObject.FindObjectOfType<MenuManager>().GetComponent<MenuManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            menuManager.setState("Lose");
        }
    }
}
