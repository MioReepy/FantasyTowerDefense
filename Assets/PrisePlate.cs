using TMPro;
using TowerSpace;
using UnityEngine;

public class PrisePlate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priseText;
    [SerializeField] private GameObject _tower;

    // private void Awake()
    // {
    //     if (_tower.GetComponent<TowerInformation>().currentTowerLevel == 0)
    //     {
    //         _priseText.text = gameObject.GetComponent<Tower>()._towerObjects[0].towerCost.ToString();
    //     }
    //     else if (_tower.GetComponent<TowerInformation>().currentTowerLevel >= _tower.GetComponent<TowerInformation>().towerObjects.Length - 2)
    //     {
    //         _priseText.text = "Max";
    //     }
    //     else
    //     {
    //         _priseText.text = _tower.GetComponent<TowerInformation>().towerObjects[_tower.GetComponent<TowerInformation>().currentTowerLevel].towerCost.ToString();
    //     }
    // towerObjects = new TowerObject[_currentTower._towerObjects.Length];
    // }
}
