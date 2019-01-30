using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public GameObject background;
    public float backgroundWidth;

    public float totalWidth = 0;

    private float spawnAt;
    public GameObject player;

    public float yOffset = -1.4f;

	void Start ()
    {
        SpriteRenderer sprite = background.GetComponent<SpriteRenderer>();
        backgroundWidth = sprite.bounds.size.x;
    }
	
	void Update ()
    {
		if (player.transform.position.x >= spawnAt) 
        {
            addBackground();
        }
	}

    private void addBackground()
    {
        Vector3 newPos = new Vector3(totalWidth, yOffset, 0);
        Instantiate(background, newPos, Quaternion.identity);
        totalWidth += backgroundWidth;
        spawnAt = totalWidth - 30;
    }
}
