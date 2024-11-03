using UnityEngine;

namespace UISpace
{
    public class UpgradeTowerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowAvailableUpgrade;
        [SerializeField] private GameObject _availableBuild;
        [SerializeField] private GameObject _availableUpgrade;

        internal void HideArrowUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(false);
        }

        internal void HideAvailableBuild()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(false);
        }
        
        internal void HideAvailableUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(false);
        }

        internal void ShowArrowUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(true);
        }

        internal void ShowAvailableBuild()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(true);
        }

        internal void ShowAvailableUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(true);
        }
    }
}