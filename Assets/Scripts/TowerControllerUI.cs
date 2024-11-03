using UISpace;
using UnityEngine;

namespace TowerSpace
{
    public class TowerControllerUI : MonoBehaviour
    {
        private void Awake()
        {
            SelectingTowers.OnTowerSelected += ShowTowerUI;
            SelectingTowers.OnTowerUnselected += HideTowerUI;
        }

        private void ShowTowerUI(object sender, SelectingTowers.OnSelected towerSelectedArgs)
        {
            if (towerSelectedArgs != null)
            {
                // Tower currentTowwer = towerSelectedArgs.TowerSelected.GetComponent<Builder>()._buildingTower.transform.chi.GetComponent<Tower>()._towerType == towerType;
                UpgradeTowerUI uiTower = towerSelectedArgs.TowerSelected.GetComponent<UpgradeTowerUI>();
                uiTower.HideArrowUpgrade();

                // if (currentTowwer. == TowerType.None)
                // {
                //     uiTower.ShowAvailableBuild();
                // }   
            }
        }

        private void HideTowerUI(object sender, SelectingTowers.OnSelected towerSelectedArgs)
        {
            UpgradeTowerUI uiTower = towerSelectedArgs.TowerSelected.GetComponent<UpgradeTowerUI>();
            uiTower.ShowArrowUpgrade();
        }
        
        private void OnDisable()
        {
            SelectingTowers.OnTowerSelected -= ShowTowerUI;
            SelectingTowers.OnTowerUnselected -= HideTowerUI;
        }
    }   
}