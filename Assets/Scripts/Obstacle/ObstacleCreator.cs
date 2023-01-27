using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstaclesPool;
    [SerializeField] private float _maxHeight = 1f;
    [SerializeField] private float _minHeight = -1f;

    private void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }

    private IEnumerator SpawnRandomObstacle()
    {
        while (true)
        {
            int rand = Random.Range(0, _obstaclesPool.Capacity);
            GameObject instance = Instantiate(_obstaclesPool[rand], transform.position, Quaternion.identity);
            instance.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
            yield return new WaitForSeconds(8);
        }
    }
}

