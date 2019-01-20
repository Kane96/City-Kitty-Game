using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {

    public Transform playerTransform;
    public float xOffset;

    public GameObject cloud;
    public float minSpawnHeight;
    public float maxSpawnHeight;

    public float intervalSeconds;
    private float nextSpawnTime;
    public float spawnChancePercent;

    void Start ()
    {
        nextSpawnTime = intervalSeconds;
	}
	
	void Update ()
    {
		if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + intervalSeconds;
            if (Random.Range(0, 100) <= spawnChancePercent)
            {
                spawnCloud();
            }
        }
	}

    private void spawnCloud()
    {
        float yPosSpawn = Random.Range(minSpawnHeight, maxSpawnHeight);
        Vector3 spawnLocation = new Vector3(playerTransform.position.x + xOffset, yPosSpawn, 0);

        Instantiate(cloud, spawnLocation, Quaternion.identity);
    }
}
