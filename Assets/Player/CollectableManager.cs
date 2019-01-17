using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {

    public ScoreManager scoreManager;
    public float coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            GameObject collectable = collision.gameObject;
            collectable.GetComponent<AudioSource>().Play();
            collectable.GetComponent<SpriteRenderer>().enabled = false;
            collectable.GetComponent<BoxCollider2D>().enabled = false;
            scoreManager.addScore(coinValue);   
        }
    }
}
