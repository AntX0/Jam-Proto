using System;
using System.Collections;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _pool;

    private void Start()
    {
        StartCoroutine(EnableObjectInPool());
    }

    private IEnumerator EnableObjectInPool()
    {
        foreach (GameObject ground in _pool)
        {
            ground.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
