using PlayerSpace;
using TowerSpace;
using UnityEngine;

namespace UISpace
{
    public class UpgradeTowerUI : MonoBehaviour
    {
        [SerializeField] internal GameObject availableBuild;
        [SerializeField] internal GameObject availableUpgrade;
        private GameObject _currentButton;

        internal void HideAvailableBuild()
        {
            availableBuild.gameObject.SetActive(false);
        }
        
        internal void HideAvailableUpgrade()
        {
            availableUpgrade.gameObject.SetActive(false);
        }

        internal void SetCurrentButton(TowerType towerType)
        {
            for (int i = 0; i < availableUpgrade.transform.childCount; i++)
            {
                if (availableUpgrade.transform.GetChild(i).GetComponent<Tower>()._towerType != towerType) continue;
                
                _currentButton = availableUpgrade.transform.transform.GetChild(i).gameObject;
                _currentButton.SetActive(true);
            }
        }

        internal void ShowAvailableBuild()
        {
            Transform tower = availableBuild.gameObject.transform;

            for (int i = 0; i < tower.childCount; i++)
            {
                SwitchButtons buttons = tower.GetChild(i).transform.GetComponent<SwitchButtons>();
                
                if (tower.GetChild(i).GetComponent<Tower>()._towerObjects[0].towerCost > PlayerStats.Instance.money)
                {
                    buttons.onButton.SetActive(false);
                    buttons.offButton.SetActive(true);
                }
                else
                {
                    buttons.onButton.SetActive(true);
                    buttons.offButton.SetActive(false);
                }
            }

            availableBuild.gameObject.SetActive(true);
        }

        internal void ShowAvailableUpgrade()
        {
            SwitchButtons buttons = _currentButton.transform.GetComponent<SwitchButtons>();

            buttons.onButton.SetActive(true);
            buttons.offButton.SetActive(false);
            
            if (gameObject.GetComponent<TowerInformation>().currentTowerLevel <
                gameObject.GetComponent<TowerInformation>().towerObjects.Length)
            {
                int towerCost = gameObject.GetComponent<TowerInformation>()
                    .towerObjects[gameObject.GetComponent<TowerInformation>().currentTowerLevel].towerCost;
                
                if (towerCost > PlayerStats.Instance.money)
                {
                    buttons.onButton.SetActive(false);
                    buttons.offButton.SetActive(true);
                }
            }
            
            if (gameObject.GetComponent<TowerInformation>().currentTowerLevel > gameObject.GetComponent<TowerInformation>().towerObjects.Length - 1)
            {
                buttons.onButton.SetActive(false);
                buttons.offButton.SetActive(true);
            }

            availableUpgrade.gameObject.SetActive(true);
        }
    }
}