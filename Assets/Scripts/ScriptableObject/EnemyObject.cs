using System;
using UnityEngine;

namespace EnemySpace
{
    public enum EnemyType
    {
        Ghost = 0,
        Phantom = 1,
        Spook = 2
    }
    
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
    [Serializable]
    public class EnemyObject : ScriptableObject
    {
        [SerializeField] internal GameObject prefabEnemy;
        [SerializeField] internal EnemyType enemyType;
        // [SerializeField] [Range(10, 100)] internal int enemyHP;
        [SerializeField] [Range(0.5f, 10f)] internal float enemySpeed;
    }
}