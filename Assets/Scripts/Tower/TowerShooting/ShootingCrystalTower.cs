using UnityEngine;

namespace TowerSpace
{
    public class ShootingCrystalTower : ShootingBaseTower
    {
        [SerializeField] protected float rotationSpeed = 100f;
        [SerializeField] protected float fireSpeed = 1f;
        [SerializeField] protected Transform spawnPool;
        
        private void Awake()
        {
            towerFieldOfView = GetComponent<TowerFieldOfView>();
            SetShootingBaseTower(spawnPool, rotationSpeed);
        }

        private void Update()
        {
            if (towerFieldOfView.target == null) return;
            
            RotateToDirection();

            if (fireCoolDown <= 0f)
            {
                SoundManager.Instance.CrystalShotSound();
                Shoot();
                fireCoolDown = 1 / fireSpeed;
            }

            fireCoolDown -= Time.deltaTime;
        }
        
        protected override GameObject GetBullet()
        {
            return CrystalObjectPool.Singleton.GetPoolObject();
        }  
        
        protected override Transform GetSpawnPosition()
        {
            return CrystalObjectPool.Singleton.spawnObject.transform;
        }
    }
}