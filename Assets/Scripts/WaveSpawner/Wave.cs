using System;
using EnemySpace;

namespace WaveSpawnerSpace
{
    [Serializable]
    public struct Enemies
    {
        public EnemyObject EnemyObject;
        public int count;
    }
    
    [Serializable]
    public struct Wave
    {
        public Enemies[] enemies;
    }
}