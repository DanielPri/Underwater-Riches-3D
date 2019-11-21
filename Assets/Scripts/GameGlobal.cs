using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
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
    public int level = 1;

    public float elapsedLevelTime = 0f;

    void Start()
    {
        activePlayer = GameObject.Find("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        updateLevel();
    }

    public void respawn()
    {
        if (lives > 0)
        {
            StartCoroutine(waitAndRespawnAfter(2f));
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void updateLevel()
    {
        if(elapsedLevelTime >= levelDuration)
        {
            level++;
            elapsedLevelTime = 0f;
        }
        elapsedLevelTime += Time.deltaTime;
    }

    IEnumerator waitAndRespawnAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        activePlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    public void restart()
    {
        SceneManager.LoadScene("LevelCube");
    }
}
