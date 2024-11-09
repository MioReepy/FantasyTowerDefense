using System;
using UnityEngine;

namespace TowerSpace
{
    public class StartGame : MonoBehaviour
    {
        private bool isFirstUpdate = true;
        
        public static event EventHandler OnStartGame;

        public static void ResetStaticData()
        {
            OnStartGame = null;
        }

        private void Update()
        {
            if (isFirstUpdate)
            {
                OnStartGame?.Invoke(this, EventArgs.Empty);
                
                isFirstUpdate = false;
            }
        }
    }
}