using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstaclesPool;

    private void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }

    private IEnumerator SpawnRandomObstacle()
    {
        int rand = Random.Range(0, _obstaclesPool.Capacity);
        while (true)
        {
            Instantiate(_obstaclesPool[rand], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
