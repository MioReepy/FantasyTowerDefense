using System;
using System.Collections;
using System.Collections.Generic;
using EnemySpace;
using UnityEngine;
using WaypointSpase;
using Random = UnityEngine.Random;

namespace WaveSpawnerSpace
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _timeBetweenEnemies = 0.5f;
        private float _coolDownWaves = 5f;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] internal float _waveSpawnerWidth = 5f;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        [SerializeField] private Waypoint _waypoint;

        private int _currentWave = 0;

        private List<Enemies> _enemyObjects;

        private void Awake()
        {
            for (int wave = 0; wave < waves.Length; wave++)
            {
                for (int enemy = 0; enemy < waves[wave].enemies.Length; enemy++)
                {
                    var enemyObject = waves[wave].enemies[enemy];
                    enemyObject.waveNumber = wave;
                    _enemyObjects.Add(enemyObject);
                }
            }
        }

        private void Start()
        {
            minBounds = transform.position + transform.right * _waveSpawnerWidth / 2;
            maxBounds = transform.position - transform.right * _waveSpawnerWidth / 2;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_currentWave < waves.Length)
            {
                foreach (var enemy in _enemyObjects)
                {
                    if (enemy.waveNumber == _currentWave)
                    {
                        for (int i = 0; i < enemy.enemyCount; i++)
                        {
                            SpawnEnemy(enemy.enemyObject);
                            yield return new WaitForSeconds(_timeBetweenEnemies);   
                        }
                    }
                }

                _currentWave++;
                yield return new WaitForSeconds(_timeBetweenWaves);
            }
        }

        private void SpawnEnemy(EnemyObject enemy)
        {
            GameObject enemyObject = EnemyObjectPool.Singleton.GetPoolObject(enemy);

            if (enemyObject != null)
            {
                enemyObject.GetComponent<WaypointNavigator>().UpdateWaypoint(_waypoint);
                Vector3 spawnPosition = Vector3.Lerp(minBounds, maxBounds, Random.Range(0f, 1f));
                
                enemyObject.transform.parent = EnemyObjectPool.Singleton.spawnObject.transform;
                enemyObject.transform.position = spawnPosition;
                enemyObject.transform.rotation = transform.rotation;

                enemyObject.SetActive(true);
            }
        }
    }
}