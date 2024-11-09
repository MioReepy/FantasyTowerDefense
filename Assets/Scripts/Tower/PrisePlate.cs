using TMPro;
using TowerSpace;
using UnityEngine;
using UnityEngine.UI;

public class PrisePlate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priseText;
    [SerializeField] private TextMeshProUGUI _maxText;
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _tower;

    private void OnEnable()
    {
        if (_tower.GetComponent<TowerInformation>().currentTowerLevel == 0)
        {
            _priseText.text = gameObject.GetComponent<Tower>()._towerObjects[0].towerCost.ToString();
        }
        else if (_tower.GetComponent<TowerInformation>().currentTowerLevel >= _tower.GetComponent<TowerInformation>().towerObjects.Length)
        {
            _priseText.gameObject.SetActive(false);
            _icon.gameObject.SetActive(false);
            _maxText.gameObject.SetActive(true);
        }
        else
        {
            _priseText.text = _tower.GetComponent<TowerInformation>().towerObjects[_tower.GetComponent<TowerInformation>().currentTowerLevel].towerCost.ToString();
        }
    }
}
