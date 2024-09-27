using System;
using UnityEngine;

namespace TowerSpace
{
    [CreateAssetMenu(fileName = "Crystal Tower", menuName = "ScriptableObject/Tower/Crystal Tower\"")]
    [Serializable]
    public class CrystalTower : TowerObject, ISerializationCallbackReceiver
    {
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            ID = 03;
            towerType = TowerType.Crystal;
        }
    }
}