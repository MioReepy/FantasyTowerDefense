using System;
using UnityEngine;

namespace PlayerSpace
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats Instance;

        [SerializeField] private int _startMoney = 500;
        internal int money;
        
        public event EventHandler<OnCoins> OnChangeMoney;
        public class OnCoins : EventArgs
        {
            public int coinsCount;
        }

        private void Awake()
        {
            Instance = this;
            money = _startMoney;
        }

        internal void SetMoney(int money)
        {
            this.money -= money;
            
            OnChangeMoney?.Invoke(this, new OnCoins
            {
                coinsCount = this.money,
            });
        }
    }
}