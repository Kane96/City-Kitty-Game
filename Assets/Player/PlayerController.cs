using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    public float platformToPlayerDistance;
    public bool isGrounded;

    // The continuous velocity applied to the player 
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
    }

    void Update()
    {
        // Is there a platform 0.35 units below the player on each end of the collider?
        // Bit shift to find the correct layer mask
        if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x - 1.2f, transform.position.y - platformToPlayerDistance, 0), 1 << LayerMask.NameToLayer("Platform"))  ||
            Physics2D.Linecast(transform.position, new Vector3(transform.position.x + 1.2f, transform.position.y - platformToPlayerDistance, 0), 1 << LayerMask.NameToLayer("Platform")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidBody.velocity = Vector2.up * veloJump;
        }
    }
}
