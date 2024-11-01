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

    public class TowerObject : ScriptableObject
    {
        public TowerType TowerType;
        public GameObject TowerPrefab;
        public Sprite TowerSprite; 
    }
}