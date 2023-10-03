using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private int lives = 3;
    public GameObject basketPrefab;

    // Start is called before the first frame update
    void Start()
    {
        private float yOff = 2f;
        for(int i = 0; i < lives; i++) {
            GameObject basketLayer = Instantiate<GameObject>(basketPrefab, transform);
            Vector3 pos = basketLayer.transform.position;
            pos.y = -7f + yOff * i;
            basketLayer.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
}
