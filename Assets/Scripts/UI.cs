using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameGlobal globalData;

    TextMeshProUGUI score;
    TextMeshProUGUI lives;
    TextMeshProUGUI level;
    GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponentsInChildren<TextMeshProUGUI>()[0];
        lives = GetComponentsInChildren<TextMeshProUGUI>()[1];
        level = GetComponentsInChildren<TextMeshProUGUI>()[2];
        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText("score: " + globalData.score);
        lives.SetText("lives: " + globalData.lives);
        level.SetText("level: " + globalData.level);
        handleGameOver();
    }

    private void handleGameOver()
    {
        if(globalData.lives == 0)
        {
            GameOver.SetActive(true);
        }
    }
}

