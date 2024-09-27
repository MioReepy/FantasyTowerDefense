using UnityEngine;

namespace TowerSpace
{
    public class TowerObject : ScriptableObject
    {
        [SerializeField] internal int ID;
        [SerializeField] internal TowerType towerType;
        [SerializeField] internal GameObject[] towerPrefab;
    }
}