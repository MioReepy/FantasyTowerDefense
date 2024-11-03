using UISpace;
using UnityEngine;

namespace TowerSpace
{
    public class TowerControllerUI : MonoBehaviour
    {
        private void Awake()
        {
            SelectingTowers.OnTowerSelected += SelectingTowers_OnShowTowerUI;
            SelectingTowers.OnTowerUnselected += SelectingTowers_OnHideTowerUI;
            Builder.OnUpgradeTower += Builder_OnUpgradeUI;
        }

        private void SelectingTowers_OnShowTowerUI(object sender, SelectingTowers.OnSelected towerSelectedArgs)
        {
            if (towerSelectedArgs != null)
            {
                Tower currentTower = towerSelectedArgs.TowerSelected.GetComponent<Builder>().tower;
                
                UpgradeTowerUI uiTower = towerSelectedArgs.TowerSelected.GetComponent<UpgradeTowerUI>();
                uiTower.HideArrowUpgrade();

                if (currentTower == null)
                {
                    uiTower.ShowAvailableBuild();
                }
                else
                {
                    uiTower.ShowAvailableUpgrade();
                }
            }
        }

        private void SelectingTowers_OnHideTowerUI(object sender, SelectingTowers.OnSelected towerSelectedArgs)
        {
            UpgradeTowerUI uiTower = towerSelectedArgs.TowerSelected.GetComponent<UpgradeTowerUI>();
            uiTower.ShowArrowUpgrade();
            
            if (uiTower.availableBuild.activeInHierarchy)
            {
                uiTower.HideAvailableBuild();
            }            
            
            if (uiTower.availableUpgrade.activeInHierarchy)
            {
                uiTower.HideAvailableUpgrade();
            }
        }

        private void Builder_OnUpgradeUI(object sender, Builder.OnUpgrade towerUpgradeArgs)
        {
            UpgradeTowerUI uiTower = towerUpgradeArgs.SelectedTower.GetComponent<UpgradeTowerUI>();

            if (uiTower.availableBuild.activeInHierarchy)
            {
                uiTower.HideAvailableBuild();
                uiTower.ShowAvailableUpgrade();
            }
        }

        private void OnDisable()
        {
            SelectingTowers.OnTowerSelected -= SelectingTowers_OnShowTowerUI;
            SelectingTowers.OnTowerUnselected -= SelectingTowers_OnHideTowerUI;
            Builder.OnUpgradeTower -= Builder_OnUpgradeUI;
        }
    }   
}