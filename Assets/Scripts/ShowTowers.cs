using System;
using UnityEngine;

namespace TowerSpace
{
    public class ShowTowers : MonoBehaviour
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
            
            Debug.Log("Start");
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