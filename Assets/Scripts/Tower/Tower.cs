using UnityEngine;

namespace TowerSpace
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] internal TowerType _towerType;
        internal GameObject _currentTower;
        internal int currentTowerLevel = 0;

        private void Start()
        {
            currentTowerLevel = 0;
            _towerType = TowerType.None;
        }
    }
}