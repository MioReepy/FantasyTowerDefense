using System.Collections.Generic;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class PhantomPool : EnemyPoolObjects
    {
        [SerializeField] internal EnemyObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        
        public static PhantomPool Singleton;

        private void Awake()
        {
            Singleton = this;
            SetEnemyObjectAndSpawnObject(objectToPool, spawnObject);
        }
    }
}