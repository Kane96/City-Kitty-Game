using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSky : MonoBehaviour {

    public GameObject player;

    public float offset;

	void Update ()
    {
        Vector3 newPos = new Vector3(offset + player.transform.position.x, 0, 0);
        transform.position = newPos;
	}
}
