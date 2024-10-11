using System;
using UnityEngine;

namespace TowerSpace
{
    public class BuildTower : MonoBehaviour
    {
        #region Singleton

        public static BuildTower Instance;
        private void Awake() => Instance = this;

        #endregion
        
        internal TowerType GetTowerToBuild(string key) => key switch
        {
            "1" => TowerType.Crossbow,
            "2" => TowerType.Crystal,
            "3" => TowerType.Mortar,
            "4" => TowerType.Tesla,
            _ => throw new ArgumentOutOfRangeException(nameof(Event.current.keyCode), Event.current.keyCode, null)
        };
    }
}