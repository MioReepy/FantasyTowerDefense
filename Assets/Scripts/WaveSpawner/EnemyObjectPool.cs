using System.Collections.Generic;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class EnemyObjectPool : MonoBehaviour
    {
        [SerializeField] internal EnemyObject[] objectToPool;
        [SerializeField] internal GameObject spawnObject;
        [SerializeField] private int _poolSize = 10;

        private List<GameObject> _poolObjects;
        
        static public EnemyObjectPool Singleton;
        private void Awake() => Singleton = this;

        private void Start()
        {
            _poolObjects = new List<GameObject>();

            for (int i = 0; i < objectToPool.Length; i++)
            {
                for (int j = 0; j < _poolSize; j++)
                {
                    GameObject poolTemp = Instantiate(objectToPool[i].prefabEnemy, spawnObject.transform);
                    poolTemp.SetActive(false);
                    _poolObjects.Add(poolTemp);
                }
            }
        }

        internal GameObject GetPoolObject(EnemyObject enemy)
        {
            for (int i = 0; i < objectToPool.Length; i++)
            {
                for (int j = 0; j < _poolObjects.Count; j++)
                {
                    if (!_poolObjects[j].activeInHierarchy &&
                        _poolObjects[j].GetComponent<EnemyIdentificator>().enemy ==
                        enemy.prefabEnemy.GetComponent<EnemyIdentificator>().enemy)
                    {
                        return _poolObjects[j];
                    }
                }
            }

            GameObject poolTemp = Instantiate(enemy.prefabEnemy, spawnObject.transform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);
            return poolTemp;
        }
        
        internal void ReturnToPool(GameObject poolObject)
        {
            poolObject.SetActive(false);
            poolObject.transform.position = spawnObject.transform.position;
        }
    }
}