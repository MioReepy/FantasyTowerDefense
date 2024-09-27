using System;
using UnityEngine;

namespace TowerSpace
{
    [CreateAssetMenu(fileName = "Crossbow Tower", menuName = "ScriptableObject/Tower/Crossbow Tower")]
    [Serializable]
    public class CrossbowTower : TowerObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 02;
            towerType = TowerType.Crossbow;
        }
    }
}