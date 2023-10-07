using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {


    public GameObject applePrefab;
    public Camera mainCamera;
    public float boundary;
    private float dropRate = 1f;
    private float initVel = 10f;
    private float changeRate = 2f; // number of seconds before changing direction, on average

    // Start is called before the first frame update
    void Start() {
        mainCamera = Camera.main;
        boundary = mainCamera.orthographicSize * 16 / 9 - 1f; // half horizontal width of screen in unity
        Vector3 pos = transform.position;
        pos.x = Random.Range(-boundary + 2f, boundary - 2f);
        pos.y = mainCamera.orthographicSize - 4.5f;
        transform.position = pos;

        Invoke("dropApple", dropRate / 2);
        Invoke("attemptDirChange", 2f); // try to change the direction every 2 seconds, based on a % chance
    }

    // Update is called once per frame
    void Update() {

        Vector3 pos = transform.position;
        pos.x += initVel * Time.deltaTime;

        if (pos.x > boundary || pos.x < -boundary)
        {
            initVel *= -1;
        }

        if(pos.x > boundary)
        {
            pos.x = boundary - 0.001f;
        }

        if(pos.x < -boundary)
        {
            pos.x = -boundary + 0.001f;
        }

        transform.position = pos;

    }

    void dropApple() {
        if(Random.Range(0f, 1f) < 0.1)
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            apple.GetComponent<Rigidbody>().velocity = new Vector3(initVel, 0, 0);
        }
        
        Invoke("dropApple", dropRate * 0.1f);
    }

    void attemptDirChange()
    {
        if(Random.Range(0f, 1f) < 0.1)
        {
            initVel *= -1;
        }

        Invoke("attemptDirChange", changeRate / 10);
    }

    public void gameOver()
    {
        initVel = 0;
        CancelInvoke();
    }

}
