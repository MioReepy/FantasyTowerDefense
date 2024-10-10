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
            "2" => TowerType.Cannon,
            "3" => TowerType.Crystal,
            "4" => TowerType.Mortar,
            _ => throw new ArgumentOutOfRangeException(nameof(Event.current.keyCode), Event.current.keyCode, null)
        };
    }
}