using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class SpookPool : EnemyPoolObjects
    {
        [SerializeField] internal EnemyObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        
        public static SpookPool Singleton;

        private void Awake()
        {
            Singleton = this;
            SetEnemyObjectAndSpawnObject(objectToPool, spawnObject);
        }
    }
}