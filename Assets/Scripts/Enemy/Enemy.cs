using GameController;
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

        private int _currentHelth;
        private Animator _animator;
        internal bool isDead;

        private void Awake()
        {
            _currentHelth = _health;
        }

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
            _currentHelth -= bullet.GetComponent<Bullet>().DamagePower;
            Instantiate(_impactEffect, transform.position, Quaternion.identity);

            if (_currentHelth > 0) return;
            
            bullet.gameObject.SetActive(false);
            SetEnemyStats(false);
            Finish.Instance.EnemyDied();
        }
        
        public void EnemyDied()
        {
            PlayerStats.Instance.SetMoney(_reward);
            SetEnemyStats(true);
            _currentHelth = _health;
            EnemyPool.ReturnToPool(gameObject);
        }
        
        private void SetEnemyStats(bool isEnable)
        {
            _animator.SetBool("IsDied", !isEnable);
            gameObject.GetComponent<Collider>().enabled = isEnable;
            gameObject.GetComponent<Rigidbody>().useGravity = isEnable;
            gameObject.GetComponent<Rigidbody>().isKinematic = isEnable;
            gameObject.GetComponent<WaypointNavigator>().enabled = isEnable;
            gameObject.GetComponent<EnemyNavigator>().enabled = isEnable;
            isDead = !isEnable;
        }
    }
}