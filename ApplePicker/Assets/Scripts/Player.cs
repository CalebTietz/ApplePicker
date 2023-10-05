using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int lives = 3;
    public GameObject basketPrefab;
    private List<GameObject> basketList = new List<GameObject>();
    private int topBasketLayerIndex = lives - 1;

    // Start is called before the first frame update
    void Start()
    {
        float yOff = 1f;
        float yBot = -8f;
        for(int i = 0; i < lives; i++) {
            GameObject basketLayer = Instantiate<GameObject>(basketPrefab, transform);
            Vector3 pos = basketLayer.transform.position;
            pos.y = yBot + yOff * i;
            basketLayer.transform.position = pos;
            basketList.Add(basketLayer);
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

    public void AppleMissed()
    {
        if(topBasketLayerIndex >= 0)
        {
            Destroy(basketList[topBasketLayerIndex]);
            topBasketLayerIndex--;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
