using System;
using UnityEngine;

namespace TowerSpace
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject _emptyTower;
        [SerializeField] private GameObject _baseTower;
        [SerializeField] private GameObject _buildingTower;
        [SerializeField] internal Tower tower;
        
        public static event EventHandler<OnUpgrade> OnUpgradeTower;
        public class OnUpgrade : EventArgs
        {
            public GameObject SelectedTower;
        }

        internal void OnButtonClick(TowerType towerType)
        {
            BuildSelectedTower(towerType);

            OnUpgradeTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });
        }

        private void BuildSelectedTower(TowerType towerType)
        {
            if (_emptyTower.activeInHierarchy)
            {
                BuildNewTower(towerType);
            }
            else
            {
                UpgradeTower();
            }
        }

        private void BuildNewTower(TowerType towerType)
        {
            _emptyTower.SetActive(false);
            _baseTower.SetActive(true);
                
            for (int child = 0; child < _buildingTower.transform.childCount; child++)
            {
                tower = _buildingTower.transform.GetChild(child).GetComponent<Tower>();
                if (tower._towerType == towerType)
                {
                    tower._currentTower = _buildingTower.transform.GetChild(child).gameObject;
                    tower._currentTower.SetActive(true);
                    tower.currentTowerLevel = 0;
                    break;
                }
            }
        }

        private void UpgradeTower()
        {
            if (tower.currentTowerLevel < tower.gameObject.transform.childCount - 1)
            {
                ActiveNewStageTower(false);
                tower.currentTowerLevel++;
                ActiveNewStageTower(true);
            }
        }

        private void ActiveNewStageTower(bool isActive)
        {
            tower.transform.GetChild(tower.currentTowerLevel).gameObject.SetActive(isActive);
            _baseTower.transform.GetChild(tower.currentTowerLevel).gameObject.SetActive(isActive);
        }
    }
}