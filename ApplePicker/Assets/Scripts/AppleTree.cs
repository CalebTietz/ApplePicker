using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {


    public GameObject applePrefab;
    public Camera mainCamera;
    public float boundary;
    public float dropRate;
    public float initVel = 1f;
    public float changeRate;

    private Renderer treeRenderer;

    // Start is called before the first frame update
    void Start() {
        mainCamera = Camera.main;
        treeRenderer = GetComponent<Renderer>();
        Vector3 treeSize = treeRenderer.bounds.size;
        boundary = mainCamera.orthographicSize * 16 / 9; // half horizontal width of screen in unity
        Vector3 pos = transform.position;
        pos.x = Random.Range(-boundary + treeSize.x / 2, boundary - treeSize.x / 2);
        pos.y = mainCamera.orthographicSize - treeRenderer.bounds.size.y / 2;
        transform.position = pos;
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
