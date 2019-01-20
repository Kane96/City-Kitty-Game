using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public float xMinVelocity;
    public float xMaxVelocity;
    private float velocity;
    private Vector2 moveVelo;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        velocity = Random.Range(xMinVelocity, xMaxVelocity);
        moveVelo = new Vector2(velocity, 0);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = moveVelo;
    }
}
