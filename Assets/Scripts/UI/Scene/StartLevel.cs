using System;
using GameController;
using UISpace;
using UnityEngine;

namespace TowerSpace
{
    public class StartLevel : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1;
            StartGame.OnStartGame += StartGame_OnStartGame;
        }

        private void StartGame_OnStartGame(object sender, EventArgs e)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            
            UISystem.Instance.OpenWindow(WindowType.LevelUI);
        }

        private void OnDisable()
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            
            StartGame.OnStartGame -= StartGame_OnStartGame;
        }
    }
}