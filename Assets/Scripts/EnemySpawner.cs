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
    float maxY = -5f;
    [SerializeField]
    float minY = -70f;
    [SerializeField]
    float maxZ = 55f;
    [SerializeField]
    float minZ = -55f;

    float sharkFrequency;
    float elapsedTimeShark;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(testObject, new Vector3(transform.position.x, maxY, maxZ), Quaternion.identity);
        Instantiate(testObject, new Vector3(transform.position.x, maxY, minZ), Quaternion.identity);
        Instantiate(testObject, new Vector3(transform.position.x, minY, maxZ), Quaternion.identity);
        Instantiate(testObject, new Vector3(transform.position.x, minY, minZ), Quaternion.identity);
        sharkFrequency = globalData.sharkFrequncy;
        elapsedTimeShark = sharkFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        generateShark();
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
        Debug.Log(elapsedTimeShark);
    }
}
