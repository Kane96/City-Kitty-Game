using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [Tooltip("With the current player velocity values:\n" +
        "   veloJump = 20,\n   veloRight = 10,\n   maxTimeInAir = 0.2,\n   multiplierFall = 15,\n   multiplierLowJump = 15\n" +
        "Jumps 8 units apart on the same y axis are impossible, jumps 7 units apart are challenging, 6 somewhat challenging, etc.\n" + 
        "The first block MUST be in position x = 0 with consideration for the y position (lower is better).")]
    public float worldSpaceWidth;

    void Update()
    {
        if (transform.childCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}