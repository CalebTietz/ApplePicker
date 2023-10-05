using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private float boundary = -12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < boundary) {
            Destroy(gameObject);

            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().AppleMissed();
        }
    }
}
