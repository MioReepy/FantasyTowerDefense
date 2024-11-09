using TowerSpace;
using UnityEngine;

public class RestartStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        Builder.ResetStaticData();
        SelectingTowers.ResetStaticData();
        StartGame.ResetStaticData();
    }
}