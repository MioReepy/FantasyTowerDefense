using PlayerSpace;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCounter;
    private void Start()
    {
        PlayerStats.Instance.OnChangeMoney += PlayerStats_OnChangeMoney;
    }

    private void PlayerStats_OnChangeMoney(object sender, PlayerStats.OnCoins moneyArgs)
    {
        _coinsCounter.text = moneyArgs.coinsCount.ToString();
    }
}
