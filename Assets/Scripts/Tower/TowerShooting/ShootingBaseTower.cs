using UnityEngine;

namespace TowerSpace
{
    public class ShootingBaseTower : MonoBehaviour
    {
        private Transform _spawnPool;
        private float _rotationSpeed = 100f;
        protected float fireCoolDown = 0f;
        protected TowerFieldOfView towerFieldOfView;

        protected void SetShootingBaseTower(Transform spawnPool, float rotationSpeed)
        {
            _spawnPool = spawnPool;
            _rotationSpeed = rotationSpeed;
        }
        
        protected void RotateToDirection()
        {
            Vector3 lookRotation = Quaternion.LookRotation(towerFieldOfView.target.position - transform.position)
                .eulerAngles;
            Quaternion rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }

        protected virtual GameObject GetBullet()
        {
            return null;
        }        
        
        protected virtual Transform GetSpawnPosition()
        {
            return null;
        }
        
        protected virtual void Shoot()
        {
            GameObject bulletObject = GetBullet();

            if (bulletObject == null) return;
            
            bulletObject.GetComponent<Bullet>().DamagePower = gameObject.GetComponentInParent<Tower>().mainTowerPrefab.GetComponent<TowerInformation>().damageTower; 
                
            bulletObject.transform.parent = GetSpawnPosition();
            bulletObject.transform.position = _spawnPool.transform.position;
            bulletObject.transform.rotation = _spawnPool.transform.rotation;
                
            bulletObject.SetActive(true);
                
            Bullet bullet = bulletObject.GetComponent<Bullet>();

            bullet.Target = towerFieldOfView.target;
        }
    }
}