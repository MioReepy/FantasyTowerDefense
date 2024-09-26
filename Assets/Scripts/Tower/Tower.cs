using UnityEngine;

namespace TowerSpace
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private float _fireSpeed = 1f;
        private float _fireCoolDown = 0f;
        
        private TowerFieldOfView _towerFieldOfView;
        private BulletObjectPool _bulletPool;
        [SerializeField] private Transform _spawnPool;
        [SerializeField] private float fireOffset = 3f;
        private void Start()
        {
            _towerFieldOfView = GetComponent<TowerFieldOfView>();
            _bulletPool = GetComponent<BulletObjectPool>();
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
            GameObject bulletObject = _bulletPool.GetPoolObject();

            if (bulletObject != null)
            {
                bulletObject.transform.parent = _bulletPool.spawnObject.transform;
                bulletObject.transform.position = _bulletPool.spawnObject.transform.position;
                bulletObject.transform.rotation = _bulletPool.spawnObject.transform.rotation;
                
                bulletObject.SetActive(true);
                
                Bullet bullet = bulletObject.GetComponent<Bullet>();

                bullet.Target = _towerFieldOfView.target.position + (_towerFieldOfView.target.forward * fireOffset);
                bullet.Hit = true;
            }
        }
    }
}