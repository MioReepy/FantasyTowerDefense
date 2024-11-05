using UISpace;
using UnityEngine;

namespace TowerSpace
{
    public class TowerControllerUI : MonoBehaviour
    {
        private GameObject selectedTower;
        private void Awake()
        {
            SelectingTowers.OnTowerSelected += SelectingTowers_OnShowTowerUI;
            SelectingTowers.OnTowerUnselected += SelectingTowers_OnHideTowerUI;
            Builder.OnStartBuildingTower += Builder_OnBuildingTowerUI;
            Builder.OnStartUpgradeTower += Builder_OnStartUpgradeUI;
        }

        private void SelectingTowers_OnShowTowerUI(object sender, SelectingTowers.OnSelected towerSelectedArgs)
        {
            if (towerSelectedArgs != null)
            {
                selectedTower = towerSelectedArgs.TowerSelected;
                
                UpgradeTowerUI uiTower = selectedTower.GetComponent<UpgradeTowerUI>();

                uiTower.HideArrowUpgrade();
                
                ShowTowerUI(uiTower);
            }
        }

        private void SelectingTowers_OnHideTowerUI(object sender, SelectingTowers.OnSelected towerSelectedArgs)
        {
            UpgradeTowerUI uiTower = towerSelectedArgs.TowerSelected.GetComponent<UpgradeTowerUI>();
            uiTower.ShowArrowUpgrade();

            HideTowerUI(uiTower);
        }

        private void Builder_OnBuildingTowerUI(object sender, Builder.OnUpgrade towerUpgradeArgs)
        {
            UpgradeTowerUI uiTower = towerUpgradeArgs.SelectedTower.GetComponent<UpgradeTowerUI>();

            if (uiTower.availableBuild.activeInHierarchy)
            {
                uiTower.HideAvailableBuild();
            }
        }

        private void Builder_OnStartUpgradeUI(object sender, Builder.OnUpgrade towerUpgradeArgs)
        {
            UpgradeTowerUI uiTower = towerUpgradeArgs.SelectedTower.GetComponent<UpgradeTowerUI>();

            if (uiTower.availableBuild.activeInHierarchy)
            {
                uiTower.HideAvailableUpgrade();
            }
        }

        private void ShowTowerUI(UpgradeTowerUI uiTower)
        {
            if (selectedTower.GetComponent<Builder>().tower == null)
            {
                uiTower.ShowAvailableBuild();
            }
            else
            {
                uiTower.ShowAvailableUpgrade();
            }
        }

        private static void HideTowerUI(UpgradeTowerUI uiTower)
        {
            if (uiTower.availableBuild.activeInHierarchy)
            {
                uiTower.HideAvailableBuild();
            }

            if (uiTower.availableUpgrade.activeInHierarchy)
            {
                uiTower.HideAvailableUpgrade();
            }
        }

        private void OnDisable()
        {
            SelectingTowers.OnTowerSelected -= SelectingTowers_OnShowTowerUI;
            SelectingTowers.OnTowerUnselected -= SelectingTowers_OnHideTowerUI;
            Builder.OnStartBuildingTower -= Builder_OnBuildingTowerUI;
        }
    }   
}