using UnityEngine;

namespace TowerSpace
{
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