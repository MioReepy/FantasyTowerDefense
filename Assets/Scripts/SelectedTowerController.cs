using System;
using PlayerSpace;
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
        }

        private void SelectingTowers_OnSelect(object sender, SelectingTowers.OnSelected tower)
        {
            if (selectedTowerController != null)
            {
                selectedTowerController.GetComponent<SelectingTowers>().OnEscapeDown();
            }
            
            selectedTowerController = tower.TowerSelected;
        }

        private void OnDisable()
        {
            SelectingTowers.OnTowerSelected -= SelectingTowers_OnSelect;
        }
    }
}