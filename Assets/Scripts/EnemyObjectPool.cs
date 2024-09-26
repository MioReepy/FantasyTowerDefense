using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField] internal GameObject[] objectToPool;
    [SerializeField] internal GameObject spawnObject;
    [SerializeField] private int _poolSize = 10;

    private List<GameObject> _poolObjects;

    private void Start()
    {
        _poolObjects = new List<GameObject>();
        
        for (int i = 0; i < objectToPool.Length; i++)
        {
            for (int j = 0; j < _poolSize; j++)
            {
                GameObject poolTemp = Instantiate(objectToPool[i], spawnObject.transform);
                poolTemp.SetActive(false);
                _poolObjects.Add(poolTemp);
            }
        }
    }

    internal GameObject GetPoolObject()
    {
        for (int i = 0; i < objectToPool.Length; i++)
        {
            for (int j = 0; j < _poolObjects.Count; j++)
            {
                if (!_poolObjects[j].activeInHierarchy)
                {
                    return _poolObjects[j];
                }
            }

            GameObject poolTemp = Instantiate(objectToPool[i], spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);
            return poolTemp;
        }

        return null;
    }
}
