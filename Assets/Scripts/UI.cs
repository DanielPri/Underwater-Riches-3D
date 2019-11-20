using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameGlobal globalData;

    TextMeshProUGUI score;
    TextMeshProUGUI lives;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponentsInChildren<TextMeshProUGUI>()[0];
        lives = GetComponentsInChildren<TextMeshProUGUI>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText("score: " + globalData.score);
        lives.SetText("lives: " + globalData.lives);
    }
}

