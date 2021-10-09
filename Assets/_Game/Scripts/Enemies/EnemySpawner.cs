using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private Vector2 spawnDeltaTime;
    [SerializeField] private GameObject enemy;
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
            yield return new WaitForSeconds(Random.Range(spawnDeltaTime.x, spawnDeltaTime.y));
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
