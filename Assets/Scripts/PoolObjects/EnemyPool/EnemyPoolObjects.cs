using System.Collections.Generic;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class EnemyPoolObjects : MonoBehaviour
    {
        private EnemyObject _objectToPool;
        private GameObject _spawnObject;
        private List<GameObject> _poolObjects;

        protected void SetEnemyObjectAndSpawnObject(EnemyObject objectToPool, GameObject spawnObject)
        {
            _objectToPool = objectToPool;
            _spawnObject = spawnObject;
            _poolObjects = new List<GameObject>();
        }

        internal void AddEnemyToPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject poolTemp = Instantiate(_objectToPool.prefabEnemy, _spawnObject.transform);
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

            GameObject poolTemp = Instantiate(_objectToPool.prefabEnemy, _spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);

            return poolTemp;
        }
    }
}