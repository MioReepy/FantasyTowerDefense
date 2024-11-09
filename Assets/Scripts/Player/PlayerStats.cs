using System;
using UnityEngine;

namespace PlayerSpace
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats Instance;

        [SerializeField] private int _startMoney = 300;
        [SerializeField] private int _startLifes = 5;
        internal int money;
        internal int lifes;
        
        public event EventHandler<OnCoins> OnChangeMoney;
        public class OnCoins : EventArgs
        {
            public int coinsCount;
        }
        
        public event EventHandler<OnLifes> OnChangeLifes;
        public class OnLifes : EventArgs
        {
            public int lifesCount;
        }

        private void Awake()
        {
            Instance = this;
            money = _startMoney;
            lifes = _startLifes;
        }

        internal void SetMoney(int money)
        {
            this.money += money;
            
            OnChangeMoney?.Invoke(this, new OnCoins
            {
                coinsCount = this.money,
            });
        }
        
        internal void SetLifes()
        {
            lifes--;
            
            OnChangeLifes?.Invoke(this, new OnLifes
            {
                lifesCount = lifes,
            });
        }
    }
}