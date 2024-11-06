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
        PlayerStats.Instance.money -= _buyTowercost._towerCost[_buyTowerlevel.currentTowerLevel - 1];
        Debug.Log(PlayerStats.Instance.money);
    }
}