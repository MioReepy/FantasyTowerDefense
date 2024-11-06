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
        [SerializeField] private GameObject _emptyTower;
        [SerializeField] private float timerBuildingTower = 5f;

        internal Tower tower;
        private SelectingTowers _selectingTowers;
        
        public static event EventHandler<OnUpgrade> OnStartBuildingNewTower;
        public static event EventHandler<OnUpgrade> OnStartUpgradeTower;
        public static event EventHandler<OnUpgrade> OnEndBuildingTower;
        public class OnUpgrade : EventArgs
        {
            public GameObject SelectedTower;
        }

        private void Start()
        {
            _selectingTowers = gameObject.GetComponent<SelectingTowers>();
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
                StartCoroutine(UpgradeTower());
            }
        }

        private IEnumerator BuildNewTower(TowerType towerType)
        {
            OnStartBuildingNewTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });

            _selectingTowers.isAvailableBuild = false;
            _selectingTowers.OnEscapeDown();
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
                    break;
                }
            }
            
            _buildingEffect.SetActive(false);
            _selectingTowers.isAvailableBuild = true;
            tower.currentTowerLevel++;
            
            OnEndBuildingTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });
            
            gameObject.GetComponent<BuyTower>().BuyTowerObject();
        }

        private IEnumerator UpgradeTower()
        {
            OnStartUpgradeTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });
            
            _selectingTowers.isAvailableBuild = false;

            if (tower.currentTowerLevel == 0)
            {
                tower.currentTowerLevel++;
            }
            
            _selectingTowers.OnEscapeDown();
            _buildingEffect.SetActive(true);
            ActiveNewStageTower(false);
            tower.currentTowerLevel++;

            yield return new WaitForSeconds(timerBuildingTower);

            ActiveNewStageTower(true);
            _buildingEffect.SetActive(false);
            _selectingTowers.isAvailableBuild = true;
            
            OnEndBuildingTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });
            
            gameObject.GetComponent<BuyTower>().BuyTowerObject();
        }

        private void ActiveNewStageTower(bool isActive)
        {
            tower.transform.GetChild(tower.currentTowerLevel - 1).gameObject.SetActive(isActive);
            _baseTower.transform.GetChild(tower.currentTowerLevel - 1).gameObject.SetActive(isActive);
        }
    }
}