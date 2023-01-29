using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _maxHeight = 1f;
    [SerializeField] private float _spawnRate;

    private ObjectPooler _objectPooler;
    private float _time;

    private void OnEnable()
    {
        DifficultyController.OnDifficultyIncrease += IncreaseSpawnRate;
    }

    private void OnDisable()
    {
        DifficultyController.OnDifficultyIncrease -= IncreaseSpawnRate;
    }

    private void Start()
    {
        _objectPooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float nextTimeToFire = 1 / _spawnRate;

        if ( _time >= nextTimeToFire)
        {
            _time = 0;
            _objectPooler.SpawnObject();
        }
    }

    private void IncreaseSpawnRate()
    {
        _spawnRate += 0.01f;
    }
}
