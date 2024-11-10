using PlayerSpace;
using UnityEngine;

namespace TowerSpace
{
    public class AvailableUpgrade : MonoBehaviour
    {
        [SerializeField] private GameObject _arrow;
        [SerializeField] private GameObject _availableBuild;

        private void Update()
        {
            _arrow.SetActive(true);

            if (gameObject.GetComponent<TowerInformation>().towerCost == 0)
            {
                for (int i = 0; i < _availableBuild.transform.childCount; i++)
                {
                    var Tower = _availableBuild.transform.GetChild(i).GetComponent<Tower>()._towerObjects;
                    
                    for (int j = 0; j < Tower.Length; j++)
                    {
                        _arrow.SetActive(false);

                        if (Tower[j].towerCost >= PlayerStats.Instance.money) continue;
                        
                        _arrow.SetActive(true);
                        return;
                    }
                }
                
                return;
            }
            
            TowerInformation towerInformation = gameObject.GetComponent<TowerInformation>();

            if (towerInformation.towerObjects != null &&
                towerInformation.currentTowerLevel > towerInformation.towerObjects.Length - 1)
            {
                _arrow.SetActive(false);
                return;
            }

            int towerCost = gameObject.GetComponent<TowerInformation>()
                .towerObjects[gameObject.GetComponent<TowerInformation>().currentTowerLevel].towerCost;

            if (towerCost > PlayerStats.Instance.money)
            {
                _arrow.SetActive(false);
                return;
            }
                
            if (!gameObject.GetComponent<SelectingTowers>().isAvailableBuild)
            {
                _arrow.SetActive(false);
            }
        }
    }
}