using UnityEngine;

namespace TowerSpace
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject _emptyTower;
        [SerializeField] private GameObject _baseTower;
        [SerializeField] private GameObject _buildingTower;
        
        private Tower _tower;
        private TowerType _towerType;
        private GameObject _currentTower;
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
                Debug.Log("New Tower");
            }
            else
            {
                UpgradeTower();
                Debug.Log("Upgrade Tower");
            }
        }

        private void BuildNewTower(TowerType towerType)
        {
            _emptyTower.SetActive(false);
            _baseTower.SetActive(true);
                
            for (int child = 0; child < _buildingTower.transform.childCount; child++)
            {
                _tower = _buildingTower.transform.GetChild(child).GetComponent<Tower>();
                if (_tower._towerType == towerType)
                {
                    _tower._currentTower = _buildingTower.transform.GetChild(child).gameObject;;
                    _tower._currentTower.SetActive(true);
                    _tower.currentTowerLevel = 0;
                    break;
                }
            }
        }

        private void UpgradeTower()
        {
            if (_tower.currentTowerLevel < _tower.transform.childCount - 1)
            {
                ActiveNewStageTower(false);
                _tower.currentTowerLevel++;
                ActiveNewStageTower(true);
            }
        }

        private void ActiveNewStageTower(bool isActive)
        {
            _tower.transform.GetChild(_tower.currentTowerLevel).gameObject.SetActive(isActive);
            _baseTower.transform.GetChild(_tower.currentTowerLevel).gameObject.SetActive(isActive);
        }
    }
}