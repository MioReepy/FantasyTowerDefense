using UnityEngine;

namespace TowerSpace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private GameObject _impactEffect;
        public Transform Target { get; set; }
        public bool Hit { get; set; }

        private void LateUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, bulletSpeed * Time.deltaTime);
        }
    }
}