using UnityEngine;

namespace EnemySpace
{
    public class Enemy
    {
        public int ID;

        public Enemy(EnemyObject enemy)
        {
            this.ID = enemy.ID;
        }
    }

    public class EnemyObject : ScriptableObject
    {
        public int ID;
        public GameObject prefabEnemy;
        public EnemyType enemyType;
        [Range(10, 100)] public int enemyHP;
        [Range(0.5f, 10f)] public float enemySpeed;

        public Enemy CreateEnemy()
        {
            Enemy newEnemy = new Enemy(this);
            return newEnemy;
        }
    }
}

