using UISpace;
using UnityEngine;

namespace TowerSpace
{
    public class BuildTowerButton : MonoBehaviour
    {
        public void OnCrossbowButtonClicked()
        {
            gameObject.GetComponent<TowerInformation>().SetTowerInformation(TowerType.Crossbow);
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crossbow);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentButton(TowerType.Crossbow);
        }
        
        public void OnMortalButtonClicked()
        {
            gameObject.GetComponent<TowerInformation>().SetTowerInformation(TowerType.Mortar);
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Mortar);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentButton(TowerType.Mortar);
        }
        
        public void OnTeslaButtonClicked()
        {
            gameObject.GetComponent<TowerInformation>().SetTowerInformation(TowerType.Tesla);
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Tesla);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentButton(TowerType.Tesla);
        }
        
        public void OnCrystalButtonClicked()
        {
            gameObject.GetComponent<TowerInformation>().SetTowerInformation(TowerType.Crystal);
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crystal);
            gameObject.GetComponent<UpgradeTowerUI>().SetCurrentButton(TowerType.Crystal);
        }
    }
}