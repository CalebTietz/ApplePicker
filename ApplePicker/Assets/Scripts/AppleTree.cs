using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {


    public GameObject applePrefab;
    public float boundary;
    public float dropRate;
    public float initVel;
    public float changeRate;

    // Start is called before the first frame update
    void Start() {
        boundary = 3f;
        initVel = 1f;
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        pos.x += initVel * Time.deltaTime;

        if(pos.x >= boundary || pos.x < -boundary) { 
            initVel *= -1;
        }

        transform.position = pos;

    }
}
