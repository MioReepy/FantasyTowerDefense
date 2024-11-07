using PlayerSpace;
using TowerSpace;
using UnityEngine;

namespace UISpace
{
    public class UpgradeTowerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowAvailableUpgrade;
        [SerializeField] internal GameObject availableBuild;
        [SerializeField] internal GameObject availableUpgrade;
        [SerializeField] internal Transform currentTowerButton;
        
        internal GameObject currentButton;

        internal void HideArrowUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(false);
        }

        internal void HideAvailableBuild()
        {
            availableBuild.gameObject.SetActive(false);
        }
        
        internal void HideAvailableUpgrade()
        {
            availableUpgrade.gameObject.SetActive(false);
        }

        internal void ShowArrowUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(true);
        }

        internal void SetCurrentButton(TowerType towerType)
        {
            for (int i = 0; i < currentTowerButton.childCount; i++)
            {
                if (currentTowerButton.GetChild(i).GetComponent<Tower>()._towerType == towerType)
                {
                    currentButton = currentTowerButton.transform.GetChild(i).gameObject;
                    currentButton.SetActive(true);
                }
            }
        }

        internal void ShowAvailableBuild()
        {
            Transform tower = availableBuild.gameObject.transform.GetChild(0).transform;

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
            SwitchButtons buttons = currentButton.transform.GetComponent<SwitchButtons>();

            int towerCost = gameObject.GetComponent<TowerInformation>().towerCost;

            if (towerCost > PlayerStats.Instance.money 
                || gameObject.GetComponent<TowerInformation>().currentTowerLevel >= gameObject.GetComponent<TowerInformation>().towerObjects.Length)
            {
                buttons.onButton.SetActive(false);
                buttons.offButton.SetActive(true);
            }
            else
            {
                buttons.onButton.SetActive(true);
                buttons.offButton.SetActive(false);
            }

            availableUpgrade.gameObject.SetActive(true);
        }
    }
}