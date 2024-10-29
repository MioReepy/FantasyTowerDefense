using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class GhostPool : EnemyPoolObjects
    {
        [SerializeField] internal EnemyObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        
        public static GhostPool Singleton;

        private void Awake()
        {
            Singleton = this;
            SetEnemyObjectAndSpawnObject(objectToPool, spawnObject);
        }
    }
}