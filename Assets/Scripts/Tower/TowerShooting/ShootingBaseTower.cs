using UnityEngine;

namespace TowerSpace
{
    public class ShootingBaseTower : MonoBehaviour
    {
        private GameObject _tower;
        protected Transform spawnPool;
        protected float rotationSpeed = 100f;
        protected float fireSpeed = 1f;

        protected float fireCoolDown = 0f;
        protected TowerFieldOfView towerFieldOfView;

        protected void SetShootingBaseTower(GameObject tower, Transform spawnPool, float rotationSpeed, float fireSpeed)
        {
            _tower = tower;
            this.spawnPool = spawnPool;
            this.rotationSpeed = rotationSpeed;
            this.fireSpeed = fireSpeed;
        }
        
        protected void RotateToDirection()
        {
            Vector3 lookRotation = Quaternion.LookRotation(towerFieldOfView.target.position - transform.position)
                .eulerAngles;
            Quaternion rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
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

            if (bulletObject != null)
            {
                Tower tower = _tower.GetComponent<Builder>().tower.transform.GetComponent<Tower>();

                if (tower.currentTowerLevel == 0)
                {
                    bulletObject.GetComponent<Bullet>().DamagePower = transform.GetComponentInParent<Tower>()._damageTower[tower.currentTowerLevel]; 
                }

                else
                {
                    bulletObject.GetComponent<Bullet>().DamagePower = transform.GetComponentInParent<Tower>()._damageTower[tower.currentTowerLevel - 1]; 
                }
                
                bulletObject.transform.parent = GetSpawnPosition();
                bulletObject.transform.position = spawnPool.transform.position;
                bulletObject.transform.rotation = spawnPool.transform.rotation;
                
                bulletObject.SetActive(true);
                
                Bullet bullet = bulletObject.GetComponent<Bullet>();

                bullet.Target = towerFieldOfView.target;
            }
        }
    }
}