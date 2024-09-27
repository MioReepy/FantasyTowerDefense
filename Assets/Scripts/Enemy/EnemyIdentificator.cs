using System;
using TowerSpace;
using UnityEngine;
using WaveSpawnerSpace;

namespace EnemySpace
{
    public class EnemyIdentificator : MonoBehaviour
    {
        [SerializeField] internal EnemyObject enemy;

        // private void OnEnable()
        // {
        //     Bullet.OnEnemyHit += EnemyHit;
        // }
        //
        // private void EnemyHit()
        // {
        //     EnemyObjectPool.SingletonEnemyObjectPool.ReturnToPool(gameObject);
        // }
        //
        // private void OnDisable()
        // {
        //     Bullet.OnEnemyHit -= EnemyHit;
        //     
        // }
    }
}