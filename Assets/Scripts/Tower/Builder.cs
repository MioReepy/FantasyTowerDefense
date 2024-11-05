using System;
using System.Collections;
using UnityEngine;

namespace TowerSpace
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject _baseTower;
        [SerializeField] private GameObject _buildingTower;
        [SerializeField] private GameObject _buildingEffect;
        [SerializeField] internal Tower tower;
        [SerializeField] private GameObject _emptyTower;
        [SerializeField] private float timerBuildingTower = 5f;
        
        public static event EventHandler<OnUpgrade> OnUpgradeTower;
        public class OnUpgrade : EventArgs
        {
            public GameObject SelectedTower;
        }

        internal void OnButtonClick(TowerType towerType)
        {
            BuildSelectedTower(towerType);
        }

        private void BuildSelectedTower(TowerType towerType)
        {
            if (_emptyTower.activeInHierarchy)
            {
                StartCoroutine(BuildNewTower(towerType));
            }
            else
            {
                UpgradeTower();
            }
        }

        private IEnumerator BuildNewTower(TowerType towerType)
        {
            _buildingEffect.SetActive(true);
            _emptyTower.SetActive(false);
            
            yield return new WaitForSeconds(timerBuildingTower);
            
            for (int child = 0; child < _buildingTower.transform.childCount; child++)
            {
                _baseTower.SetActive(true);

                tower = _buildingTower.transform.GetChild(child).GetComponent<Tower>();
                if (tower._towerType == towerType)
                {
                    tower._currentTower = _buildingTower.transform.GetChild(child).gameObject;
                    tower._currentTower.SetActive(true);
                    tower.currentTowerLevel = 0;
                    break;
                }
            }

            _buildingEffect.SetActive(false);

            OnUpgradeTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });
            
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