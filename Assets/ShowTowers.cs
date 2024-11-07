using System;
using UnityEngine;

namespace TowerSpace
{
    public class ShowTowers : MonoBehaviour
    {
        private void Awake()
        {
            StartGame.OnStartGame += StartGame_OnStartGame;
        }

        private void StartGame_OnStartGame(object sender, EventArgs e)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Debug.Log(gameObject.transform.GetChild(i).name);
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}