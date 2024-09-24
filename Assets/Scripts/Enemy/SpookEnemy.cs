using System;
using UnityEngine;

namespace EnemySpace
{
    [CreateAssetMenu(fileName = "Spook Enemy", menuName = "Enemy/Enemy Type/Spook Enemy")]
    [Serializable]
    public class SpookEnemy : EnemyObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 03;
            enemyType = EnemyType.Spook;
        }
    }
}