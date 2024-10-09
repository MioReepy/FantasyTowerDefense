using System;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    public class EnemyPool
    {
        public static void CreateEnemyPool(EnemyType enemyType, int poolSize)
        {
            switch (enemyType)
            {
                case EnemyType.Ghost:
                    GhostPool.Singleton._poolSize += poolSize;
                    break;                
                case EnemyType.Phantom:
                    PhantomPool.Singleton._poolSize += poolSize;
                    break;                
                case EnemyType.Spook:
                    SpookPool.Singleton._poolSize += poolSize;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }

        public static GameObject GetEnemy(EnemyType enemyType) => enemyType switch
        {
            EnemyType.Ghost => GhostPool.Singleton.GetPoolObject(),
            EnemyType.Phantom => GhostPool.Singleton.GetPoolObject(),
            EnemyType.Spook => GhostPool.Singleton.GetPoolObject(),
            _ => throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null)
        };
        
        public static void ReturnToPool(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }
    }
}