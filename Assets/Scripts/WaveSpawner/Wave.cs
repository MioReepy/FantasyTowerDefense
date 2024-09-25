using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Wave/New Wave")]
    public class Wave : ScriptableObject
    {
        public EnemiesForWave[] enemy;
        public float timeBetweenEnemies = 0.5f;
    }
}