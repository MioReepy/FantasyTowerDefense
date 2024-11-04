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
            availableBuild.gameObject.SetActive(true);
        }

        internal void ShowAvailableUpgrade()
        {
            for (int i = 0; i < _currentTowerButton.childCount; i++)
            {
                if (_currentTowerButton.GetChild(i).GetComponent<Tower>()._towerType ==
                    gameObject.GetComponent<Builder>().tower._towerType)
                {
                    _currentTowerButton.GetChild(i).gameObject.SetActive(true);
                }
            }

            availableUpgrade.gameObject.SetActive(true);
        }
    }
}