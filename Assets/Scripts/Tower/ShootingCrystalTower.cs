using UnityEngine;

namespace TowerSpace
{
    public class ShootingCrystalTower : ShootingBaseTower
    {
        private void Start()
        {
            _towerFieldOfView = GetComponent<TowerFieldOfView>();
        }

        private void Update()
        {
            if (_towerFieldOfView.target != null)
            {
                RotateToDirection();

                if (_fireCoolDown <= 0f)
                {
                    Shoot();
                    _fireCoolDown = 1 / _fireSpeed;
                }

                _fireCoolDown -= Time.deltaTime;
            }
        }
    }
}