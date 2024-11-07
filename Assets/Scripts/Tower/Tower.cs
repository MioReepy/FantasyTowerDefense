using UnityEngine;

namespace TowerSpace
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] internal TowerType _towerType;
        [SerializeField] internal int[] _towerCost;
        [SerializeField] internal int[] _damageTower;
        internal GameObject _currentTower;
        internal int currentTowerLevel = 0;

        private void Start()
        {
            currentTowerLevel = 0;
        }
    }
}