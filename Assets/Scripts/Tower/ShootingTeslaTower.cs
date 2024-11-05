using DigitalRuby.LightningBolt;
using UnityEngine;

namespace TowerSpace
{
    public class ShootingTeslaTower : ShootingBaseTower
    {
        [SerializeField] private GameObject _lightningBolt;
        
        private void Start()
        {
            towerFieldOfView = GetComponent<TowerFieldOfView>();
            
            _lightningBolt.GetComponent<LightningBoltScript>().EndObject = spawnPool.gameObject;
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

        protected override void Shoot()
        {
            base.Shoot();

            _lightningBolt.GetComponent<LightningBoltScript>().EndObject = towerFieldOfView.target.gameObject;
        }
    }
}