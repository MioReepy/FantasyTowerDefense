using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private int _poolSize = 10;

    private List<GameObject> _poolObjects;

    private void Start()
    {
        _poolObjects = new List<GameObject>();

        GameObject poolTemp;

        for (int i = 0; i < _poolSize; i++)
        {
            poolTemp = Instantiate(objectToPool, _spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);
        }
    }

    internal GameObject GetPoolObject()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (!_poolObjects[i].activeInHierarchy)
            {
                return _poolObjects[i];
            }
        }

        return null;
    }
}
