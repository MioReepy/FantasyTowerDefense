using UnityEngine;

namespace PlayerSpace
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats Instance;

        [SerializeField] private int _startMoney = 500;
        internal int money;

        internal void Awake()
        {
            Instance = this;
            money = _startMoney;
        }
    }
}