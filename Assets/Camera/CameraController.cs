using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 currentPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        currentPos = new Vector3(player.transform.position.x + 6, 0, -10);
        gameObject.transform.position = currentPos;
	}
}
