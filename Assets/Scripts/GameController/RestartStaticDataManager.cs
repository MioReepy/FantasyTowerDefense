using TowerSpace;
using UnityEngine;

namespace GameController
{
    public class RestartStaticDataManager : MonoBehaviour
    {
        private void Awake()
        {
            Builder.ResetStaticData();
            SelectingTowers.ResetStaticData();
            StartGame.ResetStaticData();
        }
    }
}