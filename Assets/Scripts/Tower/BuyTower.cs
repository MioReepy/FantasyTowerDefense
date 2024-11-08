using PlayerSpace;
using TowerSpace;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    private int _counter;

    internal void BuyTowerObject()
    {
        int costTower = gameObject.GetComponent<TowerInformation>().towerCost;

        PlayerStats.Instance.SetMoney(-costTower);
        SoundManager.Instance.TowerSelectedTower();
    }
}