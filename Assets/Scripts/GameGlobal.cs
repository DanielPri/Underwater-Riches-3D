using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameGlobal : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    GameObject activePlayer;
    //GameObject thirdPersonCamera;

    public float levelDuration = 60f;
    public float goldFrequency = 20f;
    public float sharkFrequncy = 10f;
    public float velocity;
    public int score = 0;
    public int lives = 2;

    void Start()
    {
        activePlayer = GameObject.Find("Player");
    }

    public void respawn()
    {
        StartCoroutine(waitAndRespawnAfter(2f));
    }


    IEnumerator waitAndRespawnAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        activePlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
