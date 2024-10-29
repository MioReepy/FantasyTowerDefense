using UnityEngine;

namespace TowerSpace
{
    public enum TowerType
    {
        Crossbow = 0,
        Crystal = 1,
        Mortar = 2,
        Tesla = 3,
    }
    
    public class Tower : MonoBehaviour
    {
        [SerializeField] internal TowerType _towerType;
        internal int currentTowerLevel;

        private void Start()
        {
            currentTowerLevel = 0;
        }
    }
}