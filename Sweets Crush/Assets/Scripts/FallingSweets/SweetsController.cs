using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetsController : MonoBehaviour
{
    [SerializeField] private GameObject[] _sweetsPrefabs;

    [SerializeField] private Transform _sweetsSpawnPoint1;
    [SerializeField] private Transform _sweetsSpawnPoint2;

    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _maxSpawnInterval;

    private float _spawnActualInterval;

    private void Start()
    {
        SetSpawnInterval();
    }

    private void Update()
    {
        _spawnActualInterval -= Time.deltaTime;

        if (_spawnActualInterval <= 0)
        {
            SpawnSweets();
            SetSpawnInterval();
        }
    }

    private void SpawnSweets()
    {
        var spawnPosition = _sweetsSpawnPoint1.position;
        spawnPosition.x = Mathf.Lerp(_sweetsSpawnPoint1.position.x, _sweetsSpawnPoint2.position.x, Random.Range(0, 1f));


        GameObject sweetsPrefab = _sweetsPrefabs[Random.Range(0, _sweetsPrefabs.Length)];

        var go = Instantiate(sweetsPrefab, spawnPosition, Quaternion.identity);
        Destroy(go, 12f);
    }

    private void SetSpawnInterval()
    {
        _spawnActualInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }
}
