using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public static spawnManager Instance {  get; private set; }


    public float spawnRange = 20f;
    public float ySpawn;

    [Header("Prefabs")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;

    [Header("Enemies")]
    public int totalEnemies;
    public int wave = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    
    void Start()
    {
        SpawnEnemy(totalEnemies);

    }

    // Update is called once per frame
    void Update()
    {
        totalEnemies = FindObjectsOfType<enemyScript>().Length;
        if (totalEnemies == 0)
        {
            wave++;

            if (wave % 5 == 0 && wave != 0)
            {
                int extraBossCount = wave / 5;
                for (int i = 0; i < extraBossCount; i++)
                {
                    SpawnBoss();
                }
            }
            else
            {
                SpawnEnemy(wave);
            }
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 6.8f, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    void SpawnBoss()
    {
        Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
    }
}

