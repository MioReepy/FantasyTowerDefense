using UnityEngine;

namespace TowerSpace
{
    public class CrystalObjectPool : BulletObjectPool
    {
        [SerializeField] internal GameObject objectToPool;
        [SerializeField] internal GameObject spawnObject;
        [SerializeField] internal int poolSize = 10;
        
        public static CrystalObjectPool Singleton;

        private void Awake()
        {
            Singleton = this;
            SetBulletObject(objectToPool, spawnObject);
            AddBulletToPool(poolSize);
        }
    }
}