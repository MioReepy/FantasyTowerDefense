using UnityEngine;

namespace TowerSpace
{
    public class ShootingMortalTower : ShootingBaseTower
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
            return CannonBowObjectPool.Singleton.GetPoolObject();
        }  
        
        protected override Transform GetSpawnPosition()
        {
            return CannonBowObjectPool.Singleton.spawnObject.transform;
        }
    }
}