using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    public float platformToPlayerDistance;

    // The continuous velocity applied to the player 
    public float veloRight;
    public float veloJump;

    private float timer = 0;
    public float maxTimeInAir;
    public float multiplierFall;
    public float multiplierLowJump;

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
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rigidBody.velocity = Vector2.up * veloJump;
        }

        // Apply a snappier falling motion
        if (rigidBody.velocity.y < 0)
        {
            timer = 0;
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (multiplierFall - 1) * Time.deltaTime;
        }
        // Unless the spacebar is held, the player will descend 
        else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump") || timer > 0.15f)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (multiplierLowJump - 1) * Time.deltaTime;
        }

        if (rigidBody.velocity.y > 0)
        {
            timer += Time.deltaTime;
        }
    }

    public bool isGrounded()
    {
        // Is there a platform 0.35 units below the player on each end of the collider?
        // Bit shift to find the correct layer mask
        return (Physics2D.Linecast(transform.position, new Vector3(transform.position.x - 1f, transform.position.y - platformToPlayerDistance, 0), 1 << LayerMask.NameToLayer("Platform")) ||
        Physics2D.Linecast(transform.position, new Vector3(transform.position.x + 1f, transform.position.y - platformToPlayerDistance, 0), 1 << LayerMask.NameToLayer("Platform")));
    }
}
