using UnityEngine;

namespace TowerSpace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject DecalPrefab;
        [SerializeField] private float bulletSpeed = 100f;
        
        private ObjectPool decalPool;
        public Vector3 Target { get; private set; }
        public bool Hit { get; private set; }

        private void Start()
        {
            decalPool = GetComponent<ObjectPool>();
        }

        private void LateUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, bulletSpeed * Time.deltaTime);

            if (!Hit && Vector3.Distance(transform.position, Target) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];

            GameObject decal = decalPool.GetPoolObject();

            if (decal == null)
            {
                decal.transform.position = contact.point + contact.normal * 0.001f;
                decal.transform.rotation = Quaternion.LookRotation(contact.normal);
                decal.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}