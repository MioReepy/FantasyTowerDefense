using UnityEngine;

namespace TowerSpace
{
    public class ShootingTower : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private float _fireSpeed = 1f;
        [SerializeField] private Transform _spawnPool;
        private float _fireCoolDown = 0f;
        private TowerFieldOfView _towerFieldOfView;

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

        private void RotateToDirection()
        {
            Vector3 lookRotation = Quaternion.LookRotation(_towerFieldOfView.target.position - transform.position)
                .eulerAngles;
            Quaternion rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }

        private void Shoot()
        {
            GameObject bulletObject = BulletObjectPool.Singleton.GetPoolObject();

            if (bulletObject != null)
            {
                bulletObject.transform.parent = BulletObjectPool.Singleton.spawnObject.transform;
                bulletObject.transform.position = _spawnPool.transform.position;
                bulletObject.transform.rotation = _spawnPool.transform.rotation;
                
                bulletObject.SetActive(true);
                
                Bullet bullet = bulletObject.GetComponent<Bullet>();

                bullet.Target = _towerFieldOfView.target;
            }
        }
    }
}