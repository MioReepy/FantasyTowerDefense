using PlayerSpace;
using TowerSpace;
using UISpace;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    private int _counter;

    internal void BuyTowerObject()
    {
        Tower _buyTowerlevel = gameObject.GetComponent<Builder>().tower.transform.GetComponent<Tower>();
        Tower _buyTowercost = gameObject.GetComponent<UpgradeTowerUI>().currentButton.transform.GetComponent<Tower>();
        int costTower = _buyTowercost._towerCost[_buyTowerlevel.currentTowerLevel - 1];

        PlayerStats.Instance.SetMoney(costTower);
    }
}