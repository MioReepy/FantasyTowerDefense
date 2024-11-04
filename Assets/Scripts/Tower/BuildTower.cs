using System;
using UnityEngine;

namespace TowerSpace
{
    public class BuildTower : MonoBehaviour
    {
        private GameObject tower;
        private void OnEnable()
        {
            SelectingTowers.OnTowerSelected += SelectingTowersOnOnTowerSelected;
        }

        private void SelectingTowersOnOnTowerSelected(object sender, SelectingTowers.OnSelected selectingTowers)
        {
            tower = selectingTowers.TowerSelected;
            Debug.Log(tower);
        }

        public void OnCrossbowButtonClicked()
        {
            tower.GetComponent<Builder>().OnButtonClick(TowerType.Crossbow);
        }
    }
}