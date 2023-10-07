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
        xBoundary = Camera.main.orthographicSize * 16 / 9 + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yBoundary) {
            Destroy(gameObject);

            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().AppleMissed();
        }

        float? basketTopY = GameObject.Find("Player").GetComponent<Player>().getBasketTopY();
        if (basketTopY == null) return;
        if (Mathf.Abs(transform.position.x) > xBoundary && transform.position.y > basketTopY)
        {
            Destroy(gameObject);
        }
    }
}
