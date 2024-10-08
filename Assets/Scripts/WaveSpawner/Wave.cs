using System;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    [Serializable]
    public struct Enemies
    {
        public EnemyObject enemyObject;
        public int enemyCount;
        internal int waveNumber;
    }
    
    [Serializable]
    public class Wave
    {
        public Enemies[] enemies;
    }
}