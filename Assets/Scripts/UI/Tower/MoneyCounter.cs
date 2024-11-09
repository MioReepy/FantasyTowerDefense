using System;
using PlayerSpace;
using TMPro;
using UnityEngine;

namespace UISpace
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsCounter;

        private void Awake()
        {
            _coinsCounter.text = PlayerStats.Instance.money.ToString();
        }

        private void Start()
        {
            PlayerStats.Instance.OnChangeMoney += PlayerStats_OnChangeMoney;
        }

        private void PlayerStats_OnChangeMoney(object sender, PlayerStats.OnCoins moneyArgs)
        {
            _coinsCounter.text = moneyArgs.coinsCount.ToString();
        }

        private void OnDisable()
        {
            PlayerStats.Instance.OnChangeMoney -= PlayerStats_OnChangeMoney;
        }
    }
}