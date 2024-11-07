using System;
using PlayerSpace;
using UnityEngine;
using WaveSpawnerSpace;

public class Finish : MonoBehaviour
{
    private int _enemyCount;
    
    public static Finish Instance;
    private void Awake() => Instance = this;

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
            Debug.Log("Win");
        }
        
        Debug.Log(_enemyCount);
    }
}
