using System;
using UnityEngine;

namespace TowerSpace
{
    [CreateAssetMenu(fileName = "Cannon Tower", menuName = "ScriptableObject/Tower/Cannon Tower")]
    [Serializable]
    public class CannonTower : TowerObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 01;
            towerType = TowerType.Cannon;
        }
    }
}