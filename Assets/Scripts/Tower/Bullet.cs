using UnityEngine;

namespace TowerSpace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private GameObject _impactEffect;
        public Transform Target { get; set; }
        public bool Hit { get; set; }

        public delegate void EnemyHit();
        public static event EnemyHit OnEnemyHit;
        
        private void LateUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, bulletSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Target.position) < 0.01f)
            {
                HitTarget();
            }
        }

        private void HitTarget()
        {
            Instantiate(_impactEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            OnEnemyHit?.Invoke();
        }
    }
}