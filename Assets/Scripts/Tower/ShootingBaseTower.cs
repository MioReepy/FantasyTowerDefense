using UnityEngine;

namespace TowerSpace
{
    public class ShootingBaseTower : MonoBehaviour
    {
        [SerializeField] protected float rotationSpeed = 100f;
        [SerializeField] protected float _fireSpeed = 1f;
        [SerializeField] protected Transform _spawnPool;

        protected float _fireCoolDown = 0f;
        protected TowerFieldOfView towerFieldOfView;

        protected void RotateToDirection()
        {
            Vector3 lookRotation = Quaternion.LookRotation(towerFieldOfView.target.position - transform.position)
                .eulerAngles;
            Quaternion rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        private protected virtual void Shoot()
        {
            GameObject bulletObject = BulletObjectPool.Singleton.GetPoolObject();

            if (bulletObject != null)
            {
                bulletObject.transform.parent = BulletObjectPool.Singleton.spawnObject.transform;
                bulletObject.transform.position = _spawnPool.transform.position;
                bulletObject.transform.rotation = _spawnPool.transform.rotation;
                
                bulletObject.SetActive(true);
                
                Bullet bullet = bulletObject.GetComponent<Bullet>();

                bullet.Target = towerFieldOfView.target;
            }
        }
    }
}