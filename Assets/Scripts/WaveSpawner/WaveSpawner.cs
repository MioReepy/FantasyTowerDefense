using System;
using System.Collections.Generic;
using UnityEngine;

namespace WaveSpawnerSpace
{
    [CreateAssetMenu(fileName = "Wave Spawner", menuName = "Enemy/Wave Spawner")]
    [Serializable]
    public class WaveSpawner : ScriptableObject, ISerializationCallbackReceiver
    {
        public List<WaveDataBase> WavesCount;
        // public  Dictionary<EnemyType, int> Enemies;
        
        public void OnBeforeSerialize()
        {
            if (WavesCount != null)
            {
                for (int i = 0; i < WavesCount.Count; i++)
                {
                    WavesCount[i] = CreateInstance<WaveDataBase>();
                }
            }
            // if (Waves == null)
            // {
            //     EnemiesDatabase = new EnemyDatabase[Waves.Length];
            // }
            // Enemies = new Dictionary<EnemyType, int>();
        }

        public void OnAfterDeserialize()
        {

        }
    }
}