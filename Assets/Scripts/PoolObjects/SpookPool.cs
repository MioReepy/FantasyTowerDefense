using System.Collections.Generic;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class SpookPool : MonoBehaviour
    {
        [SerializeField] internal EnemyObject objectToPool;
        [SerializeField] internal GameObject spawnObject;

        private List<GameObject> _poolObjects;
        
        public static SpookPool Singleton;

        private void Awake()
        {
            Singleton = this;
            _poolObjects = new List<GameObject>();
        }
        
        internal void AddEnemyToPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
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