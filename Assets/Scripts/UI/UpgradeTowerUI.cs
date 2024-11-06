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
        
        [SerializeField] private Transform _currentTowerButton;

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
            Transform tower = availableUpgrade.gameObject.transform.GetChild(0).transform;

            for (int i = 0; i < _currentTowerButton.childCount; i++)
            {
                if (_currentTowerButton.GetChild(i).GetComponent<Tower>()._towerType ==
                    gameObject.GetComponent<Builder>().tower._towerType)
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

                    _currentTowerButton.GetChild(i).gameObject.SetActive(true);
                }
            }

            availableUpgrade.gameObject.SetActive(true);
        }
    }
}