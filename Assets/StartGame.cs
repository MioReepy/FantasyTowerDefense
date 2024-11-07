using System;
using UnityEngine;

namespace TowerSpace
{
    public class StartGame : MonoBehaviour
    {
        private bool isFirstUpdate = true;
        
        public static event EventHandler OnStartGame;

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