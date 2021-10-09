using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private Vector2 spawnDeltaTime;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float[] spawnDelayMultiplier;
    Coroutine spawnerCoroutine;

    void Start()
    {
        spawnerCoroutine = StartCoroutine(SpawnNewEnemy());
    }


    IEnumerator SpawnNewEnemy()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            int enemy = Random.Range(0, enemies.Length);

            float spawnDelay = Random.Range(spawnDeltaTime.x, spawnDeltaTime.y) * spawnDelayMultiplier[enemy];
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(enemies[enemy], transform.position, Quaternion.identity);
        }
    }
}
