using UnityEngine;

namespace TowerSpace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private GameObject _impactEffect;
        private int damagePower;
        public Transform Target { get; set; }
        public int DamagePower { get; set; }

        private void LateUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, bulletSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, Target.position) < 0.01f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}