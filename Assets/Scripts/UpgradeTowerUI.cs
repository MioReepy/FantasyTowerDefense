using UnityEngine;

namespace UISpace
{
    public class UpgradeTowerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowAvailableUpgrade;
        [SerializeField] internal GameObject availableBuild;
        [SerializeField] internal GameObject availableUpgrade;

        internal void HideArrowUpgrade()
        {
            _arrowAvailableUpgrade.gameObject.SetActive(false);
        }

        // internal void HideAvailableBuild()
        // {
        //     availableBuild.gameObject.SetActive(false);
        // }
        //
        // internal void HideAvailableUpgrade()
        // {
        //     availableUpgrade.gameObject.SetActive(false);
        // }

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
            availableUpgrade.gameObject.SetActive(true);
        }
    }
}