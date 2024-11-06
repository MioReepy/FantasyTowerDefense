using PlayerSpace;
using TowerSpace;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    private Tower _buyTower;

    private void Start()
    {
        _buyTower = gameObject.GetComponent<Tower>();
    }

    public void BuyTowerObject()
    {
        PlayerStats.Instance.money -= _buyTower._towerCost[_buyTower.currentTowerLevel];
        Debug.Log(PlayerStats.Instance.money);
    }
}
