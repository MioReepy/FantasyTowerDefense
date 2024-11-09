using UnityEngine;

namespace TowerSpace
{
    public class TowerInformation : MonoBehaviour
    {
        [SerializeField] private Transform _towersParent;
        [SerializeField] internal TowerObject[] towerObjects;
        [SerializeField] internal TowerType towerType;
        [SerializeField] internal GameObject towerPrefab;
        [SerializeField] internal int towerCost;
        [SerializeField] internal int damageTower;
        
        internal TowerObject _currentTowerObject;
        internal Tower _currentTower;
        internal int currentTowerLevel = 0;

        internal void SetTowerInformation(TowerType towerType)
        {
            if (currentTowerLevel < 1)
            {
                for (int i = 0; i < _towersParent.childCount; i++)
                {
                    if (_towersParent.GetChild(i).GetComponent<Tower>()._towerType == towerType)
                    {
                        this.towerType = towerType;
                        _currentTower = _towersParent.GetChild(i).GetComponent<Tower>();
                        towerObjects = new TowerObject[_currentTower._towerObjects.Length];
                        break;
                    }
                }

                for (int i = 0; i < _currentTower._towerObjects.Length; i++)
                {
                    towerObjects[i] = _currentTower._towerObjects[i];
                }
            }

            _currentTower.gameObject.SetActive(true);
            _currentTowerObject = towerObjects[currentTowerLevel];
            towerCost = _currentTowerObject.towerCost;
            damageTower = _currentTowerObject.towerDamage;
            towerPrefab = _currentTowerObject.TowerPrefab;
            currentTowerLevel++;
        }
    }
}