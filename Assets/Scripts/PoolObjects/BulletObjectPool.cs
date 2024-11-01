using System.Collections.Generic;
using UnityEngine;

namespace TowerSpace
{
    public class BulletObjectPool : MonoBehaviour
    {
        [SerializeField] internal GameObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        [SerializeField] private int _poolSize = 10;

        private List<GameObject> _poolObjects;

        static public BulletObjectPool Singleton;
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
        
        public static void ReturnToPool(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }
    }
}