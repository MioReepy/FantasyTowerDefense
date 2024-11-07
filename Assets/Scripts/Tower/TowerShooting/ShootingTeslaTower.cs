using DigitalRuby.LightningBolt;
using UnityEngine;

namespace TowerSpace
{
    public class ShootingTeslaTower : ShootingBaseTower
    {
        [SerializeField] private GameObject _lightningBolt;
        [SerializeField] protected float rotationSpeed = 100f;
        [SerializeField] protected float fireSpeed = 1f;
        [SerializeField] protected Transform spawnPool;
        [SerializeField] private GameObject _tower;
        
        private void Awake()
        {
            towerFieldOfView = GetComponent<TowerFieldOfView>();
            SetShootingBaseTower(_tower, spawnPool, rotationSpeed, fireSpeed);
        }

        protected void Update()
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
            
            if (towerFieldOfView.target == null)
            {
                _lightningBolt.GetComponent<LightningBoltScript>().EndObject = spawnPool.gameObject;
            }
        }
        
        protected override GameObject GetBullet()
        {
            return UnvisibleObjectPool.Singleton.GetPoolObject();
        }  
        
        protected override Transform GetSpawnPosition()
        {
            return UnvisibleObjectPool.Singleton.spawnObject.transform;
        }

        protected override void Shoot()
        {
            base.Shoot();

            _lightningBolt.GetComponent<LightningBoltScript>().EndObject = towerFieldOfView.target.gameObject;
        }
    }
}