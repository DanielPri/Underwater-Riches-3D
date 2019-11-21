using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameGlobal globalData;

    [SerializeField]
    GameObject testObject;

    [SerializeField]
    GameObject shark;

    [SerializeField]
    GameObject octopus;
    
    [SerializeField]
    float maxY = -5f;
    [SerializeField]
    float minY = -70f;
    [SerializeField]
    float maxZ = 55f;
    [SerializeField]
    float minZ = -55f;

    float sharkFrequency;
    float octopusFrequency;
    float elapsedTimeShark;
    float elapsedTimeOctopus;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(testObject, new Vector3(transform.position.x, maxY, maxZ), Quaternion.identity);
        Instantiate(testObject, new Vector3(transform.position.x, maxY, minZ), Quaternion.identity);
        Instantiate(testObject, new Vector3(transform.position.x, minY, maxZ), Quaternion.identity);
        Instantiate(testObject, new Vector3(transform.position.x, minY, minZ), Quaternion.identity);
        sharkFrequency = globalData.sharkFrequncy;
        elapsedTimeShark = sharkFrequency;

        octopusFrequency = globalData.levelDuration / 2f;
        elapsedTimeOctopus = octopusFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        generateShark();
        generateOctopus();
    }

    private void generateOctopus()
    {
        if (elapsedTimeOctopus > octopusFrequency)
        {
            float randomY = UnityEngine.Random.Range(minY, maxY);
            float randomZ = UnityEngine.Random.Range(minZ, maxZ);
            Instantiate(octopus, new Vector3(transform.position.x, randomY, randomZ), transform.rotation);
            elapsedTimeOctopus = 0f;
        }
        elapsedTimeOctopus += Time.deltaTime;
    }

    private void generateShark()
    {
        if (elapsedTimeShark > sharkFrequency)
        {
            float randomY = UnityEngine.Random.Range(minY, maxY);
            float randomZ = UnityEngine.Random.Range(minZ, maxZ);
            Instantiate(shark, new Vector3(transform.position.x, randomY, randomZ), transform.rotation);
            elapsedTimeShark = 0f;
        }
        elapsedTimeShark += Time.deltaTime;
    }
}
