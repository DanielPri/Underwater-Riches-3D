using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    [SerializeField]
    GameGlobal globalData;

    [SerializeField]
    List<GameObject> goldbarPrefabs;

    [SerializeField]
    GameObject testPoint;

    float goldFrequency;
    float elapsedDuration;

    Terrain terrain;
    float terrainMinX;
    float terrainMaxX;
    float terrainMinZ;
    float terrainMaxZ;

    // Start is called before the first frame update
    void Start()
    {
        this.goldFrequency = globalData.goldFrequency;
        elapsedDuration = 0f;

        terrain = GetComponent<Terrain>();
        terrainMinX = terrain.transform.position.x;
        terrainMaxX = terrain.terrainData.size.x + terrainMinX;
        terrainMinZ = terrain.transform.position.z;
        terrainMaxZ = terrain.terrainData.size.z + terrainMinZ;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateGold();
    }

    private void GenerateGold()
    {
        if (elapsedDuration > goldFrequency)
        {
            int prefabToSpawn = UnityEngine.Random.Range(0, goldbarPrefabs.Count);
            float randomX = UnityEngine.Random.Range(terrainMinX, terrainMaxX);
            float randomZ = UnityEngine.Random.Range(terrainMinZ, terrainMaxZ);
            float heightY = Terrain.activeTerrain.SampleHeight(new Vector3(randomX, 0, randomZ));
            Instantiate(goldbarPrefabs[prefabToSpawn], new Vector3(randomX, heightY - 95, randomZ),Quaternion.identity);

            elapsedDuration = 0f;
        }
        elapsedDuration += Time.deltaTime;
    }
}
