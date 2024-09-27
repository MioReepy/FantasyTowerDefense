using System;
using UnityEngine;

namespace TowerSpace
{
    [CreateAssetMenu(fileName = "Mortar Tower", menuName = "ScriptableObject/Tower/Mortar Tower")]
    [Serializable]
    public class MortalTower : TowerObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 04;
            towerType = TowerType.Mortar;
        }
    }
}