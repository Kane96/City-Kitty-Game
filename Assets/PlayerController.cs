using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float forceRight;
    public float veloLimitRight;

    public float jumpingForce;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        if (!(rigidBody.velocity.x > veloLimitRight))
        {
            rigidBody.AddForce(Vector3.right * forceRight, ForceMode2D.Force);
        }

        print(rigidBody.velocity);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print("Jumping!");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingForce);
        }
    }
}
