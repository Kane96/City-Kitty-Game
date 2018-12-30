using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float veloRight;
    public float veloJump;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        Vector2 moveVelo = rigidBody.velocity;
        moveVelo.x = veloRight;
        rigidBody.velocity = moveVelo;

        print(rigidBody.velocity);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print("Jumping!");
            rigidBody.velocity = Vector2.up * veloJump;
        }
    }
}
