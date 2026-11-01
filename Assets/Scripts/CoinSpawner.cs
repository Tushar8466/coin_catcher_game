using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Spawns random items (coins/bombs) across the top of the screen at intervals.
/// </summary>
public class CoinSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableItem
    {
        public GameObject prefab;
        [Range(0, 100)] public int spawnWeight;
    }

    [Header("Spawn Settings")]
    [SerializeField] private List<SpawnableItem> spawnList;
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float maxSpawnInterval = 2.0f;
    [SerializeField] private float spawnHeight = 6f;

    private float timer;
    private float nextSpawnTime;

    private void Start()
    {
        CalculateNextSpawn();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            SpawnItem();
            CalculateNextSpawn();
            timer = 0;
        }
    }

    private void CalculateNextSpawn()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void SpawnItem()
    {
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);

        // Weighted spawn selection
        int totalWeight = 0;
        foreach (var item in spawnList) totalWeight += item.spawnWeight;

        int randomWeight = Random.Range(0, totalWeight);
        int currentWeight = 0;

        foreach (var item in spawnList)
        {
            currentWeight += item.spawnWeight;
            if (randomWeight < currentWeight)
            {
                Instantiate(item.prefab, spawnPos, Quaternion.identity);
                break;
            }
        }
    }
}
