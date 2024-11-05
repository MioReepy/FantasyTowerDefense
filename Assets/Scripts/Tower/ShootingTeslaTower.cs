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

            _lightningBolt.GetComponent<LightningBoltScript>().StartObject = _spawnPool.gameObject;
            _lightningBolt.GetComponent<LightningBoltScript>().EndObject = _spawnPool.gameObject;
        }

        protected void Update()
        {
            if (towerFieldOfView.target != null)
            {
                RotateToDirection();

                if (_fireCoolDown <= 0f)
                {
                    Shoot();
                    _fireCoolDown = 1 / _fireSpeed;
                }

                _fireCoolDown -= Time.deltaTime;
            }
            
            if (gameObject.transform.GetComponentInParent<Tower>()._towerType == TowerType.Tesla && towerFieldOfView.target == null)
            {
                _lightningBolt.GetComponent<LightningBoltScript>().EndObject = _spawnPool.gameObject;
            }
        }

        private protected override void Shoot()
        {
            base.Shoot();

            if (gameObject.transform.GetComponentInParent<Tower>()._towerType == TowerType.Tesla)
            {
                _lightningBolt.GetComponent<LightningBoltScript>().EndObject = towerFieldOfView.target.gameObject;
            }
        }
    }
}