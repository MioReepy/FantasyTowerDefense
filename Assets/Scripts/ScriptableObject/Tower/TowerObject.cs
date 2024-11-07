using System;
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

    [CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObject/Tower")]
    [Serializable]
    public class TowerObject : ScriptableObject
    {
        public TowerType TowerType;
        public int towerCost;
        public int towerDamage;
        public int towerLevel;
        public GameObject TowerPrefab;
        public Sprite AvailableTowerSprite;
        public Sprite UnavailableTowerSprite;
    }
}