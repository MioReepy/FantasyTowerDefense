using UnityEngine;

namespace TowerSpace
{
    public class BuildTower : MonoBehaviour
    {
        #region Singleton

        public static BuildTower Instance;
        private void Awake() => Instance = this;

        #endregion

        [SerializeField] private GameObject[] _towerPrefabs;
        private GameObject _towerToBuild;

        private void Start()
        {
            _towerToBuild = _towerPrefabs[Random.Range(0, _towerPrefabs.Length)];
        }

        internal GameObject GetTowerToBuild() => _towerToBuild;
    }
}