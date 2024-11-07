using PlayerSpace;
using TowerSpace;
using UnityEngine;
using WaveSpawnerSpace;
using WaypointSpase;

namespace EnemySpace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] internal EnemyObject enemy;
        [SerializeField] private GameObject _impactEffect;
        [SerializeField] internal int _health = 100;
        [SerializeField] int _reward = 50;
        
        private Animator _animator;
        internal bool isDead;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                GetDamag(other.gameObject);
            }
        }

        private void GetDamag(GameObject bullet)
        {
            _health -= bullet.GetComponent<Bullet>().DamagePower;
            PlayerStats.Instance.SetMoney(_reward);
            Instantiate(_impactEffect, transform.position, Quaternion.identity);

            if (_health <= 0)
            {
                bullet.gameObject.SetActive(false);
                _animator.SetBool("IsDied", true);
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<WaypointNavigator>().enabled = false;
                gameObject.GetComponent<EnemyNavigator>().enabled = false;
                isDead = true;
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
            isDead = false;
            EnemyPool.ReturnToPool(gameObject);
            Finish.Instance.EnemyDied();
        }
    }
}