using UnityEngine;

namespace TowerSpace
{
    public class UnvisibleObjectPool : BulletObjectPool
    {
        [SerializeField] internal GameObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        [SerializeField] internal int poolSize = 10;
        
        public static UnvisibleObjectPool Singleton;

        private void Awake()
        {
            Singleton = this;
            SetBulletObject(objectToPool, spawnObject);
            AddBulletToPool(poolSize);
        }
    }
}