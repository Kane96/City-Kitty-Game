using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{

    public GameObject[] segments;
    public GameObject currentSegment;
    public float totalWidth;
    public float spawnAt;

    private GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnSegment();
	}

	void Update ()
    {
        Vector3 playerPos = player.GetComponent<Transform>().position;
        
        // If it's time to spawn a new level segment ahead of the player
        if (playerPos.x > spawnAt)
        {
            spawnSegment();
        }
	}

    public void spawnSegment()
    {
        GameObject current = Instantiate(currentSegment) as GameObject;
        float currentSegWidth = current.GetComponent<Segment>().worldSpaceWidth;
        totalWidth += currentSegWidth;
        current.transform.position = new Vector3(totalWidth, 0, 0);
        
        spawnAt = totalWidth - (currentSegWidth / 2);
    }
}