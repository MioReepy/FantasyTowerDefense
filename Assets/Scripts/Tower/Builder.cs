using System;
using System.Collections;
using UnityEngine;

namespace TowerSpace
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject _baseTower;
        [SerializeField] private GameObject _buildingEffect;
        [SerializeField] private GameObject _emptyTower;
        [SerializeField] private float timerBuildingTower = 5f;
        private SelectingTowers _selectingTowers;
        private TowerInformation _towerInformation;

        private GameObject _tower;
        
        public static event EventHandler<OnUpgrade> OnStartBuildingNewTower;
        public static event EventHandler<OnUpgrade> OnStartUpgradeTower;

        public class OnUpgrade : EventArgs
        {
            public GameObject SelectedTower;
        }

        public static void ResetStaticData()
        {
            OnStartBuildingNewTower = null;
            OnStartUpgradeTower = null;
        }

        private void Start()
        {
            _selectingTowers = gameObject.GetComponent<SelectingTowers>();
            _towerInformation = gameObject.GetComponent<TowerInformation>();
        }

        internal void OnButtonClick(TowerType towerType)
        {
            gameObject.GetComponent<BuyTower>().BuyTowerObject();
            SoundManager.Instance.TowerBuildingSound();
            
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

            _baseTower.SetActive(true);
            _tower = Instantiate(_towerInformation.towerPrefab, _towerInformation._currentTower.transform);

            _buildingEffect.SetActive(false);
            _selectingTowers.isAvailableBuild = true;
        }

        private IEnumerator UpgradeTower()
        {
            OnStartUpgradeTower?.Invoke(this, new OnUpgrade
            {
                SelectedTower = gameObject
            });
            
            _selectingTowers.isAvailableBuild = false;
            
            _selectingTowers.OnEscapeDown();
            _buildingEffect.SetActive(true);
            Destroy(_tower);

            yield return new WaitForSeconds(timerBuildingTower);
            
            _tower = Instantiate(_towerInformation.towerPrefab, _towerInformation._currentTower.transform);
            
            _buildingEffect.SetActive(false);
            _selectingTowers.isAvailableBuild = true;
        }
    }
}