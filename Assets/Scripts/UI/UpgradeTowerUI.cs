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

        internal void ShowAvailableBuild()
        {
            Transform tower = availableBuild.gameObject.transform.GetChild(0).transform;

            for (int i = 0; i < tower.childCount; i++)
            {
                SwitchButtons buttons = tower.GetChild(i).transform.GetComponent<SwitchButtons>();
                int towerCost = tower.GetChild(i).transform.GetComponent<Tower>()
                    ._towerCost[tower.GetChild(i).transform.GetComponent<Tower>().currentTowerLevel];
                
                if (towerCost > PlayerStats.Instance.money)
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

            int towerCost = currentButton.transform.GetComponent<Tower>()
                ._towerCost[currentButton.transform.GetComponent<Tower>().currentTowerLevel];

            if (towerCost > PlayerStats.Instance.money 
                || gameObject.GetComponent<Builder>().tower.currentTowerLevel >= gameObject.GetComponent<Builder>().tower.transform.childCount)
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
            
            Debug.Log(currentButton.transform.GetComponent<Tower>().currentTowerLevel);
        }

        internal void SetCurrentTower(TowerType towerType)
        {
            for (int i = 0; i < currentTowerButton.childCount; i++)
            {
                if (currentTowerButton.GetChild(i).GetComponent<Tower>()._towerType == towerType)
                {
                    currentButton = currentTowerButton.GetChild(i).gameObject;
                    currentButton.SetActive(true);
                }
            }
        }
    }
}