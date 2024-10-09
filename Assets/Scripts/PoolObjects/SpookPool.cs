using System.Collections.Generic;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class SpookPool : MonoBehaviour
    {
        [SerializeField] internal EnemyObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        internal int _poolSize = 0;

        private List<GameObject> _poolObjects;
        
        public static SpookPool Singleton;
        private void Awake() => Singleton = this;

        private void Start()
        {
            _poolObjects = new List<GameObject>();

            for (int i = 0; i < _poolSize; i++)
            {
                GameObject poolTemp = Instantiate(objectToPool.prefabEnemy, spawnObject.transform);
                poolTemp.SetActive(false);
                _poolObjects.Add(poolTemp);
            }
        }

        internal GameObject GetPoolObject()
        {
            foreach (var enemyObject in _poolObjects)
            {
                if (!enemyObject.activeInHierarchy)
                {
                    return enemyObject;
                }
            }

            GameObject poolTemp = Instantiate(objectToPool.prefabEnemy, spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);
            return poolTemp;
        }
    }
}