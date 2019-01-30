using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float yPosDivideOffset;
    public float veloRight;
    public bool canMove;

    private Rigidbody2D rigidBody;
    private Vector2 moveVelo;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveVelo = new Vector2(veloRight, 0);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
            rigidBody.velocity = moveVelo;
        }
    }

    void Update()
    {
        if (!canMove)
        {
            float ypos =  Camera.main.transform.position.y / yPosDivideOffset;
            transform.position = new Vector3(Camera.main.transform.position.x, ypos, 0);
        }
    }
}
