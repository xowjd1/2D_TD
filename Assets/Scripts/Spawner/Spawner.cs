using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnModes
{
    Fixed,
    Random
}

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private SpawnModes spawnMode = SpawnModes.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private GameObject testGO;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private float spawnTimer;
    private int enemiesSpawned;

    private ObjectPooler pooler;

    private void Start()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;  //+=로하든 -=로하든 차이는 없음
        if(spawnTimer < 0)
        {
            spawnTimer = GetSpawnDelay();
           
            if(enemiesSpawned < enemyCount)
            {
                enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }


    void SpawnEnemy()
    {
        GameObject newInstance = pooler.GetInstanceFromPool();
        newInstance.SetActive(true);
    }

    private float GetSpawnDelay()
    {
        float delay = 0f;
        if(spawnMode == SpawnModes.Fixed)
        {
            delay = delayBtwSpawns; // Fixed 일 때 정해진 수
        }
        else
        {
            delay = GetRandomDelay(); // 아니면 Random
        }

        return delay; // 안달아주면 오류걸림

    }

    float GetRandomDelay()
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);
        return randomTimer;
    }
}
