using UISpace;
using UnityEngine;

namespace TowerSpace
{
    public class BuildTowerButton : MonoBehaviour
    {
        public void OnCrossbowButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crossbow);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentTower(TowerType.Crossbow);
        }
        
        public void OnMortalButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Mortar);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentTower(TowerType.Mortar);
        }
        
        public void OnTeslaButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Tesla);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentTower(TowerType.Tesla);
        }
        
        public void OnCrystalButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crystal);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentTower(TowerType.Crystal);
        }
    }
}