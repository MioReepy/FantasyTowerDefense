using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerSpace
{
    public abstract class BulletObjectPool : MonoBehaviour
    {
        private GameObject _objectToPool;
        private GameObject _spawnObject;
        private List<GameObject> _poolObjects;

        protected void SetBulletObject(GameObject objectToPool, GameObject spawnObject)
        {
            _objectToPool = objectToPool;
            _spawnObject = spawnObject;
            _poolObjects = new List<GameObject>();
        }

        internal void AddBulletToPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject poolTemp = Instantiate(_objectToPool, _spawnObject.transform);
                poolTemp.SetActive(false);
                _poolObjects.Add(poolTemp);
            }
        }

        internal GameObject GetPoolObject()
        {
            foreach (var enemyObject in _poolObjects.Where(enemyObject => !enemyObject.activeInHierarchy))
            {
                return enemyObject;
            }

            GameObject poolTemp = Instantiate(_objectToPool, _spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);

            return poolTemp;
        }
    }
}