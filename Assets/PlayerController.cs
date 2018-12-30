using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public bool isGrounded;

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

        print(rigidBody.velocity.magnitude);
    }

    void Update()
    {
        isGrounded = Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - 0.35f, 0), 1 << LayerMask.NameToLayer("Platform"));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            print("Jumping!");
            rigidBody.velocity = Vector2.up * veloJump;
        }
    }
}
