using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectToPool;
    [SerializeField] private int _amountToPool;

    private List<GameObject> _pooledObjects;
    private DifficultyController _difficulty;

    private void Start()
    {
        _difficulty = FindObjectOfType<DifficultyController>();
        CreateNewObjectPool();
    }

    private void CreateNewObjectPool()
    {
        _pooledObjects = new List<GameObject>();

        for (int i = 0; i < _amountToPool; i++)
        {
            int rand = Random.Range(0, _objectToPool.Capacity);
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
        GameObject gameObject = GetPooledObject();

        if (gameObject != null)
        {
            gameObject.transform.position = transform.position;
            gameObject.SetActive(true);
        }
    }
}
