using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float veloRight;

    private Rigidbody2D rigidBody;
    private Vector2 moveVelo;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveVelo = new Vector2(veloRight, 0);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = moveVelo;
    }
}
