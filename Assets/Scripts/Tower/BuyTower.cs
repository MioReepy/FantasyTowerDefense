using PlayerSpace;
using TowerSpace;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    private int _counter;

    public void BuyTowerObject()
    {
        int costTower = gameObject.GetComponent<TowerInformation>().towerCost;

        PlayerStats.Instance.SetMoney(-costTower);
        SoundManager.Instance.TowerSelectedTower();
    }
}