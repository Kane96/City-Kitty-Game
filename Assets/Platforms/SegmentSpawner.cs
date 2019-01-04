using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{

    public GameObject[] segments;
    public GameObject currentSegment;

    public float totalWidth;
    public float spawnAt;
    public float beginSpawningAt;

    private GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        getRandomSeg();
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
        //TODO: delete segments when they leave the screen

        GameObject current = Instantiate(currentSegment) as GameObject;
        float currentSegWidth = current.GetComponent<Segment>().worldSpaceWidth;
        current.transform.position = new Vector3(totalWidth + beginSpawningAt, 0, 0);
        totalWidth += currentSegWidth;

        spawnAt = totalWidth - 15;

        getRandomSeg();
    }

    public void getRandomSeg()
    {
        // TODO: don't spawn the same segment twice in a row
        int random = Random.Range(0, segments.Length);
        currentSegment = segments[random];
    }
}