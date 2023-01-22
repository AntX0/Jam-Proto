using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectToPool;
    [SerializeField] private int _amountToPool;

    private List<GameObject> _pooledObjects;

    private void Start()
    {
        CreateNewObjectPool();
    }

    private void CreateNewObjectPool()
    {
        _pooledObjects = new List<GameObject>();
        int rand = Random.Range(0, _objectToPool.Capacity);

        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_objectToPool[rand]);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    private GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (_pooledObjects[i].activeInHierarchy == false)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }

    public void SpawnObject()
    {
        GameObject projectile = GetPooledObject();

        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            projectile.SetActive(true);
        }
    }
}
