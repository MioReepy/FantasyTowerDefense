using System;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public abstract class EnemyPool : MonoBehaviour
    {
        public static void CreateEnemyPool(EnemyType enemyType, int poolSize)
        {
            switch (enemyType)
            {
                case EnemyType.Ghost:
                    GhostPool.Singleton.AddEnemyToPool(poolSize);
                    break;                
                case EnemyType.Phantom:
                    PhantomPool.Singleton.AddEnemyToPool(poolSize);
                    break;                
                case EnemyType.Spook:
                    SpookPool.Singleton.AddEnemyToPool(poolSize);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }

        public static GameObject GetEnemy(EnemyType enemyType) => enemyType switch
        {
            EnemyType.Ghost => GhostPool.Singleton.GetPoolObject(),
            EnemyType.Phantom => PhantomPool.Singleton.GetPoolObject(),
            EnemyType.Spook => SpookPool.Singleton.GetPoolObject(),
            _ => throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null)
        };
        
        public static void ReturnToPool(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }
    }
}