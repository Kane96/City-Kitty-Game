﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSky : MonoBehaviour {

    private Vector3 newPos;
    private Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
        newPos = new Vector3(camera.position.x, camera.position.y, 0);
        transform.position = newPos;
    }

    void Update ()
    {
        newPos = new Vector3(camera.position.x, camera.position.y, 0);
        transform.position = newPos;
	}
}
