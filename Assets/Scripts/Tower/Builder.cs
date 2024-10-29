using UnityEngine;

namespace TowerSpace
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject _emptyTower;
        [SerializeField] private GameObject _baseTower;
        [SerializeField] private GameObject _buildingTower;
        
        private TowerType _towerType;
        private GameObject _currentTower;
        private int _currentIndexTower = 0;
        private void Update()
        {
            if (gameObject.GetComponent<SelectingTowers>().isTowerSelected && (Input.GetKeyDown(KeyCode.Keypad1) || 
                Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4)))
            {
                _towerType = BuildTower.Instance.GetTowerToBuild(Input.inputString);
                BuildSelectedTower(_towerType);
            }
        }

        private void BuildSelectedTower(TowerType towerType)
        {
            if (_emptyTower.activeInHierarchy)
            {
                BuildNewTower(towerType);
            }
            else
            {
                UpgradeTower(towerType);
            }
        }

        private void BuildNewTower(TowerType towerType)
        {
            _emptyTower.SetActive(false);
            _baseTower.SetActive(true);
                
            for (int child = 0; child < _buildingTower.transform.childCount; child++)
            {
                if (_buildingTower.transform.GetChild(child).GetComponent<Tower>()._towerType == towerType)
                {
                    _buildingTower.transform.GetChild(child).gameObject.SetActive(true);
                    _currentTower = _buildingTower.transform.GetChild(child).gameObject;
                    _currentTower.GetComponent<Tower>().currentTowerLevel = 0;
                    _currentIndexTower = child;
                    break;
                }
            }
        }

        private void UpgradeTower(TowerType towerType)
        {
            if (BuildTower.Instance.GetTowerToBuild(Input.inputString) ==
                _currentTower.GetComponent<Tower>()._towerType && _currentTower.GetComponent<Tower>().currentTowerLevel < _currentTower.transform.childCount - 1)
            {
                ActiveNewStageTower(false);
                _currentTower.GetComponent<Tower>().currentTowerLevel++;
                ActiveNewStageTower(true);
            }
        }

        private void ActiveNewStageTower(bool isActive)
        {
            _buildingTower.transform.GetChild(_currentIndexTower).GetChild(_currentTower.GetComponent<Tower>()
                .currentTowerLevel).gameObject.SetActive(isActive);
            _baseTower.transform.GetChild(_currentTower.GetComponent<Tower>()
                .currentTowerLevel).gameObject.SetActive(isActive);
        }
    }
}