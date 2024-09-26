using UnityEngine;

namespace EnemySpace
{
    public class EnemyObject : ScriptableObject
    {
        public int ID;
        public GameObject prefabEnemy;
        public EnemyType enemyType;
        [Range(10, 100)] public int enemyHP;
        [Range(0.5f, 10f)] public float enemySpeed;
    }
}