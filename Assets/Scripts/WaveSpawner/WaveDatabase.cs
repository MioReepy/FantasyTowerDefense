using System.Collections.Generic;
using EnemySpace;
using UnityEngine;

namespace WaveSpawnerSpace
{
    [CreateAssetMenu(fileName = "Wave Database", menuName = "Wave Database")]
    public class WaveDataBase : ScriptableObject, ISerializationCallbackReceiver
    {
        public EnemyObject[] Enemies;
        internal List<EnemyObject> GetEnemy;
        
        public void OnBeforeSerialize()
        {
            if (Enemies != null)
            {
                GetEnemy = new List<EnemyObject>();
            }
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].ID = i;
                GetEnemy.Add(Enemies[i]);
            }
        }
    }
}