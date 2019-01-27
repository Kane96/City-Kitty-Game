using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    public GameObject[] easySegments;
    public GameObject[] normalSegments;
    public GameObject[] hardSegments;

    private GameObject currentSegment;

    // Difficulty is the gradually increasing index of the segments array.
    private int difficulty = 0;
    [Tooltip("In seconds")]
    public float difficultyIncreaseFreq;

    private float totalWidth;
    private float spawnAt;
    public float beginSpawningAt;

    private int random;

    private GameObject player;

	void Start ()
    {
        // Unity crashes when initialising arrays of gameobject arrays...

        player = GameObject.FindGameObjectWithTag("Player");
        getRandomSeg();
        spawnSegment();
	}

	void Update ()
    {
        int numberOfDifficulties = 3;
        Vector3 playerPos = player.GetComponent<Transform>().position;
        
        // If it's time to spawn a new level segment ahead of the player
        if (playerPos.x > spawnAt)
        {
            spawnSegment();
        }
        
        if (Time.time >= difficultyIncreaseFreq && !(difficulty >= numberOfDifficulties))
        {
            increaseDifficulty();
        }
	}

    public void spawnSegment()
    {
        GameObject current = Instantiate(currentSegment) as GameObject;
        float currentSegWidth = current.GetComponent<Segment>().worldSpaceWidth;
        current.transform.position = new Vector3(totalWidth + beginSpawningAt, 0, 0);
        totalWidth += currentSegWidth;

        spawnAt = totalWidth - 15;

        getRandomSeg();
    }

    public void getRandomSeg()
    {
        // Don't spawn the same segment twice in a row
        int randomTemp;
        GameObject[] temp = getRandomSegArray();
        do
        {
            randomTemp = Random.Range(0, temp.Length);
        } while (randomTemp == random);
        random = randomTemp;

        currentSegment = temp[random];
    }

    
    
    public GameObject[] getRandomSegArray()
    {
        
        int randomTemp = Random.Range(0, difficulty);
        switch (randomTemp)
        {
            case 0:
                return easySegments;
            case 1:
                return normalSegments;
            case 2:
                return hardSegments;
            default:
                print("Error finding a random segment!");
                return easySegments;
        }
        
        return easySegments;
    }
    
    
    public void increaseDifficulty()
    {
        difficultyIncreaseFreq += Time.time;
        difficulty++;
    }
    
}