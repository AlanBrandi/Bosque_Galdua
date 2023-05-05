using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRockRain : MonoBehaviour
{
    public GameObject prefab;
    private Collider2D spawnArea;
    public float spawnDelay = 0.5f;
    public float spawnDuration = 10f;

    public float spawnTimer = 0f;
    public float durationTimer = 0f;
    public bool isSpawning = true;

    private void Start()
    {
        spawnArea = GetComponent<Collider2D>();
        StartCoroutine(SpawnRocks());
    }

    public IEnumerator SpawnRocks()
    {
        while (isSpawning && durationTimer < spawnDuration)
        {
            spawnTimer += Time.deltaTime;
            durationTimer += Time.deltaTime;

            if (spawnTimer >= spawnDelay)
            {
                spawnTimer = 0f;

                Vector3 spawnPosition = new Vector3(
                    Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                    Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                    0f
                );
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }

            yield return null;
        }
        isSpawning = false;
    }
}
