using UnityEngine;

namespace EnemySpace
{
    
    public class EnemyObject : ScriptableObject
    {
        [SerializeField] internal int ID;
        [SerializeField] internal GameObject prefabEnemy;
        [SerializeField] internal EnemyType enemyType;
        [SerializeField] [Range(10, 100)] internal int enemyHP;
        [SerializeField] [Range(0.5f, 10f)] internal float enemySpeed;
    }
}