using System.Collections.Generic;
using UnityEngine;

namespace EnemySpace
{
    public class EnemyPortalObjectPool : MonoBehaviour
    {
        [SerializeField] internal GameObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        [SerializeField] private int _poolSize = 15;

        private List<GameObject> _poolObjects;

        public static EnemyPortalObjectPool Singleton;
        private void Awake() => Singleton = this;
        
        private void Start()
        {
            _poolObjects = new List<GameObject>();

            for (int j = 0; j < _poolSize; j++)
            {
                GameObject poolTemp = Instantiate(objectToPool, spawnObject.transform);
                poolTemp.SetActive(false);
                _poolObjects.Add(poolTemp);
            }
        }

        internal GameObject GetPoolObject()
        {
            for (int j = 0; j < _poolObjects.Count; j++)
            {
                if (!_poolObjects[j].activeInHierarchy)
                {
                    return _poolObjects[j];
                }
            }

            GameObject poolTemp = Instantiate(objectToPool, spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);

            return poolTemp;
        }
    }
}