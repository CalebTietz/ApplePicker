using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private float yBoundary = -12f;
    private float xBoundary;
    // Start is called before the first frame update
    void Start()
    {
        xBoundary = Camera.main.orthographicSize * 16 / 9 + 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yBoundary) {
            Destroy(gameObject);

            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().AppleMissed();
        }

        if (Mathf.Abs(transform.position.x) > xBoundary && transform.position.y > yBoundary + 5f)
        {
            Destroy(gameObject);
        }
    }
}
