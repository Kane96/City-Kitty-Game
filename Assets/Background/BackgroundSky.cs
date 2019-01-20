using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSky : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	void Start ()
    {
        offset = transform.position;
	}
	void Update ()
    {
        Vector3 newPos = new Vector3(offset.x + player.transform.position.x, offset.y, 0);
        transform.position = newPos;
	}
}
