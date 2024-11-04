using UnityEngine;

namespace TowerSpace
{
    public class BuildTower : MonoBehaviour
    {
        public void OnCrossbowButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crossbow);
        }
        
        public void OnMortalButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Mortar);
        }
        
        public void OnTeslaButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Tesla);
        }
        
        public void OnCrystalButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crystal);
        }
    }
}