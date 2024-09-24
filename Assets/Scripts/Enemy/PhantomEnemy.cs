using System;
using UnityEngine;

namespace EnemySpace
{
    [CreateAssetMenu(fileName = "Phantom Enemy", menuName = "Enemy/Enemy Type/Phantom Enemy")]
    [Serializable]
    public class PhantomEnemy : EnemyObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 02;
            enemyType = EnemyType.Phantom;
        }
    }
}