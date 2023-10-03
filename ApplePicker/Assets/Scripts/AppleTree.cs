using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {


    public GameObject applePrefab;
    public Camera mainCamera;
    public float boundary;
    private float dropRate;
    private float initVel = 2f;
    public float changeRate;

    // Start is called before the first frame update
    void Start() {
        mainCamera = Camera.main;
        boundary = mainCamera.orthographicSize * 16 / 9; // half horizontal width of screen in unity
        Vector3 pos = transform.position;
        pos.x = Random.Range(-boundary + 1, boundary - 1);
        pos.y = mainCamera.orthographicSize - 2.5f;
        transform.position = pos;
        dropRate = 2f;

        Invoke("dropApple", dropRate / 2);
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

    void dropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        
        Invoke("dropApple", dropRate);
    }
}
