using UnityEngine;

namespace TowerSpace
{
    public class ShootingBaseTower : MonoBehaviour
    {
        [SerializeField] protected float rotationSpeed = 100f;
        [SerializeField] protected float fireSpeed = 1f;
        [SerializeField] protected Transform spawnPool;

        protected float fireCoolDown = 0f;
        protected TowerFieldOfView towerFieldOfView;

        protected void RotateToDirection()
        {
            Vector3 lookRotation = Quaternion.LookRotation(towerFieldOfView.target.position - transform.position)
                .eulerAngles;
            Quaternion rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        protected virtual void Shoot()
        {
            GameObject bulletObject = BulletObjectPool.Singleton.GetPoolObject();

            if (bulletObject != null)
            {
                bulletObject.transform.parent = BulletObjectPool.Singleton.spawnObject.transform;
                bulletObject.transform.position = spawnPool.transform.position;
                bulletObject.transform.rotation = spawnPool.transform.rotation;
                
                bulletObject.SetActive(true);
                
                Bullet bullet = bulletObject.GetComponent<Bullet>();

                bullet.Target = towerFieldOfView.target;
            }
        }
    }
}