using UnityEngine;
using WaveSpawnerSpace;
using WaypointSpase;

namespace EnemySpace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] internal EnemyObject enemy;
        [SerializeField] private GameObject _impactEffect;
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                other.gameObject.SetActive(false);
                Instantiate(_impactEffect, transform.position, Quaternion.identity);
                _animator.SetBool("IsDied", true);
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<WaypointNavigator>().enabled = false;
                gameObject.GetComponent<EnemyNavigator>().enabled = false;
            }
        }

        public void EnemyDied()
        {
            _animator.SetBool("IsDied", false);
            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<WaypointNavigator>().enabled = true;
            gameObject.GetComponent<EnemyNavigator>().enabled = true;
            EnemyPool.ReturnToPool(gameObject);
        }
    }
}