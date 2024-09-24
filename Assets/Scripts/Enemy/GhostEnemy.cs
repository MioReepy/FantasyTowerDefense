using System;
using UnityEngine;

namespace EnemySpace
{
    [CreateAssetMenu(fileName = "Ghost Enemy", menuName = "Enemy/Enemy Type/Ghost Enemy")]
    [Serializable]
    public class GhostEnemy : EnemyObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 01;
            enemyType = EnemyType.Ghost;
        }
    }
}