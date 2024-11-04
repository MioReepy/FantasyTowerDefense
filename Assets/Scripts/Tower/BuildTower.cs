using UnityEngine;

namespace TowerSpace
{
    public class BuildTower : MonoBehaviour
    {
        public void OnCrossbowButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crossbow);
            Debug.Log($"Tower Crossbow clicked");
        }
        
        public void OnMortalButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Mortar);
            Debug.Log($"Tower Crossbow clicked");
        }
        
        public void OnTeslaButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Tesla);
            Debug.Log($"Tower Crossbow clicked");
        }
        
        public void OnCrystalButtonClicked()
        {
            gameObject.GetComponent<Builder>().OnButtonClick(TowerType.Crystal);
            Debug.Log($"Tower Crossbow clicked");
        }
    }
}