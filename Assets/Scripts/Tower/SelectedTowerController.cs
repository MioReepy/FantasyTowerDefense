using UnityEngine;

namespace TowerSpace
{
    public class SelectedTowerController : MonoBehaviour
    {
        [SerializeField] private GameObject towers;
        private GameObject selectedTowerController;
        
        private void Start()
        {
            SelectingTowers.OnTowerSelected += SelectingTowers_OnSelect;
            SelectingTowers.OnTowerUnselected += SelectingTowers_OnHideTowerUI;
        }

        private void SelectingTowers_OnSelect(object sender, SelectingTowers.OnSelected tower)
        {
            if (selectedTowerController != null)
            {
                selectedTowerController.GetComponent<SelectingTowers>().OnEscapeDown();
            }
            
            selectedTowerController = tower.TowerSelected;
        }

        private void SelectingTowers_OnHideTowerUI(object sender, SelectingTowers.OnSelected e)
        {
            selectedTowerController = null;
        }

        private void OnDisable()
        {
            SelectingTowers.OnTowerSelected -= SelectingTowers_OnSelect;
            SelectingTowers.OnTowerUnselected -= SelectingTowers_OnHideTowerUI;
        }
    }
}