using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    private GameObject highScoreTxt;
    private int highScore = 0;

    void Awake()
    {
        

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        } else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject highScoreText = GameObject.Find("HighScore");
        highScoreText.GetComponent<TextMeshPro>().text = "High Score: " + highScore;
    }

    public int getHighScore()
    {
        return highScore;
    }

    public void setHighScore(int score)
    {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", score);
    }
}
