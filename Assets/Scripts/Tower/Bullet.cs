using UnityEngine;

namespace TowerSpace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private GameObject _impactEffect;
        public Vector3 Target { get; set; }
        public bool Hit { get; set; }

        private void LateUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, bulletSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Target) < 0.01f)
            {
                HitTarget();
                gameObject.SetActive(false);
            }
        }

        private void HitTarget()
        {
            Instantiate(_impactEffect, transform.position, Quaternion.identity);
        }
    }
}