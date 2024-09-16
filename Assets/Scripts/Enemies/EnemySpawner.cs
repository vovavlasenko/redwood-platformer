using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPlaces;
    [SerializeField] private float _minSpawnDelayInSeconds;
    [SerializeField] private float _maxSpawnDelayInSeconds;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            var enemy = Instantiate(RandomEnemyPrefab(), RandomSpawnPlace(), Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetDirection(_playerTransform.position);
            yield return new WaitForSeconds(RandomSpawnDelay());
        }
    }

    private GameObject RandomEnemyPrefab()
    {
        return _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
    }

    private Vector3 RandomSpawnPlace()
    {
        return _spawnPlaces[Random.Range(0, _spawnPlaces.Length)].position;
    }

    private float RandomSpawnDelay()
    {
        return Random.Range(_minSpawnDelayInSeconds, _maxSpawnDelayInSeconds + 1);
    }
}
