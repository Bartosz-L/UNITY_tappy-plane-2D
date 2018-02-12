using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().volume = 0.2f;
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = false;

        FindObjectOfType<PointsCounter>().IncrementPoints();

        Destroy(gameObject, 3f);
    }

}
