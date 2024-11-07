using System;
using PlayerSpace;
using UnityEngine;
using WaveSpawnerSpace;

public class Finish : MonoBehaviour
{
    private int _enemyCount;
    
    public static Finish Instance;
    private void Awake() => Instance = this;

    private void Start()
    {
        _enemyCount = WaveSpawner.Instance._enemyObjects.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            PlayerStats.Instance.SetLifes();
        }
    }
}
