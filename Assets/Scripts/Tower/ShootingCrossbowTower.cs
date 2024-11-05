using UnityEngine;

namespace TowerSpace
{
    public class ShootingCrossbowTower : ShootingBaseTower
    {
        private void Start()
        {
            towerFieldOfView = GetComponent<TowerFieldOfView>();
        }

        private void Update()
        {
            if (towerFieldOfView.target != null)
            {
                RotateToDirection();

                if (fireCoolDown <= 0f)
                {
                    Shoot();
                    fireCoolDown = 1 / fireSpeed;
                }

                fireCoolDown -= Time.deltaTime;
            }
        }
        
        protected override GameObject GetBullet()
        {
            return ArrowObjectPool.Singleton.GetPoolObject();
        }  
        
        protected override Transform GetSpawnPosition()
        {
            return ArrowObjectPool.Singleton.spawnObject.transform;
        }
    }
}