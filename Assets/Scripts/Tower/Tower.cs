using UnityEngine;

namespace TowerSpace
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] internal TowerType _towerType;
        [SerializeField] internal TowerObject[] _towerObjects;
        [SerializeField] internal GameObject mainTowerPrefab;
    }
}