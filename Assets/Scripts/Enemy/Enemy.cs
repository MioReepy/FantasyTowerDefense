using UnityEngine;
using WaveSpawnerSpace;

namespace EnemySpace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] internal EnemyObject enemy;
        [SerializeField] private GameObject _impactEffect;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                other.gameObject.SetActive(false);
                Instantiate(_impactEffect, transform.position, Quaternion.identity);
                EnemyPool.ReturnToPool(gameObject);
            }
        }
    }
}