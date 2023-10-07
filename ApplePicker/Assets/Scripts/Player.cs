using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private static int lives = 3;
    public GameObject basketPrefab;
    private List<GameObject> basketList = new List<GameObject>();
    private int topBasketLayerIndex = lives - 1;
    private float boundary;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.orthographicSize * 16 / 9 - 1.5f;
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
        //update score
        GameObject scoreTxt = GameObject.Find("Score");
        scoreTxt.GetComponent<TextMeshPro>().text = "Score: " + score;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        if(pos.x > boundary)
        {
            pos.x = boundary;
        }
        if(pos.x < -boundary)
        {
            pos.x = -boundary;
        }
        this.transform.position = pos;
    }

    public void AppleMissed()
    {
        if(topBasketLayerIndex == 0)
        { // game over
            GameObject appleTree = GameObject.Find("Tree");
            appleTree.GetComponent<AppleTree>().gameOver();

            Invoke("restart", 1f);
        }
        if(topBasketLayerIndex >= 0)
        {
            Destroy(basketList[topBasketLayerIndex]);
            topBasketLayerIndex--;
        }
    }

    void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void increaseScore(int inc)
    {
        score += inc;
        GameObject highScore = GameObject.Find("HighScore");

        if(score > highScore.GetComponent<HighScore>().getHighScore())
        {
            highScore.GetComponent<HighScore>().setHighScore(score);
        }
    }

    public float? getBasketTopY()
    {
        if(topBasketLayerIndex >= 0) return basketList[topBasketLayerIndex].transform.position.y - 0.25f;
        return null;
    }
}
