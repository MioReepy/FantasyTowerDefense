using System;
using PlayerSpace;
using UISpace;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private int _enemyCount;
    
    public static Finish Instance;
    private void Awake() => Instance = this;

    private void Start()
    {
        PlayerStats.Instance.OnChangeLifes += PlayerStats_OnChangeLifes;
    }

    private void PlayerStats_OnChangeLifes(object sender, PlayerStats.OnLifes lifes)
    {
        if (lifes.lifesCount <= 0)
        {
            UISystem.Instance.OpenWindow(WindowType.GameOver);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            PlayerStats.Instance.SetLifes();
        }
    }

    internal void SetEnemy(int enemyCount)
    {
        _enemyCount += enemyCount;
    }

    internal void EnemyDied()
    {
        _enemyCount--;

        if (_enemyCount < 1)
        {
            // UISystem.Instance.OpenWindow(WindowType.GameOver);
            // Time.timeScale = 0;
        }
        
        Debug.Log(_enemyCount);
    }
}
