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
            scoreManager.addScore(coinValue);
            Destroy(collision.gameObject);
        }
    }
}
